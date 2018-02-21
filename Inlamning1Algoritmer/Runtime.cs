using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
       public int[] BubbleSort(int[] numbers)
        {
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
            return numbers;
        }

        public void Print(int[] numbers)
        {
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
