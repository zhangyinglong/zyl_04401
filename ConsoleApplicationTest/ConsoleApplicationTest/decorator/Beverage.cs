using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.decorator
{
    abstract class Beverage
    {
        public abstract double cost();
    }

    class Softdrink : Beverage
    {
        public override double cost()
        {
            return 1.5;
        }
    }
}
