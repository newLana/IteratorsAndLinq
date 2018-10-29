using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data
            int[] nums = new int[] { 302, 313, 310, 210, 111, 123, 214, 150 };

            int[] nonDistNums = new int[] { 2, 3, 4, 3, 3, 1, 2 };

            int[] firstNums = new int[] { 1, 2, 3, 5, 6 };

            int[] secondNums = new int[] { 4, 5, 1 };

            string[] strngs = new string[] { "Этот", "Солнечный", "День" };

            string[,] dictionary = new string[,] { { "Hello", "Nice"},
                                                   { "Привет", "Хорошая"},
                                                   { "World","Weather"},
                                                   { "Мир", "Погода"} };
            IEnumerable<Book> books = new Book[]
            {
                new Book{Name = "Animal Farm", Author = "G. Orwell", Year = 1996},
                new Book{Name = "1984", Author = "G. Orwell", Year = 1995},
                new Book{Name = "LINQ pocket reference", Author = "J. Albahary", Year = 2000},
                new Book{Name = " Coming Up for Air", Author = "G. Orwell", Year = 2000},
                new Book{Name = "Moby-Dick", Author = "H. Mellville", Year = 2001},
                new Book{Name = "Pro LINQ", Author = "J. C. Rattz", Year = 2007},
                new Book{Name = "The Great Gatsby", Author = "F. Fitzgerald", Year = 1964},
                new Book{Name = "This Side of Paradise", Author = "F. Fitzgerald", Year = 1990},
                new Book{Name = "LINQ Unleashed for C#", Author = "P. Kimmel", Year = 2008}
            };


            //Task 0.1
            #region 
            Console.WriteLine("Reverse this array:");
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nResult");
            IEnumerator enumReverseInt = IntegerIterators.GetReverseArray(nums);
            while (enumReverseInt.MoveNext())
            {
                Console.Write(enumReverseInt.Current + " ");
            }

            Console.WriteLine("\n");
            #endregion

            //Task 0.2
            #region 
            Console.WriteLine("Reverse this array:");
            foreach (var item in strngs)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nResult");
            IEnumerator enumGetReverse = GenericIterators<string>.GetReverseArray(strngs);
            while (enumGetReverse.MoveNext())
            {
                Console.Write(enumGetReverse.Current + " ");
            }
            Console.WriteLine("\n");
            #endregion

            //Task 0.3
            #region
            Console.WriteLine("Get this array by columns:");
            foreach (var item in dictionary)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nResult");
            IEnumerator enumByCols = GenericIterators<string>.GetArrayByColumns(dictionary);
            while (enumByCols.MoveNext())
            {
                Console.Write(enumByCols.Current + "\t");
            }
            Console.WriteLine("\n");
            #endregion

            //Task 0.4
            #region
            Console.WriteLine("Get distinct array:");
            foreach (var item in nonDistNums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nResult");
            IEnumerator enumDist = IntegerIterators.GetDistinctArray(nonDistNums);
            while (enumDist.MoveNext())
            {
                Console.Write(enumDist.Current + " ");
            }

            Console.WriteLine("\n");
            #endregion

            //Task 0.5
            #region
            Console.WriteLine("Get first array except second array");
            Console.WriteLine("First Array");
            foreach (var item in firstNums)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nSecond Array");
            foreach (var item in secondNums)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nResult");
            IEnumerator enumGetExcept = IntegerIterators.GetExceptArray(firstNums, secondNums);
            while (enumGetExcept.MoveNext())
            {
                Console.Write(enumGetExcept.Current + " ");
            }
            Console.WriteLine("\n");
            #endregion

            //Task 1.1
            #region
            Console.WriteLine("Counting next Books published in Lofty Year and bookName contains LINQ");
            foreach (var item in books.OrderBy(b => b.Name))
            {
                Console.WriteLine($"  \"{item.Name}\" in {item.Year}");
            }
            Console.WriteLine("Result: ");
            foreach (var item in LinqFilterAndOrder.FilteringByLoftyYear(books))
            {
                Console.WriteLine($"  \"{item.Name}\" in {item.Year}");
            }            
            Console.WriteLine();
            #endregion

            //Task 1.2
            #region
            Console.WriteLine("Counting Distinct Letters in sequence of words");
            foreach (var item in strngs)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine("\nResult = " + LinqFilterAndOrder.CountingDistinctLetters(strngs));
            #endregion

            //Task 1.3
            #region
            Console.WriteLine();
            Console.WriteLine("Order this array by digit -> odd digit by asc, even digit by desc:");
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nResult ");
            IEnumerable<int> res = LinqFilterAndOrder.OrderingIntegers(nums);
            foreach (var item in res)
                Console.WriteLine(item + " ");
            Console.WriteLine();
            #endregion

            //Task 1.4
            #region
            Console.WriteLine("Get Count Of Books By Author");
            foreach (var item in books.OrderBy(b => b.Author))
            {
                Console.WriteLine($"  \"{item.Name}\" by {item.Author}");
            }
            Console.WriteLine("Result: ");
            foreach (var item in LinqFilterAndOrder.GetCountOfBooksByAuthor(books))
            {
                Console.WriteLine($"  \"{item.Key}\" in {item.Count()}");
            }
            #endregion

            //Task 2.3.A
            #region
            Console.WriteLine("Get All Pairs of Nums From Sequence");
            foreach (var item in secondNums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nResult:");
            var result = LinqAgregatorAndGrouper.GetAllPairFromSequence(secondNums);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            //Task 2.3.B
            #region
            Console.WriteLine("Get Pairs With Differ Nums");
            foreach (var item in nonDistNums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nResult:");
            
            foreach (var item in LinqAgregatorAndGrouper.GetPairsWithDifferNums(nonDistNums))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion            

            //Task 2.3.C
            #region
            Console.WriteLine("Get Pairs Without Reverse Duplicates");
            foreach (var item in secondNums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nResult:");

            foreach (var item in LinqAgregatorAndGrouper.GetPairsNumsWithoutReverseDupl(secondNums))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion  

            //Task 2.2
            #region
            Console.WriteLine("Get Count Of Books By Author");
            foreach (var item in books)
            {
                Console.WriteLine($"  \"{item.Name}\" by {item.Author}");
            }
            Console.WriteLine("Result: ");
            foreach (var item in LinqAgregatorAndGrouper.GetCountOfBooksByAuthor(books))
            {
                Console.WriteLine($"  \"{item.Key}\" in {item.Value}");
            }
            #endregion

            //Task 2.1
            Console.WriteLine("Aggregate Count");
            Console.WriteLine(LinqAgregatorAndGrouper.AggregateCount(nums));
                        
            Console.WriteLine("Aggregate Max");
            Console.WriteLine(LinqAgregatorAndGrouper.AggregateMax(nums));
                        
            Console.WriteLine("Aggregate Average");
            Console.WriteLine(LinqAgregatorAndGrouper.AggregateAverage(nums));

            Console.ReadKey();
        }
    }
}
