using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPNCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, new RPNCalculator().Calculate("0 0 +"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(2, new RPNCalculator().Calculate("1 1 +"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1, new RPNCalculator().Calculate("1 1 *"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(5, new RPNCalculator().Calculate("10 5 -"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(4, new RPNCalculator().Calculate("8 2 /"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(3, new RPNCalculator().Calculate("1 1 1 + +"));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(3, new RPNCalculator().Calculate("1 1 + 1 +"));
        }


        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(14, new RPNCalculator().Calculate("5 1 2 + 4 * + 3 -"));
        }
    }

    public class RPNCalculator
    {
        string[] operators = new[] { "+", "-", "*", "/" };
        
        public int Calculate(string rpn)
        {
            string[] parts = rpn.Split(' ');
            var stack = new Stack<int>();
            foreach (string part in parts)
            {
                int digit;
                bool isDigit = int.TryParse(part, out digit);
                if (isDigit)
                {
                    stack.Push(digit);
                    continue;
                }

                bool isOperator = Array.IndexOf(operators, part) >= 0;

                if (isOperator)
                {
                    int digit2 = stack.Pop();
                    int digit1 = stack.Pop();
                    int value = InternalCalcul(digit1, digit2, part);
                    stack.Push(value);
                }
            }
            return stack.Pop();
        }

        private int InternalCalcul(int digit1, int digit2, string ope)
        {
            switch (ope)
            {
                case "+":
                    return (digit1) + (digit2);
                case "-":
                    return (digit1) - (digit2);
                case "*":
                    return (digit1) * (digit2);
                case "/":
                    return (digit1) / (digit2);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
