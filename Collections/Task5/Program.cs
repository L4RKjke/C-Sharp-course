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
            string[] array1 = { "6", "7", "12", "1", "2" };
            string[] array2 = { "6", "7", "1", "65", "3", "5" };
            MergeArrays(array1, array2, out List<string> list);
        }

        static void MergeArrays(string[] array1, string[] array2, out List<string> list)
        {
            list = new List<string>();

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                AddUniqueElement(list, array1, i);
                AddUniqueElement(list, array2, i);
            }
        }

        static void AddUniqueElement (List<string>  list, string[] array, int index)
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