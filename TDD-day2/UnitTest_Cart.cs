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

        private static Dictionary<int, double> rules;
        [ClassInitialize]
        public static void RuleInit(TestContext testcontext)
        {
            rules = new Dictionary<int, double>()
                {
                    { 5,0.25},
                    { 4,0.20},
                    { 3,0.10},
                    { 2,0.05},
                }
            ;

        }
        [TestMethod]
        public void Test_第一集買了一本_其他都沒買_價格應為100()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100}
                };
            var expected = 100;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100}
                };
            var expected = 190;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_一二三集各買了一本_價格應為270()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100}
                };
            var expected = 270;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為320()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 4,Name = "HarryPotter 4",Price = 100}
                };
            var expected = 320;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_一次買了整套_一二三四五集各買了一本_價格應為375()
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
        [TestMethod]
        public void Test_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100}
                };
            var expected = 370;

            // act
            var actual = target.Checkout(cart, a => a.Price);


            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_第一集買了一本_第二三集各買了兩本_價格應為460()
        {
            //arrange
            var target = new Cart<Book>(rules);
            var cart =
                new List<Book>
                {
                    new Book(){Id = 1,Name = "HarryPotter 1",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 2,Name = "HarryPotter 2",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100},
                    new Book(){Id = 3,Name = "HarryPotter 3",Price = 100}
                };
            var expected = 460;

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
}
