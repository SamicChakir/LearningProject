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

        [TestCase("CaseOneTwoSegments.txt", null, TestName = "No Intersection Example")]
        [TestCase("CaseTwoTwoSegments.txt", "(5,6)",TestName = "One Intersectio Example")]
        public void TestSegmentsIntersection(string fileName,string? expectedIntersection)
        {
            var segments = ObjectsFromFileHelper.GetSegmentsFromFile(path + "\\" + fileName);
            if ( !(expectedIntersection is null))
            {
                
                Assert.AreEqual(
                    expectedIntersection,
                    DataStructuresOperations.getIntersection(segments[0],segments[1]).ToString()
                    ) ;
            }
            else
            {
                Assert.AreEqual(
                    null,
                    DataStructuresOperations.getIntersection(
                        segments[0],
                        segments[1]
                        )
                    );
            }

        }

        [TestCase("SmallestDifference.txt", "(8, 11)", TestName = "Smallest Pair Difference")]
        public void TestSmallestDifference(string fileName,string expectedpair)
        {
            var arrays = ObjectsFromFileHelper.ReadArraysFromLines(path + "\\" + fileName);
            Assert.AreEqual(2, arrays.Length);
            Assert.AreEqual(expectedpair, DataStructuresOperations.SmallestDifference(arrays[0], arrays[1]).ToString());
        }
    }
}