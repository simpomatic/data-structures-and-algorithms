using System;

namespace SortingAlgorithms
{
    public class MergeSort : ISortingAlgorithm
    {
        /// <summary>
        /// Provides the functionality to merge two arrays together while sorting them during
        /// merging process.
        /// </summary>
        /// <param name="leftArray">An array to be merged</param>
        /// <param name="rightArray">Another array to be used for the merge</param>
        /// <returns></returns>
        private static int[] MergeArrays(int[] leftArray, int[] rightArray)
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

        public int[] Sort(int[] arr)
        {
            // Base case: Single item in each array
            if (arr.Length == 1)
            {
                return arr;
            }
            else
            {
                int middleIndex = arr.Length / 2;
                int[] leftArray = Sort(arr.SubArray(0, middleIndex));
                int[] rightArray = Sort(arr.SubArray(middleIndex, (arr.Length - middleIndex)));

                // New temporary array to hold the combination of both left and right arrays
                int[] combinedArray = MergeArrays(leftArray, rightArray);

                return combinedArray;
            }
        }
    }
}
