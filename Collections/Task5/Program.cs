using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 3, 2, 1, 12};
            int[] array2 = { 3, 1, 6, 6, 8, 4 };
            MergeArrays(array1, array2, out List<int> list);
        }

        static void MergeArrays(int [] array1, int[] array2, out List<int> list)
        {
            list = new List<int>();

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                AddUniqueElement(list, array1, i);
                AddUniqueElement(list, array2, i);
            }
        }

        static void AddUniqueElement (List<int>  list, int [] array, int index)
        {
            if (index < array.Length)
            {
                if (list.Contains(array[index]) == false)
                {
                    list.Add(array[index]);
                }
            }
        }
    }
}