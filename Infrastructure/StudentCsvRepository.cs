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
    public class StudentCsvRepository : IStudentRepository
    {
        private string filePath;

        public StudentCsvRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Create(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> Search(Filter filter)
        {
            var lines = File.ReadAllLines(filePath);

            foreach(var line in lines)
            {
                var student = UnflattenStudent(line);
                if (Pass(student, filter)) yield return student;
            }
        }

        private string FlattenStudent(Student student)
        {
            return $"{student.Type},{student.Name},{student.Gender},{student.Date.ToString("yyyyMMddHHmmss")}";
        }

        private Student UnflattenStudent(string flattenStudent)
        {
            var studentInfo = flattenStudent.Split(',');
            return new Student
            {
                Type = (StudentType)Enum.Parse(typeof(StudentType), studentInfo[0]),
                Name = studentInfo[1],
                Gender = studentInfo[2] == "F" ? Gender.Femele : Gender.Male,
                Date = DateTime.ParseExact(studentInfo[3], "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
            };
        }

        private bool Pass(Student student, Filter filter)
        {
            bool passName = string.IsNullOrEmpty(filter.Name) || student.Name.Equals(filter.Name, StringComparison.InvariantCultureIgnoreCase);


            return passName && (filter.Type == null || student.Type == filter.Type) && (filter.Gender == null || student.Gender == filter.Gender);
        }
    }
}
