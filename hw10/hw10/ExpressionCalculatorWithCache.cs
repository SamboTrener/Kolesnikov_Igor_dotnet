using System;
using System.Linq;
using hw10.Interfaces;
using hw10.Models;

namespace hw10
{
    public class ExpressionCalculatorWithCache : ICalculator
    {
        public ApplicationContext db;
        private ExpressionCache exCache;
        private ExpressionCalculator calculator;

        public ExpressionCalculatorWithCache(ExpressionCalculator calculator, ApplicationContext db)
        {
            this.calculator = calculator;
            this.db = db;
            exCache = new ExpressionCache();
        }

        public double Calculate(string input)
        {
            var cache = db.ExpressionCaches.SingleOrDefault(exC => exC.Expression.Equals(input));
            if (cache != null)
                return cache.Result;
            try
            {
                var resultToCache = calculator.Calculate(input);
                exCache.Expression = input;
                exCache.Result = resultToCache;
                db.ExpressionCaches.Add(exCache);
                db.SaveChanges();
                return resultToCache;
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }
    }
}