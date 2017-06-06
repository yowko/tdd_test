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
        public void Test_四本書_三本不同_第四本是重複的_結果應為370()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100}
                };
            var expected = 370;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_五本書_三本不同_第四本與第五本是重複的_結果應為460()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100}
                };
            var expected = 460;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_五本書_五本皆不同_結果應為375()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 4,Name = "HarryPotter 4",Price = 100},
                    new Book(){Id = 5,Name = "HarryPotter 5",Price = 100}
                };
            var expected = 375;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }
    }

    internal struct Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    internal class Rule<T>
    {
        public Func<T, int> Type { get; set; }
        public Dictionary<int, double> Details { get; set; }

    }
}
