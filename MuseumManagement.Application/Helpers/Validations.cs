using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Helpers
{
    public static class Validations
    {
        public static bool ContainsDuplicates<T>(this IEnumerable<T> enumerable)
        {
            HashSet<T> KnownElements = [];
            foreach (T element in enumerable)
            {
                if (!KnownElements.Add(element))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
