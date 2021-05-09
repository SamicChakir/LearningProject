using System;
using System.IO;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace Libraries
{
    public static class ObjectsFromFileHelper
    {

        public static new List<int> ReadTextFileAndStore(string pathTofile)
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
            return arrayOfIntegers;
        }

        public static Dictionary<string, int> getWordsOccurences(string pathToFile)
        {
            var Occurences = new Dictionary<string, int>();
            using (var mappedFile1 = MemoryMappedFile.CreateFromFile(pathToFile))
            {
                using (Stream mmStream = mappedFile1.CreateViewStream())
                {
                    using (StreamReader sr = new StreamReader(mmStream, ASCIIEncoding.ASCII))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            var lineWords = line.Split(' ');
                            foreach( var elem in lineWords)
                            {
                                if (Occurences.ContainsKey(elem))
                                {
                                    Occurences[elem] += 1;
                                }
                                else
                                {
                                    Occurences[elem] = 1;
                                }
                            }
                        }
                    }
                }
            }

            return Occurences;
        }

        

    }
}
