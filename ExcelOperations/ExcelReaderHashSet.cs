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

        private HashSet<string> SetUnique(string path, int sourceColumn, int sourceComparer)
        {
            FileInfo file = new FileInfo(path);

            var source = new HashSet<string>();
            var comparer = new HashSet<string>();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                for (int i = 1; i < rowCount; i++)
                {
                    source.Add(worksheet.Cells[i, sourceColumn].Value.ToString());
                }

                for (int i = 1; i < rowCount; i++)
                {
                    comparer.Add(worksheet.Cells[i, sourceComparer].Value.ToString());
                }
            }

            var unique = source;
            unique.UnionWith(comparer);
            var dublicate = source;
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
