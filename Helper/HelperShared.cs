using System.ComponentModel;

namespace FinalProject.Helper
{
    public static class HelperShared
    {

        public static async Task <string>  SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
            
            return path;
        }
        public static FileStream DownloadFile(string fileName, string path)
        {

            //string path = @"\\192.168.2.116\Share\Basant\Reports\";
            var file = Path.Combine(Path.Combine(path), fileName);
            return new FileStream(file, FileMode.Open, FileAccess.Read);
        }
        public static FileStream writeStatusInsertInCsvFileAndReturnFile<T>(List<T> list, string dirPath)
        {
            string fileName = "Report" + new Guid() + ".csv";
            string saveToPath = Path.Combine(dirPath, fileName);

            SaveToCsv(list, saveToPath);

            var file = DownloadFile(fileName, dirPath);
            return file;

        }

        public static FileStream DownloadFileAllType(string fileName)
        {
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory + "\\src\\assets";
            var file = Path.Combine(Path.Combine(currentDirectory, "attachments"), fileName);
            return new FileStream(file, FileMode.Open, FileAccess.Read);
        }
    }
}
