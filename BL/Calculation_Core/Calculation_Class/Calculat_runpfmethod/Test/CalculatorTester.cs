using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BL.Calculation_Core.Calculation_Class.Calculat_runpfmethod.Test
{
    [TestClass]
    public class CalculatorTester
    {




        [TestMethod]
        public void TestMethod1()
        {
            var calculator = new Calculator();

            Assert.AreEqual(4, calculator.Add(2, 2));

            if (calculator.Add(2, 2) == 4)
                Console.WriteLine("Success");
            else
                Console.WriteLine("Failure");
        }

    }
}
