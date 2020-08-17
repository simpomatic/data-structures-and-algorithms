using System;

namespace SortingAlgorithms
{
    public static class SharedFunctionality
    {
        /// <summary>
        /// Method to display the array to the console.
        /// </summary>
        /// <param name="arr">The given array</param>
        /// <param name="length">The length of the array</param>
        public static void PrintArray(this int[] arr, int length)
        {
            for (int i = 0; i < length; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        /// <summary>
        /// Returns the subarray of size <strong>length</strong> at the given <strong>offset</strong>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Given array</param>
        /// <param name="offset">Index in which to start from</param>
        /// <param name="length">Length of desired subarray</param>
        /// <returns>Subarray of size <strong>length</strong> at the given <strong>offset</strong></returns>
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }
}
