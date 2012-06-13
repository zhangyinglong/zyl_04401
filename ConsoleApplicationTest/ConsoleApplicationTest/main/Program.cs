using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

using ConsoleApplicationTest.main;
using ConsoleApplicationTest.singleton;
using ConsoleApplicationTest.strategy;
using ConsoleApplicationTest.observer;
using ConsoleApplicationTest.decorator;
using ConsoleApplicationTest.command;
using ConsoleApplicationTest.factory;
using ConsoleApplicationTest.adapter;
using ConsoleApplicationTest.template;
using ConsoleApplicationTest.iterator;
using ConsoleApplicationTest.composite;
using ConsoleApplicationTest.state;
using ConsoleApplicationTest.proxy;
using ConsoleApplicationTest.prototype;
using ConsoleApplicationTest.builder;
using ConsoleApplicationTest.responsibility;
using ConsoleApplicationTest.database;
using ConsoleApplicationTest.utility;
using ConsoleApplicationTest.threadpool;
using ConsoleApplicationTest.xml;
using ConsoleApplicationTest.base64;
using ConsoleApplicationTest.binarytree;

[assembly: InternalsVisibleTo("WindowsFormsApplicationTest")]

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_singleton_mode();
            //test_strategy_mode();
            //test_observer_mode();
            //test_decorator_mode();
            //test_command_mode();
            //test_factory_mode();
            //test_adapter_mode();
            //test_template_mode();
            //test_iterator_mode();
            //test_composite_mode();
            //test_state_mode();
            //test_proxy_mode();
            //test_prototype_mode();
            //test_builder_mode();
            //test_responsibility_mode();
            //test_reflection();
            //test_regex();
            //test_database();
            //test_threadpool();
            //test_xml();
            //test_base64();
            test_binarytree();
        }
        
        static void test_singleton_mode()
        {
            /*
             * 单件模式：确保一个类只有一个实例，并提供一个全局访问点。      
             */
            Console.WriteLine("\n---------------- test singleton --------------------\n");
            Singleton.getInstance().toString();
            Singleton_1.getInstance().toString();
        }

        static void test_strategy_mode()
        {
            /*
             * 策略模式：定义算法族，分别封装起来，让他们之间可以互相替换，让算法的变化独立于使用算法的客户。 
             * 设计原则 - 1、封装可能变化的部分，分开变化和不会变化的部分。
             *            2、针对接口编程，而不是针对实现编程。
             *            3、多用组合，少用继承。
             */
            Console.WriteLine("\n---------------- test strategy --------------------\n");
            Duck duck = new Duck();
            duck.performQuack();
            duck.performFly();
            duck.setFlyBehavior(new FlyWithRocket());
            duck.setQuackBehavior(new MuteQuack());
            duck.performQuack();
            duck.performFly();
        }

        static void test_observer_mode()
        {
            /*
             * 观察者模式：定义对象之间一对多的依赖，当一个对象改变状态时，他的所有依赖者都会收到通知并自动更新。
             * 设计原则 - 1、为交互对象之间的松耦合设计而努力。
             */
            Console.WriteLine("\n---------------- test observer --------------------\n");
            Subject subject = new Subject();
            Observer_1 observer_1 = new Observer_1();
            Observer_2 observer_2 = new Observer_2();
            Observer_3 observer_3 = new Observer_3();
            subject.addObserver(observer_1);
            subject.addObserver(observer_2);
            subject.addObserver(observer_3);
            subject.isChanged = true;
            subject.Length = 2;
            subject.removeObserver(observer_2);
            subject.Length = 3;
        }

        static void test_decorator_mode()
        {
            /*
             * 装饰者模式：动态地将责任附加到对象上。（提供了比继承更有弹性的替代方案）
             * 设计原则 - 1、对扩展开放，对修改关闭。
             */
            Console.WriteLine("\n---------------- test decorator --------------------\n");
            Softdrink softdrink = new Softdrink();
            Console.WriteLine(softdrink.ToString() + " cost = " + softdrink.cost());
            Milk milk = new Milk(softdrink);
            Console.WriteLine(milk.toString() + " cost = " + milk.cost());
            Tea tea = new Tea(milk);
            Console.WriteLine(tea.toString() + " cost = " + tea.cost());
        }

        static void test_command_mode()
        {
            /*
             * 命令模式：将“请求”封装成对象，以便使用不同的请求、队列或者日志来参数化其他对象。命令模式也支持可撤销的操作。
             */
            Console.WriteLine("\n---------------- test command --------------------\n");
            RemoteControl remote = new RemoteControl();

            Reciver_1 reciver_1 = new Reciver_1();
            Command_1 cmd_1 = new Command_1(reciver_1);
            Reciver_2 reciver_2 = new Reciver_2();
            Command_2 cmd_2 = new Command_2(reciver_2);

            Command[] commands = { cmd_1, cmd_2 };
            MacroCommand macro_cmd = new MacroCommand(commands);
            remote.setCommand(0, macro_cmd);
            remote.setCommand(1, cmd_1);
            remote.toString();
            remote.onButtonPressed(1);
            remote.onUndo();
            remote.onRedo();
            remote.onButtonPressed(0);
            remote.onUndo();
            remote.onUndo();
        }

        static void test_factory_mode()
        {
            /*
             * 工厂模式：定义一个创建对象的接口，但由子类决定要实例化的类是哪一个，让类把实例化推迟到子类。（以继承方式）
             * 设计原则 - 1、要依赖抽象，不要以来具体的类。(依赖倒置原则)
             * 抽象工厂模式：提供一个接口，用于创建相关或以来对象的家族，而不需要明确指定具体类。（以对象组合方式）
             */
            Console.WriteLine("\n---------------- test factory --------------------\n");
            Factory factory = new BeijingFactory();
            BeijingAbstractFactroy beijingAbstractFactroy = new BeijingAbstractFactroy();
            factory.orderProduct(EProductType.FEILIAO, beijingAbstractFactroy);
        }

        static void test_adapter_mode()
        {
            /*
             * 适配器模式：将一个类的接口，转换成客户期望的另一个接口。适配器让原本不兼容的类可以合作无间。
             */
            Console.WriteLine("\n---------------- test adapter --------------------\n");
            Adaptee adaptee = new Adaptee();
            ObjectAdapter adapter = new ObjectAdapter(adaptee);
            adapter.request();
        }

        /*
        * 外观模式：提供一个统一的接口，用来访问子系统中的一群接口，外观定义了一个高层接口，让子系统更容易使用。
        * 设计原则 - 1、最少知识原则。
        */

        static void test_template_mode()
        {
            /*
             * 模版方法模式：定义一个算法的框架，而将一些步骤的实现延迟到子类中。使子类可以在不改变算法框架的情况下，重新定义算法中的某些步骤。
             * 设计原则 - 1、好莱坞原则：别调用我们，我们会调用你。（高层组件可以调用低层组件，但是低层不能直接调用高层组件）
             */
            Console.WriteLine("\n---------------- test template --------------------\n");
            OneClickLogin login = new OneClickLogin();
            login.standardLogin();
        }

        static void test_iterator_mode()
        {
            /*
             * 迭代器模式：提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露其内部实行。
             * 设计原则 - 1、单一责任
             */
            Console.WriteLine("\n---------------- test iterator --------------------\n");
            int[] array = new int[] { 1, 2, 3, 4 };
            Aggregate aggregate = new Aggregate(array);
            Iterator iterator = aggregate.CreateTerator();
            while (iterator.hasNext())
            {
                Console.WriteLine("test_iterator_mode " + iterator.Next());//隐式拆箱
            }
        }

        static void test_composite_mode()
        {
            /*
             * 组合模式：使用对象组合成树形结构来表现“整体/部分”层次结构。组合能让客户以一致的方式处理个别对象以及对象组合。
             */
            Console.WriteLine("\n---------------- test composite --------------------\n");
            MenuComponent allMenus = new Menu("AllMenus");
            MenuComponent firstMenu = new Menu("FirstMenu");
            MenuComponent secondMeun = new Menu("SecondMenu");
            MenuComponent threeMeunItem = new MenuItem("threeMeunItem");
            MenuComponent thirdMeunItem = new MenuItem("thirdMeunItem");
            MenuComponent a = new MenuItem("aMeunItem");
            allMenus.add(a);
            allMenus.add(firstMenu);
            allMenus.add(secondMeun);
            
            firstMenu.add(threeMeunItem);
            //if (secondMeun is Menu)
            {
                secondMeun.add(thirdMeunItem);
            }
            allMenus.print();
        }

        static void test_state_mode()
        {
            /*
             * 状态模式：允许对象在内部状态改变时改变它的行为，对象看起来好像修改了它的类。（客户不清楚内部状态间的转换，策略模式则需要客户了解状态间的转换）时。
             */
            Console.WriteLine("\n---------------- test state --------------------\n");
            StatesContent content = new StatesContent();
            content.addState(new DownloadState(content));
            content.addState(new StopDownloadState(content));
            content.addState(new PlayState(content));
            content.addState(new StopPlayState(content));
            content.download();
            Console.Read();
        }

        static void test_proxy_mode()
        {
            /*
             * 代理模式：为另一个对象提供一个代理以控制对这个这个对象的访问。
             */
            Console.WriteLine("\n---------------- test proxy --------------------\n");
            ProxySubject proxy = new ProxySubject();
            proxy.request();
        }

        static void test_prototype_mode()
        {
            /*
             * 原型模式：用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
             * 设计原则 - 1、依赖倒置原则
             * 适用范围：
             *  1、当要实例化的类是在运行时刻指定时，例如，通过动态装载；
             *  2、为了避免创建一个与产品类层次平行的工厂类层次时；
             *  3、当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。
             */
            Console.WriteLine("\n---------------- test proxy --------------------\n");
            ColorManager colormanager = new ColorManager();

            string[] colorname = { "red", "green" , "blue" };
            colormanager[colorname[0]] = new ConcteteColorPrototype(255, 0, 0, 0);
            colormanager[colorname[1]] = new ConcteteColorPrototype(0, 255, 0, 0);
            colormanager[colorname[2]] = new ConcteteColorPrototype(0, 0, 255, 0);

            ConcteteColorPrototype c0 = (ConcteteColorPrototype)colormanager[colorname[0]].clone(false);
            ConcteteColorPrototype c1 = (ConcteteColorPrototype)colormanager[colorname[1]].clone(false);
            ConcteteColorPrototype c2 = (ConcteteColorPrototype)colormanager[colorname[2]].clone(false);
            c0.Display(colorname[0]);
            c1.Display(colorname[1]);
            c2.Display(colorname[2]);
        }

        static void test_builder_mode()
        {
            /*
             * 生成器模式：将一个复杂的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
             * 适用范围：
             *  1、当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
             *  2、当构造过程必须允许被构造的对象有不同的表示时。
             */
            Console.WriteLine("\n---------------- test builder --------------------\n");
            Builder builder1 = new BuilderFeition();
            Director director = new Director(builder1);
            director.construct();
            ConsoleApplicationTest.builder.Product product = builder1.product;
            product.print();

            Builder builder2 = new BuilderFeiliao();
            director.builder = builder2;
            director.construct();
            product = builder2.product;
            product.print();
        }

        static void test_responsibility_mode()
        {
            /*
             * 责任链模式：将请求的发送者和接收者之间解耦，使多个对象都有机会处理这个请求。
             * 将这些对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它。
             */
            Console.WriteLine("\n---------------- test responsibility --------------------\n");
            KeyEvent keyEvent = new KeyEvent(Event.EEventType.READ);
            SystemEvent systemEvent = new SystemEvent(Event.EEventType.READ);
            Processor processor_a = new ProcessorA(null);
            Processor processor_b = new ProcessorB(processor_a);
            Processor processor_c = new ProcessorC(processor_b);
            Processor processor_d = new ProcessorD(processor_c);

            Console.WriteLine("\n---- from top to bottom\n");
            processor_a.onSystemEvent(systemEvent);
            Console.WriteLine("\n---- from bottom to top\n");
            processor_d.onKeyEvent(keyEvent);
        }

        static void test_reflection()
        {
            Example example = (Example)Example.createInstance();
        }

        static void test_regex()
        {
            string input = Console.ReadLine();
            if (PhoneManager.IsValidEmail(input))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            input = Console.ReadLine();
            if (PhoneManager.IsMobilePhone(input))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        static void test_database()
        {
            try
            {
                DataContextBase db = new DataContextBase(@"Data Source=Feiliao.sdf");
                DataBaseHelper.EnableDatabaseLog(db);
                DataBaseHelper.InitializeDatabase(db, true);
                IQueryable<Contact> contactQuery = from contact in db.TableContact select contact;
                Console.WriteLine("show contact table:");
                Console.WriteLine("id\tname");
                foreach (Contact c in contactQuery)
                {
                    Console.WriteLine("{0}\t{1}", c.ContactID, c.ContactName);
                }
                DataBaseHelper.DisableDatabaseLog(db);
                db.Dispose();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating the DB: " + ex.Message);
            }
        }

        static void test_threadpool()
        {
            ThreadPoolExample.test();
            //ThreadSyncSample.test();
            //WorkerThreadExample.test();
        }

        static void test_xml()
        {
            XMLsample.test();
        }

        static void test_base64()
        {
            Console.WriteLine("\n---------------- test base64 encode and decode --------------------\n");
            MyBase64.base64Test();
        }

        static void test_binarytree()
        {
            Console.WriteLine("\n---------------- test binary tree --------------------\n");
            BinaryTree<int> tree = new BinaryTree<int>(0);
            //tree.Insert(5);
            //tree.Insert(11);
            //tree.Insert(5);
            //tree.Insert(-12);
            //tree.Insert(15);
            //tree.Insert(12);
            //tree.Insert(14);
            //tree.Insert(-8);
            //tree.Insert(10);
            //tree.Insert(8);
            //tree.Insert(8);
            tree.Insert(5, 11, 5, -12, 15, 12, 14, -8, 10, 8, 8, 9);

            Console.WriteLine("=========== First traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.First);
            Console.WriteLine("");
            foreach (var i in tree.FirstTravEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n============ In-order traversal ===========");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Inorder);
            Console.WriteLine("");
            foreach (var i in tree.InorderEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Postorder traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Postorder);
            Console.WriteLine("");
            foreach (var i in tree.PostorderTravEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n============ Ascend traversal ===========");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Ascend);
            Console.WriteLine("");
            foreach (var i in tree.AscendEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Descend traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Descend);
            Console.WriteLine("");
            foreach (var i in tree.DescendEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Enumertor traversal ============");
            foreach (var i in tree)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine("\n\n=========== end ============");
        }
    }
}
