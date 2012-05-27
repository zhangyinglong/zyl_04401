using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.factory
{
    // 北京工厂使用C语言
    class BeijingAbstractFactroy : IAbstractFactroy
    {
        public Language CreateLanguage()
        {
            return new CLanguage();
        }
    }

    // 北京工厂使用Java语言
    class NanjingAbstractFactroy : IAbstractFactroy
    {
        public Language CreateLanguage()
        {
            return new JavaLanguage();
        }
    }
}
