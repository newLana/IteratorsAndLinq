using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndLinq
{
    //Task 2
    public class LinqAgregatorAndGrouper
    {
        //2.1
        public static int AggregateCount(IEnumerable<int> nums)
        {
            return nums.Aggregate(0, (acc, i) => ++acc);
        }

        public static int AggregateMax(IEnumerable<int> nums)
        {
            return nums.Aggregate(nums.FirstOrDefault(), (acc, n) => acc < n ? n : acc);
        }

        public static double AggregateAverage(IEnumerable<int> nums)
        {
            return nums.Aggregate(0.0, (acc, n) => acc += (double)n/nums.Count());
        }

        //2.2
        public static IEnumerable<KeyValuePair<string, int>> GetCountOfBooksByAuthor(IEnumerable<Book> books)
        {
            return books.GroupBy(b => b.Author).Select(g => new KeyValuePair<string, int>(g.Key, g.Count()));
        }

        //2.3.A
        public static IEnumerable<int> GetAllPairFromSequence(IEnumerable<int> nums)
        {
            return nums.SelectMany(s => nums, (f, s) => Int32.Parse(f.ToString() + s.ToString()));
        }

        //2.3.B
        public static IEnumerable<int> GetPairsWithDifferNums(IEnumerable<int> nums)
        {
            return nums.SelectMany(s => nums.Where(n => s != n), (f, s) => Int32.Parse(f.ToString() + s.ToString()));
        }

        //2.3.C
        public static IEnumerable<int> GetPairsNumsWithoutReverseDupl(IEnumerable<int> nums)
        {
            int counter = 0;
            IEnumerable<int> lst = nums.Distinct();
            return lst.SelectMany(s => lst.Skip(counter++), (f, s) => Int32.Parse(f.ToString() + s.ToString()));
        }
    }
}
