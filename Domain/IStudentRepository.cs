using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar.Domain
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Delete(Student student);
        IEnumerable<Student> Search(Filter filter);
    }
}
