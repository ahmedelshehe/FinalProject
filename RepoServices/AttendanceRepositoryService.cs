﻿using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.IO;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Hosting;
using ExcelDataReader;
using System.ComponentModel;
using FinalProject.Helper;
using FinalProject.ViewModels.FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Headers;
using ExcelDataReader.Log.Logger;
using System.Collections.Generic;

namespace FinalProject.RepoServices
{
    public class AttendanceRepositoryService : IAttendanceRepositoryService
    {
        private IHostingEnvironment Environment;
        private IConfiguration Configuration;
        IExcelDataReader reader;

        public ApplicationDbContext context { get; }


        public AttendanceRepositoryService(ApplicationDbContext _context, IHostingEnvironment _environment, IConfiguration _configuration) {
            Environment = _environment;
            Configuration = _configuration;



            context = _context;
        }

        public List<Attendance> GetAttendances()
        {
            return context.Attendances.Include("Employee").ToList();
        }


        public  Attendance GetAttendance(int id,DateTime Date)
        {
            try
            {
                Attendance selectedAttendance = context.Attendances.Where(a => a.EmployeeId == id && a.Date == Date).Include("Employee").FirstOrDefault();
				if(selectedAttendance !=null)
                {
                return selectedAttendance;
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

                return null;
            }
        }

        public void InsertAttendance(Attendance attendance)
        {
            if (attendance != null)
            {
                context.Attendances.Add(attendance);
                context.SaveChanges();
            }
        }
   

        public  List<EmployeeAttendanceVM> GetEmployeeAttendancesByDeptName(string Deptname)
        {
            if (Deptname != null)
            {
                if (GetAttendances() != null)
                {

                    var parameter = new List<SqlParameter>();
                    parameter.Add(new SqlParameter("@DeptName", Deptname));

                    var list = context.EmployeeAttendanceReport.FromSqlRaw("exec SelectAllEmployeesByDeptName  @DeptName", parameter.ToArray()).ToList();



                    return list;
                }
            }
            return null;
        }
        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByName(string name = "")
        {
           
            string fname = "";
            string lname = "";

            if (GetAttendances() != null)
            {
                if (name == null || name == "")
                {


                }
                else
                {
                    var words = name.Split(' ');
                    fname = words[0];
                    lname = "";

                    if (words.Length > 0)
                    {

                        if (words.Length == 1)
                        {
                            fname = words[0];

                        }
                        else if (words.Length == 2)
                        {
                            lname = words[1];
                          
                        }
                    }
                }
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@FName", fname));
                parameter.Add(new SqlParameter("@LName", lname));
               

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByName @FName , @LName", parameter.ToArray()).ToList();
                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return null;

                }
            }
            return null;
        }

        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByEmployeeID(int empId )
        {
            if (GetAttendances() != null)
            {
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@EmpID", empId));

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByEmployeeId  @EmpID", parameter.ToArray()).ToList();
                   
                    return list;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return null;

                }

            }
            return null;
        }

        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByNameAndDate(DateTime startDate, DateTime endDate, string name = "")
        {
            
            string fname = "";
            string lname = "";

            if (GetAttendances() != null)
                {
                if (name == null || name == "" )
                {
                   

                }
                else
                {
                    var words = name.Split(' ');
                    fname = words[0];
                    lname = "";

                    if (words.Length > 0)
                    {

                        if (words.Length == 1)
                        {
                            fname = words[0];

                        }
                        else if (words.Length == 2)
                        {
                            lname = words[1];
                         
                        }
                    }
                }
                    var parameter = new List<SqlParameter>();
                    parameter.Add(new SqlParameter("@FName", fname));
                    parameter.Add(new SqlParameter("@LName", lname));
                    parameter.Add(new SqlParameter("@startDate", startDate));
                    parameter.Add(new SqlParameter("@EndDate", endDate));

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByNameAndDate @FName , @LName ,@startDate,@EndDate", parameter.ToArray()).ToList();

                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return null;

                }
                   
            }
            return null;
        }
        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByDeptNameAndEmployeeNameAndDate(DateTime startDate, DateTime endDate, string depName = "",string empName="")
        {
           

           
                string fname = "";
                string lname = "";

                if (GetAttendances() != null)
                {
                    if (empName == null || empName == "")
                    {


                    }
                    else
                    {
                        var words = empName.Split(' ');
                        fname = words[0];
                        lname = "";

                        if (words.Length > 0)
                        {

                            if (words.Length == 1)
                            {
                                fname = words[0];

                            }
                            else if (words.Length == 2)
                            {
                                lname = words[1];

                            }
                        }
                    }
                    var parameter = new List<SqlParameter>();
                    parameter.Add(new SqlParameter("@FName", fname));
                    parameter.Add(new SqlParameter("@LName", lname));
                    parameter.Add(new SqlParameter("@DeptName", depName));
                    parameter.Add(new SqlParameter("@startDate", startDate));
                    parameter.Add(new SqlParameter("@EndDate", endDate));

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByEmpNameAndDeptNameAndDate  @FName ,@LName ,@DeptName ,@startDate,@EndDate", parameter.ToArray()).ToList();

                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return null;

                }            
            }
            return null;
        }
        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByDeptNameAndEmployeeName( string depName = "",string empName="")
        {
           

           
                string fname = "";
                string lname = "";

                if (GetAttendances() != null)
                {
                    if (empName == null || empName == "")
                    {


                    }
                    else
                    {
                        var words = empName.Split(' ');
                        fname = words[0];
                        lname = "";

                        if (words.Length > 0)
                        {

                            if (words.Length == 1)
                            {
                                fname = words[0];

                            }
                            else if (words.Length == 2)
                            {
                                lname = words[1];

                            }
                        }
                    }
                    var parameter = new List<SqlParameter>();
                    parameter.Add(new SqlParameter("@FName", fname));
                    parameter.Add(new SqlParameter("@LName", lname));
                    parameter.Add(new SqlParameter("@DeptName", depName));
                 

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByEmpNameAndDeptName @FName ,@LName, @DeptName ", parameter.ToArray()).ToList();

                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return null;

                }            
            }
            return null;
        }
        public List<EmployeeAttendanceVM> GetEmployeeAttendancesByDeptNameAndDate(DateTime startDate, DateTime endDate, string name = "")
        {
           

            if (GetAttendances() != null)
                {
                    var parameter = new List<SqlParameter>();
                    parameter.Add(new SqlParameter("@DeptName", name));
                    parameter.Add(new SqlParameter("@startDate", startDate));
                    parameter.Add(new SqlParameter("@EndDate", endDate));

                try
                {
                    var list = context.EmployeeAttendanceReport.FromSqlRaw("EXECUTE SelectAllEmployeesByDeptNameAndDate @DeptName ,@startDate,@EndDate", parameter.ToArray()).ToList();

                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return null;

                }            
            }
            return null;
        }


        public void UpdateAttendance(Attendance attendance)
        {
            try
            {
                Attendance editAttendance = context.Attendances.Include("Employee")
                    .FirstOrDefault(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date);
                if (editAttendance != null)
                {
                    editAttendance.ArrivalTime = attendance.ArrivalTime;
                    editAttendance.DepartureTime = attendance.DepartureTime;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        public void DeleteAttendance(Attendance attendance)
        {
            try
            {
				Attendance deleteAttendance = context.Attendances.Include("Employee")
					.FirstOrDefault(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date); 
                if (deleteAttendance != null)
                {
                    context.Attendances.Remove(deleteAttendance);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        public bool AttendanceExists(int id, DateTime date)
        {
            return (context.Attendances?.Any(e => e.Date == date && e.EmployeeId == id)).GetValueOrDefault();
        }
        public DataTable ReadUploadedFile(IFormFile postedFile)
        {
            DataTable dt = new DataTable();

            //Create a Folder.
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            //Save the uploaded Excel file.
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (postedFile.ContentType == "application/vnd.ms-excel" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {

                var connectionString = "";
                if (postedFile.FileName.EndsWith(".xls"))
                {
                    connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", filePath);
                }
                else if (postedFile.FileName.EndsWith(".xlsx"))
                {
                    connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", filePath);
                }
                //Read the connection string for the Excel file.
               // string conString = this.Configuration.GetConnectionString("ExcelConString");
               // conString = string.Format(conString, filePath);

                //using (OleDbConnection connExcel = new OleDbConnection(conString))
                using (OleDbConnection connExcel = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }
            }
            return dt;

        }

        public DataTable ReadExcel(IFormFile file)
        {
            DataTable dt = new DataTable();

            try
            {
                // Check the File is received

                if (file == null)
                    throw new Exception("File is Not Received...");


                // Create the Directory if it is not exist
                string dirPath = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                // MAke sure that only Excel file is used 
                string dataFileName = Path.GetFileName(file.FileName);

                string extension = Path.GetExtension(dataFileName);

                string[] allowedExtsnions = new string[] { ".xls", ".xlsx" };

                if (!allowedExtsnions.Contains(extension))
                    throw new Exception("Sorry! This file is not allowed, make sure that file having extension as either.xls or.xlsx is uploaded.");

                // Make a Copy of the Posted File from the Received HTTP Request
                string saveToPath = Path.Combine(dirPath, dataFileName);

                using (FileStream stream = new FileStream(saveToPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // USe this to handle Encodeing differences in .NET Core
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                // read the excel file
                using (var stream = new FileStream(saveToPath, FileMode.Open))
                {
                    if (extension == ".xls")
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    else
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    DataSet ds = new DataSet();
                    ds = reader.AsDataSet();
                    reader.Close();

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        // Read the the Table
                        dt = ds.Tables[0];

                    }

                  
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return dt;
        }
        public List<Attendance> convertDataTableToListAttendance(DataTable dt)
        {
            var attendanceList = new List<Attendance>();
            if (dt != null)
            {
                // Read the the Table
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                       if (dt.Rows[i].ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;


                    attendanceList.Add(new Attendance()
                    {
                        ArrivalTime = Convert.ToDateTime(dt.Rows[i][0].ToString()),
                        DepartureTime = Convert.ToDateTime(dt.Rows[i][1].ToString()),
                        Date = Convert.ToDateTime(dt.Rows[i][2].ToString()),
                        EmployeeId = Convert.ToInt32(dt.Rows[i][3].ToString())
                    });
                }
               
            }
            return attendanceList;

        }
        public string insertBulk(List<Attendance> attendancesList)
        {
            try
            {
                context.Attendances.AddRange(attendancesList);
                context.SaveChanges();
                return "Inserted Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message ;
            }


        }
        public List<AttendanceStatus> InsertAttendanceList(List<Attendance> attendancesList)
        {
            List<AttendanceStatus> list = new List<AttendanceStatus>();
            // Read the the List
            foreach (Attendance attendance in attendancesList)
            {
                try
                {
                    context.Attendances.Add(attendance);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    list.Add(new AttendanceStatus()
                    {
                        ArrivalTime = attendance.ArrivalTime,
                        Date = attendance.Date,
                        DepartureTime = attendance.DepartureTime,
                        EmployeeId = attendance.EmployeeId,
                        status = ex.Message

                    });
                    Console.WriteLine(ex.Message);
                }

            }

            return list;


        }

        public List<AttendanceStatus> InsertBulkAttendanceAndUpdateIFExist(List<Attendance> attendancesList)
        {
            List<AttendanceStatus> list = new List<AttendanceStatus>();
            // Read the the List
            foreach (Attendance attendance in attendancesList)
            {
                try
                {
                    context.Attendances.Add(attendance);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    try
                    {
                        context.Attendances.Update(attendance);
                        context.SaveChanges();

                        Console.WriteLine(ex.Message);

                    }
                    catch(Exception ex2)
                    {
                        list.Add(new AttendanceStatus()
                        {
                            ArrivalTime = attendance.ArrivalTime,
                            Date = attendance.Date,
                            DepartureTime = attendance.DepartureTime,
                            EmployeeId = attendance.EmployeeId,
                            status = ex2.Message

                        });
                        Console.WriteLine(ex.Message);

                    }

                }            

            }

            return list;


        }

        public FileStream InsertDataInfileAndDownloadIt(List<AttendanceStatus> attendanceStatuses)
        {
            // Create the Directory if it is not exist
            string dirPath = Path.Combine(this.Environment.WebRootPath, "Downloads");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
           var file = HelperShared.writeStatusInsertInCsvFileAndReturnFile(attendanceStatuses, dirPath);
            return file;
        }

        public List<Attendance> SearchAtendance()
        {
            throw new NotImplementedException();
        }

        public  string checkIn(Attendance attendance,string userName)
        {
            string msg = "";
            if (attendance != null)
            {
                try
                {
                    InsertAttendance(attendance);
                    msg = "INSERTED SUCCESSFULLY ";

                }
                catch(Exception ex)
                {
                    msg = ex.Message;
                }
            }
            else
            {
                msg = "ATTENDANCE IS EMPTY";
            }
            return msg;
        }
        public string checkOut(Attendance attendance,string userName)
        {
            string msg = "";
            if (attendance != null)
            {
                try
                {
                    UpdateAttendance(attendance);
                    msg = "UPDATED SUCCESSFULLY CHECKOUT ,"+userName;

                }
                catch (Exception ex)
                {
                    msg = ex.Message;

                }
            }
            else
            {
                msg ="ATTENDANCE IS EMPTY";
            }
            return msg;
        }

        public  string createAttendanceOnlineWorkFromHome(Attendance attendance ,string userName)
        {
            if(attendance != null)
            {
                if(GetAttendance(attendance.EmployeeId,attendance.Date)==null)
                {
                    checkIn(attendance, userName);
                }
                else
                {
                    checkOut(attendance, userName);
                }
            }
            return "";
        }
    }
}

