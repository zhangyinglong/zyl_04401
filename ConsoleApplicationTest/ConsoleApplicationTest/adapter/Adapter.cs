using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.adapter
{
    class ObjectAdapter : IAdapter
    {
        public Adaptee adaptee { set; get; }

        public ObjectAdapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void request()
        {
            this.adaptee.specialRequest();
        }
    }
}
