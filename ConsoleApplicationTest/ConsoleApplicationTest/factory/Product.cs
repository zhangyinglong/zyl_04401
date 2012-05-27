using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.factory
{
    public enum EProductBelong { BEIJING, NANJING }
    public enum EProductType { FEILIAO, FEIXIN }

    abstract class Product
    {
        public IAbstractFactroy abstractFactroy { set; get; }
        protected Language language { set; get; }
        protected abstract void prepareLanguage();
        protected abstract void design();
        protected abstract void coding();
        protected abstract void complete();
        protected abstract void test();

        public void start()
        {
            prepareLanguage();
            design();
            coding();
            complete();
            test();
        }
    }

    class Feiliao : Product
    {
        protected override void prepareLanguage()
        {
            this.language = this.abstractFactroy.CreateLanguage();
        }

        protected override void design()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine(" design by " + this.language.ToString());
        }

        protected override void coding()
        {
            Console.WriteLine(" coding by " + this.language.ToString());
        }

        protected override void complete()
        {
            Console.WriteLine(" complete");
        }

        protected override void test()
        {
            Console.WriteLine(" test");
        }
    }

    class Feixin : Product
    {
        protected override void prepareLanguage()
        {
            this.language = this.abstractFactroy.CreateLanguage();
        }

        protected override void design()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine(" design by " + this.language.ToString());
        }

        protected override void coding()
        {
            Console.WriteLine(" coding by " + this.language.ToString());
        }

        protected override void complete()
        {
            Console.WriteLine(" complete");
        }

        protected override void test()
        {
            Console.WriteLine(" test");
        }
    }
}
