using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Domain
{
    public class Student
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public StudentType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
