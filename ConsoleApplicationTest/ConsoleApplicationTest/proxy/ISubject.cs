using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.proxy
{
    public interface ISubject
    {
        void request();
    }

    public class ProxySubject : ISubject
    {
        public RealSubject _real { private set; get; }

        public ProxySubject()
        {
            this._real = new RealSubject();
        }

        public void request()
        {
            preprocess();

            this._real.request();

            postprocess();

        }

        private void preprocess()
        {
            System.Console.WriteLine("Before handling request.");
        }

        private void postprocess()
        {
            System.Console.WriteLine("After handling request.");
        }
    }


    public class RealSubject : ISubject
    {

        public RealSubject()
        {
            System.Console.WriteLine("RealSubject is instantiated.");
        }

        public void request()
        {
            System.Console.WriteLine("RealSubject.Request().");
        }
    }
}
