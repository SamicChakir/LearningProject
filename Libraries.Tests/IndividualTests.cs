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

        [TestCase(2016,502,TestName = "Test TrailingZero Function for 2016!")]
        public void TestTrailingZerosFunction(int n ,int expectedValue)
        {
            Assert.AreEqual(expectedValue,MathAlgorithms.TrailingZeros(n));
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


        [TestCase("PeakAndValley.txt", "5\n3\n1\n2\n3",TestName = "ReadFileOfNumbers_peakAndValley")]
        public void CanReadFile(string fileName,string expectedValue)
        {

            Assert.AreEqual(expectedValue, ObjectsFromFileHelper.ReadTextFileAndStore(path + "\\" + fileName).StringRepresentation());

        }

  
       
        [TestCase("PeakAndValley.txt", "1\n2\n3\n3\n5", TestName = "MergeSortIntNumbers_peakAndValley")]
        public void MergeSortArrayOfInt(string fileName, string expectedValue)
        {
            Assert.AreEqual(expectedValue,ObjectsFromFileHelper.ReadTextFileAndStore(path + "\\" + fileName).SortNumbers().StringRepresentation());
        }


        [TestCase("PeakAndValley.txt",0,4, "3\n3\n1\n2\n5", TestName = "SwapInPlace_PeakAndValley")]
        public void TestSwapInPlace(string fileName,int indexA, int indexB,string expectedValue)
        {

            Assert.AreEqual(expectedValue, ObjectsFromFileHelper.ReadTextFileAndStore(path + "\\" + fileName).SwapInPlace(indexA, indexB).StringRepresentation());
        }

        [TestCase("HistoryArticle.txt","history",4,TestName = "Get Occurences of Word in Article_history")]
        [TestCase("HistoryArticle.txt", "this", 0, TestName = "Get Occurences of Word in Article_this")]
        public void TestGetWordOccurences(string fileName,string word,int expectedValue)
        {

            var dictionary = ObjectsFromFileHelper.getWordsOccurences(path + "\\" + fileName);

            int value;

            dictionary.TryGetValue(word, out value);

            Assert.AreEqual(expectedValue, value);
        }
    }
}