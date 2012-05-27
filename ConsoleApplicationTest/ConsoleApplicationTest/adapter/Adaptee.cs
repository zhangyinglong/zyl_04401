using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.adapter
{
    class Adaptee
    {
        public void specialRequest()
        {
            Console.WriteLine(this.ToString() + " specialRequest()");
        }
    }
}
