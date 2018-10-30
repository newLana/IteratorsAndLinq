using System.Collections.Generic;
using System.Collections;

namespace IteratorsAndLinq
{
    //Task 0
    public class IntegerIterators
    {
        //0.1
        public static IEnumerator GetReverseArray(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                yield return nums[i];
            }
        }

        //0.4
        public static IEnumerator GetDistinctArray(int[] nums)
        {
            List<int> l = new List<int>(nums);

            for (int j = 0; j < l.Count; j++)
            {
                for (int i = j + 1; i < l.Count; i++)
                {
                    if (l[i] == l[j])
                    {
                        l.RemoveAt(i--);
                    }
                }
                yield return l[j];
            }
        }

        //0.5
        public static IEnumerator GetExceptArray(int[] firstArray, int[] secondArray)
        {
            for (int j = 0; j < firstArray.Length; j++)
            {
                bool isDuplicate = false;
                for (int i = 0; i < secondArray.Length; i++)
                {
                    if (firstArray[j] == secondArray[i])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                    yield return firstArray[j];
            }
        }
    }
}
