using StudentManagar.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar
{
    class HandleStudentsCsvFile
    {
        private string filePath;

        public HandleStudentsCsvFile(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<Student> GetAllStudentsFromFile()
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Select(l => UnflattenStudent(l));
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
    }
}
