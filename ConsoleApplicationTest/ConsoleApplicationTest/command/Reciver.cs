using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.command
{
    abstract class Reciver
    {
        public abstract void action();
        public abstract void undo();
    }

    class Reciver_1 : Reciver
    {
        public override void action()
        {
            Console.WriteLine(" - Reciver_1 action -");
        }

        public override void undo()
        {
            Console.WriteLine(" - Reciver_1 undo -");
        }
    }

    class Reciver_2 : Reciver
    {
        public override void action()
        {
            Console.WriteLine(" - Reciver_2 action -");
        }

        public override void undo()
        {
            Console.WriteLine(" - Reciver_2 undo -");
        }
    }
}
