using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConsoleApplicationTest.observer;
using ConsoleApplicationTest.iterator;

namespace WindowsFormsApplicationTest.src
{
    public class Model : IObservable
    {
        public ArrayList Observers { private set; get; }
        public bool isChanged { set; get; }
        private int value = 0;
        public int Value 
        {
            set
            {
                this.value = value;
                this.notifyObserver();
            }
            get
            {
                return this.value;
            }
        }

        public Model()
        {
            this.Observers = new ArrayList();
            this.isChanged = true;
        }

        #region 可观察者接口

        public void addObserver(IObserver o)
        {
            this.Observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            try
            {
                this.Observers.Remove(o);
            }
            catch
            {

            }
        }

        public void notifyObserver()
        {
            if (this.isChanged)
            {
                Iterator it = this.createIterator();
                while (it.hasNext())
                {
                    object o = it.Next();
                    if (o is IObserver)
                    {
                        IObserver observer = (IObserver)o;
                        observer.update(this.Value);
                    }
                }
                //foreach (IObserver i in _observers)
                //{
                //    i.update(0);
                //}
            }
        }

        public Iterator createIterator()
        {
            return new ArrayListIterator(this.Observers);
        }

        #endregion

        
    }
}
