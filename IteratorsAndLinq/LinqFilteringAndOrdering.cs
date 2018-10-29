using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndLinq
{
    //Task 1
    public static class LinqFilterAndOrder
    {
        //1.1
        public static IEnumerable<Book> FilteringByLoftyYear(IEnumerable<Book> books)
        {
            return books.Where(b => b.Name.ToUpper().Contains("LINQ") && (b.Year % 400 == 0 || (b.Year % 100 != 0 && b.Year % 4 == 0)));
        }

        //1.2
        public static int CountingDistinctLetters(IEnumerable<string> words)
        {
            return words.SelectMany(w => w.ToUpper().ToCharArray()).Distinct().Count();
        }

        //1.3*
        public static IEnumerable<int> OrderingIntegers(IEnumerable<int> nums)
        {
            if (nums.Max(n => n.ToString().Length) == nums.Max(n => n.ToString().Length))
            {
                int[] innerNums = nums.ToArray();

                int digit = nums.First().ToString().Length;
                for (int i = digit - 1; i >= 0; i--)
                {
                    if (i % 2 == 0)
                    {
                        innerNums = innerNums.OrderBy(n => n.ToString()[i]).ToArray();
                    }
                    else
                    {
                        innerNums = innerNums.OrderByDescending(n => n.ToString()[i]).ToArray();
                    }
                }
                return innerNums;
            }
            return Enumerable.Empty<int>();
        }

        //1.4
        public static IEnumerable<IGrouping<string, Book>> GetCountOfBooksByAuthor(IEnumerable<Book> books)
        {
            return books.GroupBy(b => b.Author);
        }
    }       
}

