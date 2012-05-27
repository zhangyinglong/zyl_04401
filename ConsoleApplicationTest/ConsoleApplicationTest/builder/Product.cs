using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.builder
{
    class Product
    {
        public string Name { set; get; }

        public void print()
        {
            this.Name += " Product over!";
            Console.WriteLine(this.Name);
        }
    }
}
