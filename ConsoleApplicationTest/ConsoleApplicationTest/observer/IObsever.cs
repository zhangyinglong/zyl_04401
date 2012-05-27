using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.observer
{
    public interface IObserver
    {
        void update(int value);
    }
}
