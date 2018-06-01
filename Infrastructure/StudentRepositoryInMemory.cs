using StudentManagar.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Infrastructure
{
    public class StudentRepositoryInMemory : IStudentRepository
    {

        private List<Student> students = new List<Student>();

        public StudentRepositoryInMemory()
        {
        }

        public void Create(Student student)
        {
            students.Add(student);
        }

        public void Delete(Student student)
        {
            students.Remove(student);
        }

        public IEnumerable<Student> Search(Filter filter)
        {
            return students.Where(student => Pass(student, filter));
        }

        private bool Pass(Student student, Filter filter)
        {
            bool passName = string.IsNullOrEmpty(filter.Name) || student.Name.Equals(filter.Name, StringComparison.InvariantCultureIgnoreCase);


            return passName && (filter.Type == null || student.Type == filter.Type) && (filter.Gender == null || student.Gender == filter.Gender);
        }
    }
}
