using System;

namespace SortingAlgorithms
{
    class QuickSort
    {
        #region Constants and fields
        private static readonly int _baseCaseSize = 3;
        #endregion

        /// <summary>
        /// Manually sorts an array. The following assumptions are made:
        /// - Array is at most the size of the base case 
        /// - Array size is greater than one
        /// </summary>
        /// <param name="arr">The array passed by reference</param>
        /// <param name="startingIndex">The starting index of the subarray</param>
        /// <param name="endingIndex">The ending index of the subarray</param>
        static void manualSort(ref int[] arr, int startingIndex, int endingIndex)
        {
            if (startingIndex < endingIndex)
            {
                int subArrayIndex = 0;
                int[] tempArray = new int[(endingIndex - startingIndex) + 1];

                // Get subarray of length L from arr at the starting index 
                // and fill the temporary array starting at index zero
                for (int index = startingIndex; index <= endingIndex; index++)
                {
                    tempArray[subArrayIndex] = arr[index];
                    subArrayIndex++;
                }

                // Sort array
                Array.Sort(tempArray);

                subArrayIndex = 0;
                for (int index = startingIndex; index <= endingIndex; index++)
                {
                    arr[index] = tempArray[subArrayIndex];
                    subArrayIndex++;
                }
            }
        }

        /// <summary>
        /// This method performs swaps around/with the partition index and updates the partition index
        /// as needed.
        /// </summary>
        /// <param name="arr">The array passed by reference</param>
        /// <param name="startingIndex">The starting index of the subarray</param>
        /// <param name="endingIndex">The ending index of the subarray</param>
        /// <param name="partitionIndex">A reference to the index of the partition</param>
        static void performSwapsAroundPartition(ref int[] arr, int startingIndex, int endingIndex, ref int partitionIndex)
        {
            // Automatically floors any decimal/double
            int middleIndex = (startingIndex + endingIndex) / 2;

            if (partitionIndex == startingIndex)
            {
                // Swap the beginning value with the middle value
                int temp = arr[middleIndex];
                arr[middleIndex] = arr[partitionIndex];
                arr[startingIndex] = temp;
            }
            else if (partitionIndex == middleIndex)
            {
                // Nothing needs to happen
            }
            else if (partitionIndex == endingIndex)
            {
                // Swap the ending value with the middle value
                int temp = arr[middleIndex];
                arr[middleIndex] = arr[endingIndex];
                arr[endingIndex] = temp;
            }

            bool isCorrect = false;
            while (!isCorrect)
            {
                // Default the value to partition index in case an offender is found on the right side
                int leftSwapIndex = partitionIndex;
                for (int i = 0; i < partitionIndex; i++)
                {
                    // A Value on the left side is greater than the value at the partition
                    if (arr[i] > arr[partitionIndex])
                    {
                        leftSwapIndex = i;
                        break;
                    }
                }

                // Default the value to partition index in case an offender is found on the left side
                int rightSwapIndex = partitionIndex;
                for (int i = partitionIndex + 1; i < arr.Length; i++)
                {
                    // A value on the right is less than or equal to the value at the partition
                    if (arr[i] <= arr[partitionIndex])
                    {
                        rightSwapIndex = i;
                        break;
                    }
                }

                // Either a swap was found on the right or left side or both
                if (leftSwapIndex != rightSwapIndex)
                {
                    // Update the partition index to match the new index if needed.
                    partitionIndex = (partitionIndex == leftSwapIndex) ? rightSwapIndex :
                        ((partitionIndex == rightSwapIndex) ? leftSwapIndex : partitionIndex);
                    int temp = arr[leftSwapIndex];
                    arr[leftSwapIndex] = arr[rightSwapIndex];
                    arr[rightSwapIndex] = temp;
                }
                // Since both indexes were never overwritten, we know each side must be correct
                else
                {
                    isCorrect = true;
                }
            }
        }

        /// <summary>
        /// Retrieves the partition index, index of the median value, of the current subarray.
        /// </summary>
        /// <param name="arr">The array passed by reference</param>
        /// <param name="startingIndex">The starting index of the subarray</param>
        /// <param name="endingIndex">The ending index of the subarray</param>
        /// <returns>The index of the median value</returns>
        static int getPartitionIndex(ref int[] arr, int startingIndex, int endingIndex)
        {
            int middleIndex = (startingIndex + endingIndex) / 2;
            // Supposedly one of the most efficient ways to get the median of three numbers.
            int partitionValue = Math.Max(Math.Min(arr[startingIndex], arr[middleIndex]), 
                Math.Min(Math.Max(arr[startingIndex], arr[middleIndex]), arr[endingIndex]));

            // Returns partition index based on the median value
            // NOTE: This makes the assumption that each index has a different value.
            int partitionIndex = (partitionValue == arr[startingIndex]) ? startingIndex :
                ((partitionValue == arr[middleIndex]) ? middleIndex : endingIndex);

            return partitionIndex;
        }

        /// <summary>
        /// Implementation of the quick sort algorithm. Utilizes a base case as well as uses the median
        /// of the first, middle, and last index values to get the partition point.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        /// <param name="startingIndex">The starting index of the subarray</param>
        /// <param name="endingIndex">The ending index of the subarray</param>
        static void quickSort(ref int[] arr, int startingIndex, int endingIndex)
        {
            // Ensures that the value of the starting index is lowering than that of the ending
            // index. Also, we are making sure the base case has not been met.
            if (startingIndex + (_baseCaseSize - 1) < endingIndex)
            {
                int partitionIndex = getPartitionIndex(ref arr, startingIndex, endingIndex);
                performSwapsAroundPartition(ref arr, startingIndex, endingIndex, ref partitionIndex);
                quickSort(ref arr, startingIndex, partitionIndex - 1);
                quickSort(ref arr, partitionIndex + 1, endingIndex);
            }
            // To ensure we do not waste time sorting a singular item
            else if (startingIndex < endingIndex)
            {
                // Manually sort
                manualSort(ref arr, startingIndex, endingIndex);
            }
        }
    }
}
