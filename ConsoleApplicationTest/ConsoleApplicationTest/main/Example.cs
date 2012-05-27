using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplicationTest.main
{
    class Example
    {
        private int factor;
        public Example(int f)
        {
            factor = f;
        }
        public int SampleMethod(int x)
        {
            Console.WriteLine("Example.SampleMethod({0}) executes.", x);
            return x * factor;
        }

        private static void printType(Type type)
        {
            Console.WriteLine("类型名:" + type.Name);
            Console.WriteLine("类全名：" + type.FullName);
            Console.WriteLine("命名空间名:" + type.Namespace);
            Console.WriteLine("程序集名：" + type.Assembly);
            Console.WriteLine("模块名:" + type.Module);
            Console.WriteLine("基类名：" + type.BaseType);
            Console.WriteLine("是否类：" + type.IsClass);
            Console.WriteLine("类的公共成员：");
            MemberInfo[] memberInfos = type.GetMembers();//得到所有公共成员
            foreach (var item in memberInfos)
            {
                Console.WriteLine("{0}:{1}", item.MemberType, item);
            }
            Console.WriteLine("---------------------------------------------------\n");
        }

        private static void printAssembly(Assembly assem)
        {
            Console.WriteLine("程序集全名:" + assem.FullName);
            Console.WriteLine("程序集的版本：" + assem.GetName().Version);
            Console.WriteLine("程序集初始位置:" + assem.CodeBase);
            Console.WriteLine("程序集位置：" + assem.Location);
            Console.WriteLine("程序集入口：" + assem.EntryPoint);
            Type[] types = assem.GetTypes();
            Console.WriteLine("程序集下包含的类型:");
            foreach (var item in types)
            {
                Console.WriteLine("类：" + item.Name);
            }
            Console.WriteLine("---------------------------------------------------\n");
        }

        public static Object createInstance()
        {
            string type_str = "ConsoleApplicationTest.main.Example";
            string func_str = "SampleMethod";

            //获取当前执行代码的程序集，或其他程序集
            Assembly assem = Assembly.GetExecutingAssembly();//Assembly.Load("ConsoleApplicationTest");//
            // 打印程序集信息
            printAssembly(assem);

            // 从程序集众获取一个类型
            Type type = assem.GetType(type_str);
            // 打印类的信息
            printType(type);

            // 创建一个Example实例并且用object类型的引用o指向它，同时调用一个输入参数的构造函数
            Object o = assem.CreateInstance(type.FullName, false, BindingFlags.ExactBinding, null, new Object[] { 2 }, null, null);

            //构造Example类的一个晚绑定的方法
            MethodInfo m = type.GetMethod(func_str);
            //调用刚才实例化好的Example对象o中的SampleMethod方法，传入的参数为42
            Object ret = m.Invoke(o, new Object[] { 42 }); // 等价于 int ret = (Example)o.SampleMethod(42);
            Console.WriteLine("SampleMethod returned {0}.", ret);

            Console.WriteLine("\nAssembly entry point:");
            Console.WriteLine(assem.EntryPoint + "\n");
            return o;
        }
    }
}
