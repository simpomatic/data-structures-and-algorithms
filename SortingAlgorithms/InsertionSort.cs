namespace SortingAlgorithms
{
    public class InsertionSort : ISortingAlgorithm
    {
        /// <summary>
        /// Implementation of the Insertion sort algorithm.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        public int[] Sort(int[] arr)
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

            return arr;
        }
    }
}
