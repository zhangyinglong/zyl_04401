using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.observer
{
    abstract class BaseClass : IObserver
    {
        public int value { set; get; }
        public virtual void update(int value)
        {
            this.value = value;
        }
    }

    class Observer_1 : BaseClass
    {
        public override void update(int value)
        {
            base.update(value);
            Console.WriteLine("[ Class Obsever_1 ] value = " + this.value);
        }
    }

    class Observer_2 : BaseClass
    {
        public override void update(int value)
        {
            base.update(value);
            Console.WriteLine("[ Class Obsever_2 ] value = " + this.value);
        }
    }

    class Observer_3 : BaseClass
    {
        public override void update(int value)
        {
            base.update(value);
            Console.WriteLine("[ Class Obsever_3 ] value = " + this.value);
        }
    }
}
