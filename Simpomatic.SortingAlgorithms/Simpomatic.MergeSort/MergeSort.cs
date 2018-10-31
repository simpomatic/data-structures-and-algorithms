using System;

namespace Simpomatic.MergeSort
{
    class MergeSort
    {
        /// <summary>
        /// Provides the functionality to merge two arrays together while sorting them during
        /// merging process.
        /// </summary>
        /// <param name="leftArray">An array to be merged</param>
        /// <param name="rightArray">Another array to be used for the merge</param>
        /// <returns></returns>
        static int[] mergeArrays(int[] leftArray, int[] rightArray)
        {
            // New temporary array to hold the combination of both left and right arrays
            int[] combinedArray = new int[leftArray.Length + rightArray.Length];

            // Indices of each array
            int leftArrayIndex = 0;
            int rightArrayIndex = 0;

            // Fill every index in the new combined array
            for (int i = 0; i < combinedArray.Length; i++)
            {
                int minimumValue;
                // Preventing out of bounds exceptions
                // NOTE: We use the fact the post-increment function returns the original
                //       value and then applies the incrementation
                if (leftArrayIndex == leftArray.Length)
                {
                    minimumValue = rightArray[rightArrayIndex++];
                }
                else if (rightArrayIndex == rightArray.Length)
                {
                    minimumValue = leftArray[leftArrayIndex++];
                }
                else
                {
                    // Compare the current index of the right array to the current index
                    // of the left array to determine which value will be inserted first
                    minimumValue = (leftArray[leftArrayIndex] > rightArray[rightArrayIndex]) ?
                        rightArray[rightArrayIndex++] : leftArray[leftArrayIndex++];
                }
                combinedArray[i] = minimumValue;
            }

            return combinedArray;
        }

        /// <summary>
        /// Recursive Merge sort algorithm.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        /// <param name="startingIndex">Starting index of the subarray</param>
        /// <param name="endingIndex">Ending index of the subarray</param>
        /// <returns></returns>
        static int[] mergeSort(int[] arr, int startingIndex, int endingIndex)
        {
            // Base case: Single item in each array
            if (startingIndex == endingIndex)
            {
                // All components are now split
                int[] single = { arr[startingIndex] };
                return single;
            }
            else
            {
                int middleIndex = (startingIndex + endingIndex) / 2;
                int[] leftArray = mergeSort(arr, startingIndex, middleIndex);
                int[] rightArray = mergeSort(arr, middleIndex + 1, endingIndex);

                // New temporary array to hold the combination of both left and right arrays
                int[] combinedArray = mergeArrays(leftArray, rightArray);

                return combinedArray;
            }
        }

        // Driver program
        static void Main(string[] args)
        {
            Console.WriteLine("Original array ");
            int[] arr = { 10, 7, 8, 11, 1, 10, 23, 7, 8, 5, 2, 2, 2, 2, 9, 1, 5 };
            int n = arr.Length;
            SharedFunctionality.printArray(arr, n);
            Console.WriteLine("Sorted array ");
            SharedFunctionality.printArray(mergeSort(arr, 0, n - 1), n);
            Console.ReadKey();
        }
    }
}
