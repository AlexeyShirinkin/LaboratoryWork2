using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork2
{
    public static class Sorts
    {
        public static void BubbleSort(List<string> collection)
        {
            for (var i = 0; i < collection.Count; ++i)
            for (var j = 0; j < collection.Count - 1 - i; ++j)
                if (string.CompareOrdinal(collection[j], collection[j + 1]) > 0)
                {
                    var temp = collection[j];
                    collection[j] = collection[j + 1];
                    collection[j + 1] = temp;
                }
        }

        public static void QuickSort(List<string> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private static void QuickSort(List<string> collection, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = collection[(left + right) / 2];

            while (i <= j)
            {
                while (string.CompareOrdinal(collection[i], pivot) < 0)
                    i++;
                while (string.CompareOrdinal(collection[j], pivot) > 0)
                    j--;

                if (i > j)
                    continue;

                var temp = collection[i];
                collection[i] = collection[j];
                collection[j] = temp;
                i++;
                j--;
            }

            if (left < j)
                QuickSort(collection, left, j);
            if (i < right)
                QuickSort(collection, i, right);
        }

        public static List<string> TreeSort(List<string> collection)
        {
            var treeNode = new TreeNode(collection[0]);
            for (var i = 1; i < collection.Count; i++)
                treeNode.Add(new TreeNode(collection[i]));

            return treeNode.Transform().ToList();
        }

        public static void InsertionSort(List<string> collection)
        {
            for (var i = 1; i < collection.Count; i++)
            for (var j = i; j > 0 && string.CompareOrdinal(collection[j - 1], collection[j]) > 0; --j)
            {
                var temp = collection[j];
                collection[j] = collection[j - 1];
                collection[j - 1] = temp;
            }
        }

        public static void MergeSort(List<string> collection)
        {
            MergeSort(collection, 0, collection.Count - 1);
        }

        private static void MergeSort(List<string> collection, int lowIndex, int highIndex)
        {
            if (lowIndex >= highIndex)
                return;

            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(collection, lowIndex, middleIndex);
            MergeSort(collection, middleIndex + 1, highIndex);
            Merge(collection, lowIndex, middleIndex, highIndex);
        }

        private static void Merge(List<string> collection, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new string[highIndex - lowIndex + 1];
            var index = 0;

            while (left <= middleIndex && right <= highIndex)
            {
                tempArray[index++] = string.CompareOrdinal(collection[left], collection[right]) < 0
                    ? collection[left++]
                    : collection[right++];
            }

            for (var i = left; i <= middleIndex; i++)
                tempArray[index++] = collection[i];

            for (var i = right; i <= highIndex; i++)
                tempArray[index++] = collection[i];

            for (var i = 0; i < tempArray.Length; i++)
                collection[lowIndex + i] = tempArray[i];
        }

        public static void HeapSort(List<string> collection)
        {
            var size = collection.Count;

            for (var i = size / 2 - 1; i >= 0; i--)
                Heapify(collection, size, i);

            for (var i = size - 1; i >= 0; i--)
            {
                var temp = collection[0];
                collection[0] = collection[i];
                collection[i] = temp;

                Heapify(collection, i, 0);
            }
        }

        private static void Heapify(List<string> collection, int size, int index)
        {
            var largest = index;
            var left = 2 * index + 1;
            var right = 2 * index + 2;

            if (left < size && string.CompareOrdinal(collection[left], collection[largest]) > 0)
                largest = left;

            if (right < size && string.CompareOrdinal(collection[right], collection[largest]) > 0)
                largest = right;

            if (largest == index)
                return;

            var swap = collection[index];
            collection[index] = collection[largest];
            collection[largest] = swap;

            Heapify(collection, size, largest);
        }

        public static void RadixSort(List<string> array)
            => RadixSort(array, 0, array.Count - 1, 0, new string[array.Count]);

        private static void RadixSort(List<string> array, int left, int right, int d, string[] temp)
        {
            if (left >= right)
                return;

            var k = 256;

            var count = new int[k + 2];
            for (var i = left; i <= right; i++)
            {
                var j = Key(array[i]);
                count[j + 2]++;
            }

            for (var i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            for (var i = left; i <= right; i++)
            {
                var j = Key(array[i]);
                temp[count[j + 1]++] = array[i];
            }

            for (var i = left; i <= right; i++)
                array[i] = temp[i - left];

            for (var i = 0; i < k; i++)
                RadixSort(array, left + count[i], left + count[i + 1] - 1, d + 1, temp);

            int Key(string s) => d >= s.Length ? -1 : s[d];
        }

        public static List<string> RedBlackTreeSort(List<string> collection)
        {
            var tree = new RedBlackTree<string>();
            foreach (var item in collection)
                tree.Insert(item);

            return tree.AsEnumerable().ToList();
        }
    }
}