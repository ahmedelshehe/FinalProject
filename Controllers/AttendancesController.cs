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

namespace FinalProject.Controllers
{
    public class AttendancesController : Controller
    {
        public IEmployeeRepository employeeRepository { get; set; }
        public IDepartmentRepository departmentRepository { get; set; }
        private readonly IAttendanceRepositoryService attendanceRepository;

        public AttendancesController(IAttendanceRepositoryService _attendanceRepository, IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository)
        {
            attendanceRepository = _attendanceRepository;
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
        }



    
    public async Task<IActionResult> Index()
        {
            return View(attendanceRepository.GetAttendances().ToList());

        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int id, DateTime date)
        {
            Attendance attendance = new Attendance();
            attendance.EmployeeId = id;
            attendance.Date = date;
            if (id == null || id <= 0 || date == null)
            {
                return NotFound();
            }

            var attendanceSelected =attendanceRepository.GetAttendance(attendance);
            if (attendanceSelected == null)
            {
                return NotFound();
            }

            return View(attendanceSelected);
        }

        // GET: Attendances/Create
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
        public async Task<IActionResult> Edit(int id,DateTime date)
        {
            if (id == null || id <= 0 || date == null )
            {
                return NotFound();
            }
            Attendance attendance = new Attendance();
            attendance.EmployeeId = id;
            attendance.Date = date;
           var ediedAttendane = attendanceRepository.GetAttendance(attendance);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", attendance.EmployeeId);
            return View(ediedAttendane);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ArrivalTime,DepartureTime,Date,EmployeeId")] Attendance attendance)
        {
            if (attendance.EmployeeId == null || attendance.EmployeeId <= 0 || attendance.Date==null )
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Delete(int id,DateTime date)
        {
            if (id == null || id<=0 ||date == null)
            {
                return NotFound();
            }
            Attendance attendance = new Attendance();
            attendance.EmployeeId = id;
            attendance.Date = date;

            var delAttendance = attendanceRepository.GetAttendance(attendance);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(delAttendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
          return attendanceRepository.AttendanceExists(id,date);
        }
    }
}
