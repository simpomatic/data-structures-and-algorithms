using System;

namespace Simpomatic.InsertionSort
{
    class InsertionSort
    {
        /// <summary>
        /// Implementation of the Insertion sort algorithm.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        static void insertionSort(ref int[] arr)
        {
            // Iterate through the entire array
            for (int index = 0; index < arr.Length; index++)
            {
                if (index == 0)
                {
                    // Do nothing, first element is already sorted
                }
                else
                {
                    int reverseCounter = index - 1;
                    int currentIndex = index;
                    while (reverseCounter >= 0)
                    {
                        // Returns the index of the lowest value of the two
                        int minimumValueIndex = (arr[currentIndex] > arr[reverseCounter]) 
                            ? reverseCounter : currentIndex;
                        if (minimumValueIndex == currentIndex)
                        {
                            // Swap values
                            int temp = arr[currentIndex];
                            arr[currentIndex] = arr[reverseCounter];
                            arr[reverseCounter] = temp;

                            // Set new current index and reduce reverse iterator counter
                            currentIndex = reverseCounter--;
                        }
                        // No swap needed, avoid checking all previous entries as well
                        else
                        {
                            reverseCounter = -1;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Original array ");
            int[] arr = { 10, 7, 8, 11, 1, 10, 23, 7, 8, 5, 2, 2, 2, 2, 9, 1, 5 };
            int n = arr.Length;
            SharedFunctionality.printArray(arr, n);
            Console.WriteLine("Sorted array ");
            insertionSort(ref arr);
            SharedFunctionality.printArray(arr, n);
            Console.ReadKey();
        }
    }
}
