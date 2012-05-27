using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.strategy
{
    class Duck
    {
        private IQuackBehavior quackBehavior { set; get; }
        private IFlyBehavior flyBehavior { set; get; }

        public Duck()
        {
            this.quackBehavior = new Quack();
            this.flyBehavior = new FlyWithWings();
        }

        public void setQuackBehavior(IQuackBehavior quackBehavior)
        {
            this.quackBehavior = quackBehavior;
        }

        public void setFlyBehavior(IFlyBehavior flyBehavior)
        {
            this.flyBehavior = flyBehavior;
        }

        public void performQuack()
        {
            quackBehavior.quack();
        }

        public void performFly()
        {
            flyBehavior.fly();
        }
    }
}
