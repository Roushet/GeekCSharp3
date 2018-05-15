using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework5_factorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5_factorial.Tests
{
    [TestClass()]
    public class FactorialTests
    {
        [TestMethod(), Description("Тестирование метода получения факториала с 0")]
        public void CalculateTest_zero()
        {
            int input = 0;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, Factorial.Calculate(input));
        }

        [TestMethod(), Description("Тестирование метода получения факториала с числом")]
        public void CalculateTest()
        {
            int input = 6;
            int expectedResult = 720;

            Assert.AreEqual(expectedResult, Factorial.Calculate(input));
        }
    }
}