using System;
using System.Collections.Generic;
using System.Text;

namespace TasksEnums
{
    public static class ExtensionColors
    {
        public static void GetSortedColors(this Colors colors)
        {
            var values = Enum.GetValues(typeof(Colors));
            Array.Sort(values);
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
