using System.Collections.Generic;

namespace IteratorsAndLinq
{
    //Task 0
    public class GenericIterators<T>
    {
        //0.2
        public static IEnumerator<T> GetReverseArray(T[] innerArray)
        {
            for (int i = innerArray.Length - 1; i >= 0; i--)
            {
                yield return innerArray[i];
            }
        }

        //0.3
        public static IEnumerator<T> GetArrayByColumns(T[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    yield return array[j, i];
                }
            }
        }
    }
}
