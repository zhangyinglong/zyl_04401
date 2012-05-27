using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.strategy
{
    class Quack : IQuackBehavior
    {
        public void quack()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Squeak : IQuackBehavior
    {
        public void quack()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class MuteQuack : IQuackBehavior
    {
        public void quack()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
