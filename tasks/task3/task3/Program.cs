using System;

namespace ConsoleApplication {
    class Program {
        private static void insertionSort(int[] array) {
            for (int i = 1; i < array.Length; ++i) {
                for (int j = i; j > 0; --j) {
                    if (array[j] < array[j-1]) {
                        array[j] += array[j-1];
                        array[j-1] = array[j] - array[j-1];
                        array[j] -= array[j-1];
                    } else {
                        break;
                    }
                }
            }
        }

        private static void outputArray(int[] array) {
            for (int i = 0; i < array.Length; ++i) {
                Console.Write(array[i] + " ");
            }
        }
    
        static void Main(string[] args) {
            var array = new[]{-10, 1, 2, -1, 4, 8, 5, 6, 7, 0};
            Console.WriteLine(array.Length);
            insertionSort(array);
            outputArray(array);
        }
    }
}
