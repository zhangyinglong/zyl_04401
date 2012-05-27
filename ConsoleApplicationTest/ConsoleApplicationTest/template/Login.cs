using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.template
{
    abstract class Login
    {
        public void standardLogin() //定义算法框架
        {
            inputName();
            inputPassWord();
            startLogin();
            hook();
        }

        public void startLogin()
        {
            Console.WriteLine(this.ToString() + " startLogin()");
        }

        public virtual void hook() { }      // 钩子方法

        public abstract void inputName();
        public abstract void inputPassWord();
    }

    class OneClickLogin : Login
    {
        public override void inputName()
        {
            Console.WriteLine(this.ToString() + " inputName()");
        }

        public override void inputPassWord()
        {
            Console.WriteLine(this.ToString() + " inputPassWord()");
        }

         public override void hook()
        {
            Console.WriteLine(this.ToString() + " hook()");
        }
    }
}
