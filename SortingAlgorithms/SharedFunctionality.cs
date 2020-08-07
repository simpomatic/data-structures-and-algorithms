using System;

namespace SortingAlgorithms
{
    public class SharedFunctionality
    {
        /// <summary>
        /// Method to display the array to the console.
        /// </summary>
        /// <param name="arr">The given array</param>
        /// <param name="n">The length of the array</param>
        public static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
    }
}
