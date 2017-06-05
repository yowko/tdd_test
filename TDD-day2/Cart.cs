using System;
using System.Collections.Generic;

namespace TDD_day2
{
    internal class Cart<Book>
    {
        private Rule<Book> rules;

        public Cart(Rule<Book> rules)
        {
            this.rules = rules;
        }

        internal object Checkout(List<Book> cart, Func<Book, int> p)
        {
            throw new NotImplementedException();
        }
    }
}