using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inlamning1Algoritmer
{
    class Runtime
    {
        public int[] ReadNumbersFromFile()
        {
            var filePath = Environment.CurrentDirectory + "\\data.txt";
            var lines = File.ReadAllLines(filePath);
            var data = lines[0].Split('\t');
            return Array.ConvertAll(data, int.Parse);
        }

        #region MergeSort
        //Added this function just to be able to print the results out 
        //without repeating it many times as it will be recalled internally
        public void MergeSort(int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MergeSort(numbers, 0, numbers.Length - 1);

            watch.Stop();
            var mergeSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Merge", mergeSortExeecutionTime);
        }
        void MergeSort(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, (mid + 1), right);
                MainMerge(numbers, left, (mid + 1), right);
            }

        }

        private void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Length];

            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];

                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= eol)
            {
                temp[pos++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[pos++] = numbers[mid++];
            }

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }     
        }
        #endregion

        #region BubbleSort
        public void BubbleSort(int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < numbers.Length; i++)
            {               
                for (int j = numbers.Length -1; j  > 0; j--)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = temp;
                    }
                }
            }
            watch.Stop();
            var bubbleSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Bubble", bubbleSortExeecutionTime);
        }
        #endregion

        public void Print(int[] numbers, string type, Int64 excutionTime)
        {
            if (type == "Bubble")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Bubble sorted:   (Execution time: {0} ms)", excutionTime);

            }
            else if (type == "Merge")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Merge sorted:   (Execution time: {0} ms)", excutionTime);
            }
            foreach(var number in numbers)
            {
                Console.WriteLine("  " + number);
            }
        }
    }
}
