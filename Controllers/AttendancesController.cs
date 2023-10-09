using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.RepoServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.StaticFiles;
using FinalProject.ViewModels;
using FinalProject.Utilities;
using PagedList;
using Microsoft.AspNetCore;
using X.PagedList;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly IHostingEnvironment Environment;
        private IConfiguration Configuration;
        private IEmployeeRepository employeeRepository { get; set; }
        private IDepartmentRepository departmentRepository { get; set; }
        private UserManager<AppUser> userManager { get; set; }
        private readonly IAttendanceRepositoryService attendanceRepository;
        public AttendancesController(IAttendanceRepositoryService _attendanceRepository, IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository, IHostingEnvironment _environment, IConfiguration _configuration, UserManager<AppUser> _userManager)
        {

            attendanceRepository = _attendanceRepository;
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
            Environment = _environment;
            Configuration = _configuration;
            userManager = _userManager;
        }

        [AuthorizeByEntity("Attendance")]
        public async Task<IActionResult> Index()
        {
			var attendances = attendanceRepository.GetAttendances().ToList();
			return View(attendances);

        }

        [HttpPost]
        [HttpGet]
        public async  Task<IActionResult> SearchIndex(string searchName,DateTime to ,DateTime from)
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
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);

            var attendacesEmployeeReport = attendanceRepository.GetEmployeeAttendancesByEmployeeID(user.EmpId);

            return View(attendacesEmployeeReport);

        }

        [HttpPost]
        [AuthorizeByPermission("Attendance",Operation.Show)]
        public async Task<IActionResult> Search(DateTime Date)
        {
            var attendances = attendanceRepository.GetAttendances().Where(a => a.Date.Date == Date.Date);

            return View("Index", attendances);

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
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [AuthorizeByPermission("Attendance", Operation.Add)]
        public IActionResult Create([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
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
        public IActionResult Edit(int id, DateTime date)
        {

            var editedAttendane = attendanceRepository.GetAttendance(id, date);
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
        public IActionResult Edit([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
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

		[AuthorizeByPermission("Attendance", Operation.Add)]
		public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
		[AuthorizeByPermission("Attendance", Operation.Add)]
		public IActionResult UploadFile(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                attendanceRepository.insertBulk(attendanceList);

            }
            return RedirectToAction("Index", attendanceRepository.GetAttendances().ToList());


        }

        [HttpPost]
		[AuthorizeByPermission("Attendance", Operation.Add)]
		public FileStreamResult UploadFileWithSaveFileStatus(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                var statusList = attendanceRepository.InsertAttendanceList(attendanceList);
                if (statusList != null)
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                    string contentType = "";
                    new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out contentType);
                    return new FileStreamResult(file, contentType);
                }
            }
            return null;
        }

        [HttpPost]
		[AuthorizeByPermission("Attendance", Operation.Add)]
		public ActionResult UploadFileWithSaveFileStatusUpdateWithDownloadButton(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
                  var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
                if (statusList.Count != 0 )
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                    ViewBag.flagDownload = true;

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
		[AuthorizeByPermission("Attendance", Operation.Add)]
		public ActionResult UploadFileWithSaveFileStatusWithDownloadButton(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                var dt = attendanceRepository.ReadExcel(postedFile);
                var attendanceList = attendanceRepository.convertDataTableToListAttendance(dt);
               var statusList = attendanceRepository.InsertBulkAttendanceAndUpdateIFExist(attendanceList);
                if (statusList.Count != 0)
                {
                    var file = attendanceRepository.InsertDataInfileAndDownloadIt(statusList);
                    // DownloadFile(file);
                    ViewBag.flagDownload = true;

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

		[AuthorizeByPermission("Attendance", Operation.Add)]
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

