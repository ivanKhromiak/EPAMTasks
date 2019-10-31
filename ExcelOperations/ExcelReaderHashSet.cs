using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ExcelOperations
{
    class ExcelReaderHashSet: IExcelReader
    {
        private HashSet<string> _uniqueValues = new HashSet<string>();

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
            FileInfo file = new FileInfo(path);

            var source = new HashSet<string>();
            var comparer = new HashSet<string>();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int rowCaunt = 1;
                while (worksheet.Cells[rowCaunt, sourceColumn].Value != null)
                {
                    source.Add(worksheet.Cells[rowCaunt, sourceColumn].Value.ToString());
                    rowCaunt++;
                }

                rowCaunt = 1;
                while (worksheet.Cells[rowCaunt, comparerColumn].Value != null)
                {
                    comparer.Add(worksheet.Cells[rowCaunt, comparerColumn].Value.ToString());
                    rowCaunt++;
                }
            }

            var unique = new HashSet<string>(source);
            unique.UnionWith(comparer);
            var dublicate = new HashSet<string>(source);
            dublicate.IntersectWith(comparer);
            unique.ExceptWith(dublicate);
            return unique;
        }

        private void Validate(string path, int sourceColumn, int sourceComparer)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            if(sourceColumn <= 0 || sourceComparer <= 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
