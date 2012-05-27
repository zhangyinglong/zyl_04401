using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.builder
{
    abstract class Builder
    {
        public Product product { set;get; }

        public Builder()
        {
            this.product = new Product();
        }

        public abstract void builderPartA();
        public abstract void builderPartB();
    }

    class BuilderFeition : Builder
    {
        public override void builderPartA()
        {
            this.product.Name += "Fei";
        }

        public override void builderPartB()
        {
            this.product.Name += "tion";
        }
    }

    class BuilderFeiliao : Builder
    {
        public override void builderPartA()
        {
            this.product.Name += "Fei";
        }

        public override void builderPartB()
        {
            this.product.Name += "liao";
        }
    }
}
