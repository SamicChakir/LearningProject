using System;
using System.IO;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace Libraries
{
    public static class ObjectsFromFileHelper
    {

        public static List<int> ReadTextFileAndStore(string pathTofile)
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

        public static List<Segment> GetSegmentsFromFile(string pathToFile)
        {
            var arrayofSegments = new List<Segment>();

            using (StreamReader reader = File.OpenText(pathToFile))
            {
                string s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    var splitedCoordinates = s.Split(' ');
                    if ( splitedCoordinates.Length != 4)
                    {
                        throw new ArgumentException($"Each Line should represent one segment with exactly two points coordinates, However found  { splitedCoordinates.Length } numbers instead of 4");
                    }
                    arrayofSegments.Add(
                        new Segment(
                            new Point(double.Parse(splitedCoordinates[0]), double.Parse(splitedCoordinates[1])),
                            new Point(double.Parse(splitedCoordinates[2]), double.Parse(splitedCoordinates[3]))
                            )
                        );
                }

            }
            if (arrayofSegments.Count != 2)
            {
                throw new ArgumentException($"Only the intersection of two segments is calculated, however the number of segments in the file was  {arrayofSegments.Count } numbers instead of 2");
            }
            return arrayofSegments;
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
