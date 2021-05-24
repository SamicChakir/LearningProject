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

        public static (int,int) SmallestDifference(IList<int> array1, IList<int> array2)
        {
            var dictionnaryOfPositionsArray1 = new Dictionary<int, bool>();
            foreach (var elem in array1)
            {
                dictionnaryOfPositionsArray1[elem] = true;
            }
            var dictionnaryOfPositionsArray2 = new Dictionary<int, bool>();
            foreach (var elem in array2)
            {
                if (dictionnaryOfPositionsArray1.ContainsKey(elem))
                {
                    return (elem, elem);
                }
                else
                {
                    dictionnaryOfPositionsArray2[elem] = false;
                }
            }

            var positions = dictionnaryOfPositionsArray1.Concat(dictionnaryOfPositionsArray2).ToDictionary(x => x.Key, x => x.Value); 
            var sortedArray = SortArray(array1.Concat(array2).ToList());
            var dictionaryOfPositions = new Dictionary<int, bool>();
            int first = 0;
            int second = int.MaxValue;

            for (int i = 0; i < sortedArray.Count-1; i++)
            {
                var cur = sortedArray[i];
                var suiv = sortedArray[i + 1];
                if (positions[cur] != positions[suiv] && Math.Max(suiv-cur,cur-suiv) <= second-first)
                {
                    first = Math.Min(cur, suiv);
                    second = Math.Max(cur, suiv);
                }
            }


            return (first,second);
        }

        public static int MultiplyIntegersUsingAddOperator(int a, int b)
        {
            var res = 0;
            var count = 0; 
            while ( count < b)
            {
                res += a;
                count++;
            }
            return res;
        }

        public static int DivideIntegersUsingAddOperator(int a,int b)
        {
            if (b == 0)
            {
                throw new ArgumentException($"Division by Zero Is not Possible");
            }
            if ( b <= 0)
            {
                return 0;
            }
            
            int res = 0;
            int multiplier = 0;
            while(res < a)
            {
                res += b;
                multiplier += 1;
            }
            return multiplier-1;
        }

        public static int SubstractIntegersUsingAddOperator(int a, int b)
        {
            return a + (~b + 1);
        }

        public static Dictionary<int, List<int>> GetPositions(int[] arr)
        {
            var res = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (res.ContainsKey(arr[i]))
                {
                    res[arr[i]].Add(i);
                }
                else
                {
                    res[arr[i]] = new List<int> { i };
                }
            }
            return res;
        }
        public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
        {
            Dictionary<int, List<int>> positions = GetPositions(arr);

            var cur_weight = 0;
            while(cur_weight <= limit / 2)
            {
                if (positions.ContainsKey(cur_weight))
                {
                    if (cur_weight == limit / 2)
                    {
                        var cur_indices = positions[cur_weight];
                        if (cur_indices.Count >= 2)
                        {
                            return new int[] { cur_indices.Last(), cur_indices[cur_indices.Count - 2] };
                        }
                    }
                    else
                    {
                        if (positions.ContainsKey(limit - cur_weight))
                        {
                            var firstindex = positions[cur_weight].Last();
                            var secondIndex = positions[limit - cur_weight].Last();
                            return new int[] { Math.Max(firstindex, secondIndex), Math.Min(firstindex, secondIndex) };
                        }
                    }
                }
                
                cur_weight++;
                
            }
        
            return new int[0];
        }


       
    }
}
