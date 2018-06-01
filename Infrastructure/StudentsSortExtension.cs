using StudentManagar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Infrastructure
{
    public static class StudentsSortExtension
    {
        public static IEnumerable<Student> SortByName(this IEnumerable<Student> students)
        {
            return students.OrderBy(s => s.Name);
        }

        public static IEnumerable<Student> SortByDate(this IEnumerable<Student> students)
        {
            return students.OrderByDescending(s => s.Date);
        }

    }
}
