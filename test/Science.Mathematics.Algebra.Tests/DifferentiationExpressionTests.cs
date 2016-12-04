﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Science.Mathematics.Algebra.Tests
{
    using static ExpressionFactory;

    [TestClass]
    public class DifferentiationExpressionTests
    {
        [TestMethod]
        public void Differentiation_Power_x2()
        {
            var x = Variable("x");
            var expression = x ^ 2;
            var result = expression.Differentiate(x).Simplify();

            Assert.AreEqual(2 * x, result);
        }

        [TestMethod]
        public void Differentiation_Power_ex()
        {
            var x = Variable("x");
            var expression = e ^ x;
            var result = expression.Differentiate(x).Simplify();

            Assert.AreEqual(expression, result);
        }

        [TestMethod]
        public void Differentiation_Log_b_x()
        {
            var x = Variable("x");
            var b = Variable("b");
            var expression = Logarithm(x, b);
            var result = expression.Differentiate(x).Simplify();

            Assert.AreEqual(Reciprocal(NaturalLogarithm(b) * x), result);
        }
    }
}
