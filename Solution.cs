// Solution to the challenge at https://app.codility.com/programmers/lessons/5-prefix_sums/min_avg_two_slice/
namespace CodilityChallenges
{
    using System;

    class Solution
    {
        public static int solution(int[] A)
        {
            double avOfSlice = 100001;
            int indexOfSlice = 0;
            for (int openingIndex = 0; openingIndex < A.Length; openingIndex++)
            {
                double runningtot = A[openingIndex];
                int count = 1;
                for (int closingIndex = openingIndex + 1; closingIndex < A.Length; closingIndex++)
                {
                    runningtot += A[closingIndex];
                    double tempAv = runningtot / ++count;
                    if (tempAv == avOfSlice)
                    {
                        indexOfSlice = openingIndex > indexOfSlice ? indexOfSlice : openingIndex;
                    }
                    if (tempAv < avOfSlice)
                    {
                        avOfSlice = tempAv;
                        indexOfSlice = openingIndex;
                    }
                }
            }
            return indexOfSlice;
        }


        public static void Main(string[] args)
        {
            int[] A = { 4, 2, 2, 5, 1, 5, 8 }; // Expected value 1
            Console.WriteLine(solution(A));
            int[] B = { -3, -5, -8, -4, -10 }; // Expected value 2.
            Console.WriteLine(solution(B));
        }
    }
}
