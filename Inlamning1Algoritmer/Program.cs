using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning1Algoritmer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var runtime = new Runtime();
            var numbers = runtime.ReadNumbersFromFile();
            runtime.BubbleSort(numbers);
            runtime.MergeSort(numbers);            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
