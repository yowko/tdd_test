using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_day2
{
    [TestClass]
    public class UnitTest_Cart
    {

        private static Rule<Book> rules;
        [ClassInitialize]
        public static void RuleInit(TestContext testcontext)
        {
            rules = new Rule<Book>()
            {
                Type = a => a.Id,
                Details = new Dictionary<int, double>()
                {
                    { 5,0.25},
                    { 4,0.20},
                    { 3,0.10},
                    { 2,0.05},
                }

            };

        }


        [TestMethod]
        public void Test_四本書_三本相同_第四本是重複的_結果應為370()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {

                };
            var expected = 370;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }
    }

    internal class Book
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    internal class Rule<T>
    {
        public Func<T, Guid> Type { get; set; }
        public Dictionary<int, double> Details { get; set; }

    }
}
