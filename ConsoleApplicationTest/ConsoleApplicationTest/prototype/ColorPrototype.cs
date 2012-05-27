using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplicationTest.prototype
{
    [Serializable]
    abstract class ColorPrototype
    {
        public abstract ColorPrototype clone(bool isDeepCopy);
    }

    [Serializable]
    class ConcteteColorPrototype : ColorPrototype
    {
        private int _red, _green, _blue, _apha;

        public ConcteteColorPrototype(int red, int green, int blue, int apha)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
            this._apha = apha;
        }

        public ConcteteColorPrototype(ConcteteColorPrototype o)
        {
            this._red = o._red;
            this._green = o._green;
            this._blue = o._blue;
            this._apha = o._apha;
        }

        /*
        * 什么是浅拷贝(shallow  copy)和深拷贝(deep  copy)? 
        * 浅拷贝就是成员数据之间的一一赋值。
        * 但是可能会有这样的情况：对象还包含资源，这里的资源可以值堆资源，或者一个文件，
        * 当值拷贝的时候，两 个对象就有用共同的资源，同时对资源可以访问，这样就会出问题。
        * 深拷贝就是用来解决这样的问题的，它把资源也赋值一次，使对象拥有不同的资源，但资源的内容是一样的。
        * 对于堆资源来说，就是在开辟一片堆内存，把原来的内容拷贝。
        * 深拷贝和浅拷贝的区别是在对象状态中包含其它对象的引用的时候，
        * 当拷贝一个对象时，如果需要拷贝这个对象引用的对象，则是深拷贝，否则是浅拷贝。
        */
        public override ColorPrototype clone(bool isDeepCopy)
        {
            if (isDeepCopy)
            {
                return createDeepCopy(false);
            } 
            else
            {
                //此处调用object类的MemberwiseClone,实现浅拷贝
                return (ColorPrototype)this.MemberwiseClone();
            }
        }

        public ColorPrototype createDeepCopy(bool isSerial)
        {
            ColorPrototype colorPrototype = null;
            if (isSerial)
            {
                /*
                 * 此处使用序列化实现深拷贝。
                 * 序列化就是指将对象实例以二进制流的形式保存下来(文件保存、发送给网络)，
                 * 这些二进制流再通过反序列化，将序列化的对象加载到程序中
                 */
                MemoryStream memoryStream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);//序列化ColorPrototype对象
                memoryStream.Position = 0;
                colorPrototype = (ColorPrototype)formatter.Deserialize(memoryStream);//反序列化出ColorPrototype对象
            }
            else
            {
                //此处实现深拷贝
                colorPrototype = new ConcteteColorPrototype(this);
            }
            return colorPrototype;
        }

        public void Display(string colorname)
        {
            Console.WriteLine("{0}'s RGB Values are: {1},{2},{3},{4}", colorname, _red, _green, _blue, _apha);
        }
    }

    class ColorManager
    {
        Hashtable colors = new Hashtable();
        public ColorPrototype this[string name]
        {
            get
            {
                return (ColorPrototype)colors[name];
            }
            set
            {
                colors.Add(name, value);
            }
        }
    }
}
