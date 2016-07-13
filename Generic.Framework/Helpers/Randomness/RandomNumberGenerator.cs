using System;
using System.Collections.Generic;

namespace Generic.Framework.Helpers.Randomness
{
    public class RandomNumberGenerator
    {
        Random _random = new Random();

        public decimal GetRandomDecimal(decimal maximum = 100)
        {
            return System.Math.Round((((decimal)this._random.NextDouble()) * maximum), 2);
        }

        public int GetRandomInt(int minimum = 0, int maximum = 100)
        {
            if (minimum >= maximum)
                throw new ArgumentException("Min cannot >= max");

            return this._random.Next(minimum, maximum);
        }
    }
}