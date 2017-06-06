using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_day2
{
    internal class Cart<T>
    {
        private readonly Rule<T> rules;

        public Cart(Rule<T> rules)
        {
            this.rules = rules;
        }

        internal double Checkout(List<T> cart, Func<T, double> selector)
        {
            double result = GetAmount(cart, selector);
            return result;
        }

        private double GetAmount(List<T> cart, Func<T, double> selector)
        {
            double result = 0;
            var DistinctCart = cart.Select(a => a).Distinct();

            double discount = 0.0;
            if (rules.Details.TryGetValue(DistinctCart.ToList().Count(), out discount))
            {
                var disCartList = DistinctCart.ToList();
                foreach (var item in disCartList)
                {
                    cart.Remove(item);
                }
                result = disCartList.Sum(selector) * (1 - discount);
                result += GetAmount(cart, selector);
            }
            else
                return cart.Sum(selector);

            return result;
        }
    }
}