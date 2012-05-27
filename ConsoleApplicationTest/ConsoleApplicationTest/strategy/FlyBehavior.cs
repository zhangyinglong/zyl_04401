using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.strategy
{
    class FlyWithWings : IFlyBehavior
    {
        public void fly()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class FlyNoWay : IFlyBehavior
    {
        public void fly()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class FlyWithRocket : IFlyBehavior
    {
        public void fly()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
