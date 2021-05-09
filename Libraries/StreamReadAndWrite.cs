using System;
using System.IO;
using System.Collections.Generic;
namespace Libraries
{
    public class StreamReadAndWrite
    {
        public string path { get; private set; }

        public IList<int> FileNumbers { get; private set; }

        public bool isSorted { get; private set; }

        public StreamReadAndWrite()
        {
            path = Directory.GetCurrentDirectory();
        }

        public void PrintPath()
        {
            Console.WriteLine("This is the Current Path :");
            Console.WriteLine(path);
        }

        public void ReadTextFileAndStore(string pathTofile)
        {
            var arrayOfIntegers = new List<int>();
            
            using (StreamReader reader = File.OpenText(pathTofile))
            {
                string s = "";
                while( (s = reader.ReadLine()) != null)
                {
                    arrayOfIntegers.Add((int) Int32.Parse(s));
                }

            }
            FileNumbers = arrayOfIntegers;
        }

        public IList<int> SortNumbers()
        {
            if (!isSorted)
            {
                FileNumbers = DataStructuresOperations.SortArray(FileNumbers);

            }

            return FileNumbers;
        }

        

    }
}
