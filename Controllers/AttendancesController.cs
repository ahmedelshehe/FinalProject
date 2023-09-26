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

            var attendanceSelected =attendanceRepository.GetAttendance(id,date);
            if (attendanceSelected == null)
            {
                return NotFound();
            }

            return View(attendanceSelected);
        }

        // GET: Attendances/Create
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
        public async Task<IActionResult> Edit(int id,DateTime date)
        {
           var ediedAttendane = attendanceRepository.GetAttendance(id,date);
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "FirstName", id);
            return View(ediedAttendane);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Delete(int id,DateTime date)
        {
            var delAttendance = attendanceRepository.GetAttendance(id,date);
            return View(delAttendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, DateTime date)
        {

			var delAttendance = attendanceRepository.GetAttendance(id, date);
			attendanceRepository.DeleteAttendance(delAttendance);
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id, DateTime date) 
        {
          return attendanceRepository.AttendanceExists(id,date);
        }
    }
}
