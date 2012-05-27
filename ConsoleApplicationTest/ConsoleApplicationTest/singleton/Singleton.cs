using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.singleton
{
    class Singleton
    {
        private static Singleton _singleton = null;
        public static Singleton getInstance()
        {
            if (_singleton == null)
            {
                _singleton = new Singleton();
            }
            return _singleton;
        }

        private Singleton()
        {
        }

        public void toString()
        {
            Console.WriteLine("This is a singleton!");
        }
    }

    class Singleton_1
    {
        private static Singleton_1 _singleton = new Singleton_1();
        public static Singleton_1 getInstance()
        {
            return _singleton;
        }

        private Singleton_1()
        {
        }

        public void toString()
        {
            Console.WriteLine("This is a singleton_1!");
        }
    }
}
