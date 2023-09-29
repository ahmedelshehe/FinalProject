using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.IO;
using System.IO.Pipes;
using System.Net.Mime;
using Microsoft.AspNetCore.StaticFiles;
using FinalProject.Helper;
using FinalProject.Utilities;


namespace FinalProject.Controllers
{

    public class AttendancesController : Controller
    {
        private IHostingEnvironment Environment;
        private IConfiguration Configuration;
        public IEmployeeRepository employeeRepository { get; set; }
        public IDepartmentRepository departmentRepository { get; set; }
        private readonly IAttendanceRepositoryService attendanceRepository;

        public AttendancesController(IAttendanceRepositoryService _attendanceRepository, IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository, IHostingEnvironment _environment, IConfiguration _configuration)
        {

            attendanceRepository = _attendanceRepository;
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
            Environment = _environment;
            Configuration = _configuration;
        }




        public async Task<IActionResult> Index()
        {
            return View(attendanceRepository.GetAttendances().ToList());

        }

        // GET: Attendances/Details/5
        [AuthorizeByPermission("Attendances", Operation.Show)]

        public async Task<IActionResult> Details(int id, DateTime date)
        {

            var attendanceSelected =attendanceRepository.GetAttendance(id,date);
            if (attendanceSelected == null)
            {
                return NotFound();
            }

            return View(attendanceSelected);
        }

        // GET: Attendances/Create
        [AuthorizeByPermission("Attendances", Operation.Add)]

        public IActionResult Create()
        {

            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Attendances", Operation.Add)]

        public async Task<IActionResult> Create([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
        {
			ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName");
			if (ModelState.IsValid)
            {
                try
                {
                    if(attendance.DepartureTime.TimeOfDay < attendance.ArrivalTime.TimeOfDay)
                    {
                        ModelState.AddModelError("DepartureTime", "DepartureTime has to be after arrival time");
                        return View(attendance);
                    }else if(attendance.Date.Date > DateTime.Now.Date) {
						ModelState.AddModelError("Date", "Date Cannot be in the future");
						return View(attendance);
					}
					attendanceRepository.InsertAttendance(attendance);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", attendance.EmployeeId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5

        [AuthorizeByPermission("Attendances", Operation.Update)]

        public async Task<IActionResult> Edit(int id,DateTime date)
        {
           var editedAttendane = attendanceRepository.GetAttendance(id,date);
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", id);
            return View(editedAttendane);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Attendances", Operation.Update)]

        public async Task<IActionResult> Edit([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
        {

            if (ModelState.IsValid)
            {
                try
                {

					if (attendance.DepartureTime.TimeOfDay < attendance.ArrivalTime.TimeOfDay)
					{
						ModelState.AddModelError("DepartureTime", "DepartureTime has to be after arrival time");
						return View(attendance);
					}
					else if (attendance.Date.Date > DateTime.Now.Date)
					{
						ModelState.AddModelError("Date", "Date Cannot be in the future");
						return View(attendance);
					}

					attendanceRepository.UpdateAttendance(attendance);
                    
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", attendance.EmployeeId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5

        [AuthorizeByPermission("Attendances", Operation.Delete)]

        public async Task<IActionResult> Delete(int id,DateTime date)
        {
            var delAttendance = attendanceRepository.GetAttendance(id,date);
            return View(delAttendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Attendances", Operation.Delete)]

        public async Task<IActionResult> DeleteConfirmed(int id, DateTime date)
        {

			var delAttendance = attendanceRepository.GetAttendance(id, date);
			attendanceRepository.DeleteAttendance(delAttendance);
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id, DateTime date)
        {
            return attendanceRepository.AttendanceExists(id, date);
        }

        public async Task<IActionResult> UploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //var dt = attendanceRepository.ReadUploadedFile(postedFile);
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                attendanceRepository.insertBulk(attendanceList);

            }
            return RedirectToAction("Index", attendanceRepository.GetAttendances().ToList());


        }

        [HttpPost]
        public FileStreamResult UploadFileWithSaveFileStatus(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                var statusList = attendanceRepository.InsertAttendanceList(attendanceList);
                //  var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
                if (statusList != null)
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                    //Determine the Content Type of the File.
                    string contentType = "";
                    new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out contentType);
                    //  return file;
                    return new FileStreamResult(file, contentType);
                }
            }
            return null;
        }

        [HttpPost]
        public ActionResult UploadFileWithSaveFileStatusUpdateWithDownloadButton(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
              //  var statusList = attendanceRepository.InsertAttendanceList(attendanceList);
                  var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
                if (statusList.Count != 0 )
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                   // DownloadFile(file);
                    ViewBag.flagDownload = true;
                    //   ViewBag.file = file.Name;

                    var fullPath = file.Name;
                    ViewBag.FullPath = fullPath;

                    return View("create");
                }
                return RedirectToAction("Index", attendanceRepository.GetAttendances());

            }
            else
            {
                return RedirectToAction("Index", attendanceRepository.GetAttendances());

            }
        }
        [HttpPost]
        public ActionResult UploadFileWithSaveFileStatusWithDownloadButton(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                  var statusList = attendanceRepository.InsertAttendanceList(attendanceList);
               // var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
                if (statusList.Count != 0)
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                    // DownloadFile(file);
                    ViewBag.flagDownload = true;
                    //   ViewBag.file = file.Name;

                    var fullPath = file.Name;
                    ViewBag.FullPath = fullPath;

                    return View("create");
                }
                return RedirectToAction("Index", attendanceRepository.GetAttendances());

            }
            else
            {
                return RedirectToAction("Index", attendanceRepository.GetAttendances());

            }
        }

        public FileStreamResult DownloadFile(string fullPath)
        {
            //Determine the Content Type of the File.
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fullPath, out contentType);

            //Build the File Path.

            //Read the File data into FileStream.
            FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);

            //Send the File to Download. 
            return new FileStreamResult(fileStream, contentType);
        }
    }
}

