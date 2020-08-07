using System;

namespace SortingAlgorithms
{
    class SelectionSort
    {
        /// <summary>
        /// Implemenation of the Selection sort algorithm.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        static void selectionSort(ref int[] arr)
        {
            // Iterate through each index in the array
            for(int i = 0; i < arr.Length; i++)
            {
                int currentMinimumIndex = 0;
                // Scan the entire array sequentially to find the minimum value
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[currentMinimumIndex] > arr[j])
                    {
                        currentMinimumIndex = j;
                    }
                }

                // Swap the value at the current index with the minimum value at the given index
                int temp = arr[i];
                arr[i] = arr[currentMinimumIndex];
                arr[currentMinimumIndex] = temp;
            }
        }
    }
}
