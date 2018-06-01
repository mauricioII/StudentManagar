using StudentManagar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagar
{
    class FilterBinding
    {
        public static Filter GetFilterFromArguments(string[] args)
        {
            Filter filter = new Filter();
            for (var i = 1; i < args.Length; i++)
            {
                var filterValues = args[i].Split('=');
                if (filterValues.Length != 2) throw new ArgumentException("Invalid format for the filter");
                if ("name".Equals(filterValues[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    filter.Name = filterValues[1];
                }
                if ("type".Equals(filterValues[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    filter.Type = (StudentType)Enum.Parse(typeof(StudentType), filterValues[1], true);
                }
                if ("gender".Equals(filterValues[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    filter.Gender = (Gender)Enum.Parse(typeof(Gender), filterValues[1], true);
                }
            }

            return filter;
        }
    }
}
