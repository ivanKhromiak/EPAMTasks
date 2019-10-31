using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelOperations
{
    interface IExcelReader
    {
        ICollection<string> GetUnique();
    }
}
