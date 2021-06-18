// Solution to the challenge at https://app.codility.com/programmers/lessons/5-prefix_sums/min_avg_two_slice/

namespace CodilityChallenges
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static int solution(int[] A)
        {
            List<double> averagesList = new List<double>();
            List<int> openingIndexList = new List<int>();

            for (int openingIndex = 0; openingIndex < A.Length - 1; openingIndex++)
            {
                for (int closingIndex = 0; closingIndex < A.Length; closingIndex++)
                {
                    if(closingIndex <= openingIndex)
                    {
                        continue;
                    }
                    double av = GetAverage(A, openingIndex, closingIndex);
                    averagesList.Add(av);
                    openingIndexList.Add(openingIndex);
                }
            }
            return GetLowest(averagesList, openingIndexList);
        }

        private static int GetLowest(List<double> averagesList, List<int> openingIndexList)
        {
            List<int> lowestOpeningValsList = new List<int>();
            // Find minimum slice figure
            double min = averagesList[0];
            for (int index = 0; index < averagesList.Count; index++)
            {
                if(averagesList[index] < min)
                {
                    min = averagesList[index];
                }
            }
            // Get opening values corresponding to minimum slice figure.
            for (int index = 0; index < averagesList.Count; index++)
            {
                if(averagesList[index] == min)
                {
                    lowestOpeningValsList.Add(openingIndexList[index]);
                }
            }
            lowestOpeningValsList.Sort();
            return lowestOpeningValsList[0];
        }

        private static double GetAverage(int[] numberArray, int openingIndex, int closingIndex)
        {
            double tot = 0;
            for(int index = openingIndex; index < (closingIndex + 1); index++)
            {
                tot += numberArray[index];
            }
            return tot / ((closingIndex - openingIndex) + 1);
        }

        public static void Main(string[] args)
        {
            int[] A = { 4, 2, 2, 5, 1, 5, 8}; // Expected value 1
            Console.WriteLine(solution(A));
        }
    }
}
