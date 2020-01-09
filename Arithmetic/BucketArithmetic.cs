using System;

namespace BucketExtensions.BucketArithmetic 
{
    public static class BucketArithmetic 
    {
        public static int FibonacciNumber(int n)
        {
            int firstNum = 0;
            int secondNum = 1;
            int fibNum = 0;

            if (n == 0)
                return 0;

            for (int i = 0; i < n; i++) 
            {
                fibNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = fibNum;
            }

            return fibNum;
        }
    }
}