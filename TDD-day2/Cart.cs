using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_day2
{
    internal class Cart<T>
    {
        private readonly Dictionary<int, double> rules;

        public Cart(Dictionary<int, double> rules)
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
            var DistinctCart = cart.Distinct();

            double discount = 0.0;
            if (rules.TryGetValue(DistinctCart.ToList().Count(), out discount))
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