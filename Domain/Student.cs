using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Domain
{
    public class Student
    {
        string Name { get; set; }
        Gender Gender { get; set; }
        StudentType Type { get; set; }
    }
}
