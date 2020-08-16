namespace SortingAlgorithms
{
    public class SelectionSort : ISortingAlgorithm
    {
        /// <summary>
        /// Implemenation of the Selection sort algorithm.
        /// </summary>
        /// <param name="arr">Unsorted array</param>
        public int[] Sort(int[] arr)
        {
            // Iterate through each index in the array
            for(int currentIndex = 0; currentIndex < arr.Length; currentIndex++)
            {
                int currentMinimumIndex = currentIndex;
                // Scan the entire array sequentially to find the minimum value
                for (int j = currentIndex + 1; j < arr.Length; j++)
                {
                    if (arr[currentMinimumIndex] > arr[j])
                    {
                        currentMinimumIndex = j;
                    }
                }

                // Swap the value at the current index with the minimum value at the given index
                int temp = arr[currentIndex];
                arr[currentIndex] = arr[currentMinimumIndex];
                arr[currentMinimumIndex] = temp;
            }

            return arr;
        }
    }
}
