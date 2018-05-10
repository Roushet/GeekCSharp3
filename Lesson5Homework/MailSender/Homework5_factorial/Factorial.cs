using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework5_factorial
{
    public static class Factorial
    {
        public static int Calculate(int num)
        {
            int result = 1;

            for (int i = 1; i <= num; i++)
                result *= i;

            return result;
        }

        public static int CalculateInThreads(int num)
        {
            int result;
            int[] nums = new int[num];

            for (int i = 0; i == num; i++)
                nums[i] = i;


            //var res = new Thread(Multiply())
            
            return 0;
        }

        private static int Multiply(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int result = 1;

            for (int i = 0; i <= nums.Length; i++)
                result *= nums[i];

            return result;
        }

    }
}
