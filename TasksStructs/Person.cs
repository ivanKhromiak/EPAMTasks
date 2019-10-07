using System;
using System.Collections.Generic;
using System.Text;

namespace TasksStructs
{
    struct Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string CompareAge(int comparativeAge)
        {
            if(comparativeAge < Age)
            {
                return $"{Name} {Surname} older than {comparativeAge}";
            }
            else
            {
                return $"{Name} {Surname} younger than {comparativeAge}";
            }
        }
    }
}
