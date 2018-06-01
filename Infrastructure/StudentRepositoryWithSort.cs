using StudentManagar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Infrastructure
{
    class StudentRepositoryWithSort : IStudentRepository
    {
        private IStudentRepository repository;

        public StudentRepositoryWithSort(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Student student)
        {
            repository.Create(student);
        }

        public void Delete(Student student)
        {
            repository.Delete(student);
        }

        public IEnumerable<Student> Search(Filter filter)
        {
            var students = repository.Search(filter);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                return students.SortByName();
            }

            if (filter.Type != null || filter.Gender != null)
            {
                return students.SortByDate();
            }

            return students;
        }
    }
}
