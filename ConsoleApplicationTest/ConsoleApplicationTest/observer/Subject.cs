using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.observer
{
    class Subject : IObservable
    {
        private ArrayList _observers = new ArrayList();
        private int _lenth = 0;
        public int Length
        {
            set { _lenth = value; this.notifyObserver(); }
            get { return _lenth; }
        }

        public bool isChanged
        {
            set;
            get;
        }

        public void addObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            try
            {
                _observers.Remove(o);
                Console.WriteLine("[ Class Subject ] removeObserver = " + o.ToString());
            }
            catch
            {
                Console.WriteLine("[ Class Subject ] removeObserver() error");
            }
        }

        public void notifyObserver()
        {
            if ( this.isChanged )
            {
                foreach (IObserver i in _observers)
                {
                    i.update(this.Length);
                }
            }
        }
    }
}
