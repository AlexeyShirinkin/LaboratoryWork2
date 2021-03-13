using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LaboratoryWork2
{
    internal class SortsTests
    {
        private static readonly Random Random = new Random();
        private List<string> orderedWordsCollection;
        private List<string> shuffledWordsCollection;

        [SetUp]
        public void SetUp()
        {
            var reader = new StreamReader("text.txt");
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
        }

        [Test]
        public void CorrectSorting_BubbleSort()
        {
            Sorts.BubbleSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_QuickSort()
        {
            Sorts.QuickSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_TreeSort()
        {
            shuffledWordsCollection = Sorts.TreeSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_InsertionSort()
        {
            Sorts.InsertionSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_MergeSort()
        {
            Sorts.MergeSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_HeapSort()
        {
            Sorts.HeapSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_RadixSort()
        {
            Sorts.RadixSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void CorrectSorting_RedBlackTreeSort()
        {
            shuffledWordsCollection = Sorts.RedBlackTreeSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        private List<string> ShuffleCollection(List<string> collection)
        {
            var result = collection.ToList();

            for (var i = 0; i < result.Count; ++i)
            {
                var next = Random.Next(0, result.Count);
                var temp = result[i];
                result[i] = result[next];
                result[next] = temp;
            }

            return result;
        }
    }
}
