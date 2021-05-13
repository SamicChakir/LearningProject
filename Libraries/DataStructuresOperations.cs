using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Libraries
{
    public static class DataStructuresOperations
    {

        public static IList<int> SortArray(IList<int> array)
        {
            var helper = new List<int>();
            for (int i = 0; i < array.Count(); i++)
            {
                helper.Add(array[i]);
            }

            SortRecursiveArray(array, helper, 0, array.Count - 1);

            return array;
        }

        public static void SortRecursiveArray(IList<int> array, IList<int> helper, int low, int high)
        {
            if (low < high)
            {
                var middle = (int)(high + low) / 2;
                SortRecursiveArray(array, helper, middle + 1, high);
                SortRecursiveArray(array, helper, low, middle);
                SortRecursiveArray(array, helper, middle + 1, high);
                Merge(array, helper, low, high);

            }


        }

        public static void Merge(IList<int> array, IList<int> helper, int low, int high)
        {
            for (int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }
            var helper_left = low;
            var middle = (int)(low + high) / 2;
            var helper_right = middle + 1;
            var current = low;
            while (helper_left <= middle && helper_right <= high)
            {
                if (helper[helper_left] > helper[helper_right])
                {
                    array[current] = helper[helper_right];
                    helper_right++;
                }
                else
                {
                    array[current] = helper[helper_left];
                    helper_left++;
                }
                current++;
            }
            while (helper_left <= middle)
            {
                array[current] = helper[helper_left];
                helper_left++;
                current++;
            }
        }

        public static void PrintElements(this IList<int> array)
        {
            foreach (var elem in array)
            {
                Console.WriteLine(elem);
            }
        }

        public static string StringRepresentation(this IList<int> array)
        {
            var s = "";
            foreach (var elem in array)
            {
                s += elem.ToString() + "\n";
            }

            return s.Substring(0, s.Count() - 1);
        }

        public static IList<int> PeakAndValleys(this IList<int> array)
        {
            var temp = 0;
            for (int i = 1; i <= array.Count - 2; i = i + 2)
            {
                temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
            }
            return array;
        }

        public static IList<int> SwapInPlace(this IList<int> array, int indexA, int indexB)
        {
            (array[indexA], array[indexB]) = (array[indexB], array[indexA]);
            return array;
        }


        public static IList<int> SortNumbers(this IList<int> arrayOfNumbers)
        {
            return DataStructuresOperations.SortArray(arrayOfNumbers);
        }

        public static Point getIntersection(Segment seg1, Segment seg2)
        {
            if (seg1.Slope != seg2.Slope)
            {
                var abscissa = (seg1.Interecept - seg2.Interecept) / (seg2.Slope - seg1.Slope);
                abscissa = Math.Round(abscissa,5);
                var p = seg1.GetImageWithFunction(abscissa);
                if (seg1.IsBetweenEdges(p) && seg2.IsBetweenEdges(p))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
