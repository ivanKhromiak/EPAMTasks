using System;
using System.IO;
using OfficeOpenXml;

namespace UserInterface
{
    public class ExcelUI : IUserInterface
    {
        public string Path {get; private set;}

        private int _rowForReading = 1;

        private int _rowForWriting = 1;

        public ExcelUI(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("No such file");
            }

            Path = path;
        }

        public string Read()
        {
            FileInfo file = new FileInfo(Path);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Reading"];
                if (worksheet == null)
                    worksheet = package.Workbook.Worksheets.Add("Reading");
                string output = worksheet.Cells[_rowForReading, 1].Value.ToString();
                _rowForReading++;
                return output;
            }
        }

        public void Write(string input)
        {
            FileInfo file = new FileInfo(Path);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Writing"];
                if (worksheet == null)
                    worksheet = package.Workbook.Worksheets.Add("Writing");
                worksheet.Cells[_rowForWriting, 1].Value = input;
                _rowForWriting++;
                package.Save();
            }
        }
    }
}
