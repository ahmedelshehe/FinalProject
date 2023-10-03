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
using FinalProject.ViewModels;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Controllers
{

    public class AttendancesController : Controller
    {
        private readonly IHostingEnvironment Environment;
        private IConfiguration Configuration;
        private IEmployeeRepository employeeRepository { get; set; }
        private IDepartmentRepository departmentRepository { get; set; }
        private UserManager<AppUser> userManager { get; set; }
        private readonly IAttendanceRepositoryService attendanceRepository;
        

private readonly HttpContext httpContext;

        public AttendancesController(IAttendanceRepositoryService _attendanceRepository, IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository, IHostingEnvironment _environment, IConfiguration _configuration, UserManager<AppUser> _userManager, IHttpContextAccessor httpContextAccessor)
        {

            attendanceRepository = _attendanceRepository;
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
            Environment = _environment;
            Configuration = _configuration;
            userManager = _userManager;
            httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = attendanceRepository.GetAttendances().ToList();
			return View(attendances);

        }
        public async Task<IActionResult> SearchIndex()
        {
            

            return View(attendanceRepository.GetEmployeeAttendancesByName(""));
        }
        [HttpPost]
        public  IActionResult SearchIndex(string searchName,DateTime to ,DateTime from)
        {
            var list = new List<EmployeeAttendanceVM>();
            ViewBag.EmployeeName=searchName;
            ViewBag.DeptName=searchName;
            ViewBag.to=to;
            ViewBag.from=from;

                if (attendanceRepository.GetAttendances() != null)
                {
                if( to == new DateTime() || from == new DateTime())
                {
                    list = attendanceRepository.GetEmployeeAttendancesByName(searchName);

                }
                if (list == null || list.Count == 0 && to == new DateTime() && from == new DateTime())
                {
                    list = attendanceRepository.GetEmployeeAttendancesByDeptName(searchName);

                }
                if (list == null || list.Count==0 )
                    {
                    if (to != new DateTime() && from == new DateTime())
                    {
                        from = to;
                    }


                    else if (to == new DateTime() && from != new DateTime())
                        {
                            to = from;
                        }
                    list = attendanceRepository.GetEmployeeAttendancesByNameAndDate(to, from, searchName);
                 
                }
                if (list == null || list.Count == 0)
                {
                    list = attendanceRepository.GetEmployeeAttendancesByDeptNameAndDate(to, from, searchName);

                }



            }
            return View(list) ;

        }
     
        [HttpGet]
        public async Task<IActionResult> EmployeeReport()
        {
            // Retrieve the current user's username
            string username = httpContext.User.Identity.Name;



            var user =  await userManager.FindByNameAsync(username);

            var attendacesEmployeeReport = attendanceRepository.GetEmployeeAttendancesByEmployeeID(user.EmpId);

            //var user = await UserManager.GetAsync(User);

            return View(attendacesEmployeeReport);

        }

        [HttpPost]
        public async Task<IActionResult> Search(DateTime Date)
        {

            var attendaces = attendanceRepository.GetAttendances().Where(a => a.Date.Date == Date.Date);

            return View("Index",attendaces);

        }
        // GET: Attendances/Details/5
        [AuthorizeByPermission("Attendance", Operation.Show)]
        public async Task<IActionResult> Details(int id, DateTime date)
        {
           
            var attendanceSelected = attendanceRepository.GetAttendance(id,date);
            if (attendanceSelected == null)
            {
                return NotFound();
            }

            return View(attendanceSelected);
        }

        // GET: Attendances/Create
        [AuthorizeByPermission("Attendance", Operation.Add)]

        public IActionResult Create()
        {
            //if (employeeRepository.GetEmployees() != null)
            //{
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName");

            //}
            //else
            //{
            //    ViewData["EmployeeId"] = null;

            //}

            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [AuthorizeByPermission("Attendance", Operation.Add)]


        public async Task<IActionResult> Create([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                try
                {

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


        [AuthorizeByPermission("Attendance", Operation.Update)]

        public async Task<IActionResult> Edit(int id,DateTime date)
        {
           
            var editedAttendane = attendanceRepository.GetAttendance(id,date);
            if (editedAttendane == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", editedAttendane.EmployeeId);
            return View(editedAttendane);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [AuthorizeByPermission("Attendance", Operation.Update)]

        public async Task<IActionResult> Edit([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
        {
           

            if (ModelState.IsValid)
            {
                try
                {


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
        
        [AuthorizeByPermission("Attendance", Operation.Delete)]

        public async Task<IActionResult> Delete(int id,DateTime date)
        {
           

            var delAttendance = attendanceRepository.GetAttendance(id,date);
           

            return View(delAttendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [AuthorizeByPermission("Attendance", Operation.Delete)]

        public async Task<IActionResult> DeleteConfirmed(int id, DateTime date)
        {
            if (id == null || id <= 0 || date == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Attendances'  is null.");
            }
            Attendance attendance = new Attendance();
            attendance.EmployeeId = id;
            attendance.Date = date;


            attendanceRepository.DeleteAttendance(attendance);
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id, DateTime date)
        {
            return attendanceRepository.AttendanceExists(id, date);
        }

        public  IActionResult UploadFile()
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
                  //var statusList = attendanceRepository.InsertAttendanceList(attendanceList);
               var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
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

