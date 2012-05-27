using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.decorator
{
    abstract class Condiment : Beverage
    {
       public abstract string toString();
    }

    class Milk : Condiment
    {
        private Beverage beverage { set; get; }
        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double cost()
        {
            return this.beverage.cost() + 0.5;
        }

        public override string toString()
        {
            return "Beverage with milk";
        }
    }

    class Tea : Condiment
    {
        private Beverage beverage { set; get; }
        public Tea(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double cost()
        {
            return this.beverage.cost() + 0.6;
        }

        public override string toString()
        {
            return "Beverage with tea";
        }
    }
}
