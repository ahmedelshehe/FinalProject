using FinalProject.Data;
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
                Attendance selectedAttendance = context.Attendances.Where(a => a.EmployeeId == attendance.EmployeeId && a.Date == attendance.Date).Include("Employee").FirstOrDefault();
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
                //foreach (DataRow objDataRow in dt.Rows)
                //{
                //    if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                //    attendanceList.Add(new Attendance()
                //    {
                //        ArrivalTime = Convert.ToDateTime(objDataRow["ArrivalTime"].ToString()),
                //        Date = Convert.ToDateTime(objDataRow["Date"].ToString()),
                //        DepartureTime = Convert.ToDateTime(objDataRow["DepartureTime"].ToString()),
                //        EmployeeId = Convert.ToInt32(objDataRow["EmployeeId"].ToString())
                       
                //    });
                //}
                // Add the record in Database
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

           // TimeSpan = DateTime.Now - Start; // check total time taken

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

                    }); ;
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



        /*


       [HttpPost]
       public IActionResult Index(IFormFile postedFile)
       {
           if (postedFile != null)
           {
               //Create a Folder.
               strin g path = Path.Combine(this.Environment.WebRootPath, "Uploadt");
               if (!Directory.Exists(path))
               {
                   Directory.CreateDirectory(path);
               }

               //Save the uploaded Excel file.
               string fileName = Path.GetFileName(postedFile.FileName);
               string filePath = Path.Combine(path, fileName);
               using (FileStream stream = new FileStream(filePath, FileMode.Create))
               {
                   postedFile.CopyTo(stream);
               } 

               //Read the connection string for the Excel file.
               string conString = this.Configuration.GetConnectionString("ExcelConString");
               DataTable dt = new DataTable();  
               conString = string.Format(conString, filePath);

               using (OleDbConnection connExcel = new OleDbConnection(conString))
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

               //Insert the Data read from the Excel file to Database Table.
               conString = this.Configuration.GetConnectionString("constr");
               using (SqlConnection con = new SqlConnection(conString))
               {
                   using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                   {
                       //Set the database table name.
                       sqlBulkCopy.DestinationTableName = "dbo.Customers";

                       //[OPTIONAL]: Map the Excel columns with that of the database table.
                       sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                       sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                       sqlBulkCopy.ColumnMappings.Add("Country", "Country");

                       con.Open();
                       sqlBulkCopy.WriteToServer(dt);
                       con.Close();
                   }
               }
           }

           return View();
       }
   }*/

    }
}

