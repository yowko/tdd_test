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
            //var typeCount = cart.Select(a => a).Distinct();


            return result;
        }

        private double GetAmount(List<T> cart, Func<T, double> selector)
        {
            double result = 0;
            var DistinctCart = cart.Select(a => a).Distinct();
            if (DistinctCart.Count() == 0)
                return 0;
            else if (DistinctCart.Count() == 1)
            {
                return cart.Sum(selector);
            }
            else
            {
                var disCartList = DistinctCart.ToList();
                foreach (var item in disCartList)
                {
                    cart.Remove(item);
                }

                double discount = 0.0;
                rules.Details.TryGetValue(disCartList.Count(), out discount);
                result = disCartList.Sum(selector) * (1 - discount);
                result += GetAmount(cart, selector);
            }
            return result;
        }
    }
}