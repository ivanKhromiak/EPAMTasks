using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ExcelOperations
{
    class ExcelReaderHashSet: IExcelReader
    {
        private readonly HashSet<string> _uniqueValues;

        public ExcelReaderHashSet(string path, int sourceColumn, int sourceComparer)
        {
            Validate(path, sourceColumn, sourceComparer);

            _uniqueValues = SetUnique(path, sourceColumn, sourceComparer);
        }

        public ICollection<string> GetUnique()
        {
            return _uniqueValues;
        }

        private HashSet<string> SetUnique(string path, int sourceColumn, int comparerColumn)
        {
            var file = new FileInfo(path);

            var source = new HashSet<string>();
            var comparer = new HashSet<string>();

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCount = 1;
                while (worksheet.Cells[rowCount, sourceColumn].Value != null)
                {
                    source.Add(worksheet.Cells[rowCount, sourceColumn].Value.ToString());
                    rowCount++;
                }

                rowCount = 1;
                while (worksheet.Cells[rowCount, comparerColumn].Value != null)
                {
                    comparer.Add(worksheet.Cells[rowCount, comparerColumn].Value.ToString());
                    rowCount++;
                }
            }

            source.SymmetricExceptWith(comparer);
            return source;
        }

        private void Validate(string path, int sourceColumn, int sourceComparer)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("The path is empty");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("No such file: " + path);
            }
            if (!path.EndsWith(".xlsx"))
            {
                throw new ArgumentException("The file is not Excel format");
            }
            if(sourceColumn <= 0 || sourceComparer <= 0)
            {
                throw new ArgumentOutOfRangeException("Coluns can't be less than zero or equal");
            }
        }
    }
}
