using StudentManagar.Domain;
using StudentManagar.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("There is no argument for the file path");
                Console.ReadKey();
                return;
            }


            string filePath = args[0];

            Filter filter = new Filter();
            try
            {
                filter = FilterBinding.GetFilterFromArguments(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"A problem with the filter mapping : {e.Message}");
                return;
            }


            IStudentRepository studentRepository = new StudentRepositoryWithSort(new StudentCsvRepository(filePath));
            var students = studentRepository.Search(filter);
            foreach (var student in students)
            {
                Console.WriteLine($"Name:{student.Name}, Type:{student.Type}, Gender:{student.Gender}, Date:{student.Date:f}");
            }

            Console.ReadKey();
        }
    }
}
