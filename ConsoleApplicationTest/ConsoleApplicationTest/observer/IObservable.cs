using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.observer
{
    public interface IObservable
    {
        void addObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObserver();
    }
}
