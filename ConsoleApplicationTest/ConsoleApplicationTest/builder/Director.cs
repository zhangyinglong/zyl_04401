using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.builder
{
    class Director
    {
        public Builder builder { set; get; }

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void construct()
        {
            this.builder.builderPartA();
            this.builder.builderPartB();
        }
    }
}
