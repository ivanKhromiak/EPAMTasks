using OfficeOpenXml;
using OneDriveManipulation;
using System.IO;

namespace ExcelOperations
{
    class ExcelFactory
    {
        public static ExcelPackage CreateExcel(string path)
        {
            if (path == "OneDrive")
            {
                return new ExcelPackage(OneDriveOperations.GetFile());
            }

            else
            {
                var file = new FileInfo(path);
                return new ExcelPackage(file);
            }
        }
    }
}
