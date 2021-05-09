using System;
using Libraries;
using System.IO;

namespace TestsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReadAndWrite();


            var pathTofile = reader.path + "\\TestFiles\\PeakAndValley.txt";
            /*
            reader.ReadTextFileAndStore(pathTofile);

            var array = reader.SortNumbers();

            array.PeakAndValleys();

            array.PrintElements();
            */
            Console.WriteLine(MathAlgorithms.TrailingZeros(2016));

        }
    }
}
