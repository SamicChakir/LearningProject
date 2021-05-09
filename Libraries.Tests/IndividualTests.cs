using NUnit.Framework;
using System.IO;
using System;
using System.Collections.Generic;

namespace Libraries.Tests
{
    public class IndividualTests
    {
        public static string path = Directory.GetCurrentDirectory() + "\\TestCases";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTrailingZerosFunction()
        {
            Assert.AreEqual(MathAlgorithms.TrailingZeros(2016), 502);
        }

        [Test]
        public void TestCurrentPath()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        [Test]
        public void TestStringRepresentation()
        {
            var array = new List<int>() { 1, 2, 3 };

            Assert.AreEqual("1\n2\n3",array.StringRepresentation());

        }

        [TestCase("PeakAndValley.txt",TestName = "ReadFileOfNumbers_peakAndValley")]
        public void CanReadFile(string fileName)
        {
            var reader = new StreamReadAndWrite();

            reader.ReadTextFileAndStore(path + "\\" + fileName);

            Assert.AreEqual(reader.FileNumbers.StringRepresentation(), "5\n3\n1\n2\n3");


        }

  
       
        [TestCase("PeakAndValley.txt", TestName = "MergeSortIntNumbers_peakAndValley")]
        public void MergeSortArrayOfInt(string fileName)
        {
            var reader = new StreamReadAndWrite();

            reader.ReadTextFileAndStore(path + "\\" + fileName);

            reader.SortNumbers();

            Assert.AreEqual(reader.FileNumbers.StringRepresentation(), "1\n2\n3\n3\n5");
        }

        [TestCase("PeakAndValley.txt", TestName = "SwapInPlace_PeakAndValley")]
        public void TestSwapInPlace(string fileName)
        {
            var reader = new StreamReadAndWrite();

            reader.ReadTextFileAndStore(path + "\\" + fileName);

            Assert.AreEqual("3\n3\n1\n2\n5", reader.FileNumbers.SwapInPlace(0, 4).StringRepresentation());
        }
    }
}