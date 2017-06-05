using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_day2
{
    internal class Cart<Book>
    {
        private readonly Rule<Book> rules;

        public Cart(Rule<Book> rules)
        {
            this.rules = rules;
        }

        internal int Checkout(List<Book> cart, Func<Book, int> selector)
        {
            int result =GetAmount(cart, selector);
            //var typeCount = cart.Select(a => a).Distinct();
            

            return result;
        }

        private int GetAmount(List<Book> cart, Func<Book, int> selector)
        {
            int result = 0;
            if (cart.Select(a=>a).Distinct().Count()==1)
            {
                return cart.Sum(selector);
            }
            else
            {
                int+=GetAmount()
            }
            return result;
        }
    }
}