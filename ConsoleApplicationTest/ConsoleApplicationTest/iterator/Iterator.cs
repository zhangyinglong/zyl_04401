using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConsoleApplicationTest.composite;

namespace ConsoleApplicationTest.iterator
{
    public interface Iterator
    {
        bool hasNext();
        object Next();
    }

    class ArrayIterator : Iterator
    {
        private object[] _array;
        public int Pos { set; get; }

        public ArrayIterator(object[] array)
        {
            _array = array;
        }

        public bool hasNext()
        {
            bool ret = false;
            if (this.Pos < _array.Length && this._array[this.Pos] != null)
            {
                ret = true;
            }
            return ret;
        }

        public object Next()
        {
            object obj = this._array[this.Pos];
            this.Pos += 1;
            return obj;
        }
    }

    class ArrayListIterator : Iterator
    {
        public ArrayList arrayList { set; get; }
        public int Pos { set; get; }

        public ArrayListIterator(ArrayList arraylist)
        {
            this.arrayList = arraylist;
        }

        public bool hasNext()
        {
            bool ret = false;
            if (this.Pos < this.arrayList.Count && this.arrayList[this.Pos] != null)
            {
                ret = true;
            }
            return ret;
        }

        public object Next()
        {
            object obj = this.arrayList[this.Pos];
            this.Pos += 1;
            return obj;
        }
    }

    class NullIterator : Iterator
    {
        public bool hasNext()
        {
            return false;
        }

        public object Next()
        {
            return null;
        }
    }

    class ComponentIterator : Iterator
    {
        public Stack stack { set; get; }

        public ComponentIterator(Iterator iterator)
        {
            this.stack = new Stack();
            stack.Push(iterator);
        }

        public bool hasNext()
        {
            if (this.stack.Count <= 0)
            {
                return false;
            } 
            else
            {
                Iterator iterator = (Iterator)this.stack.Peek();
                if (!iterator.hasNext())
                {
                    this.stack.Pop();
                    return hasNext();
                } 
                else
                {
                    return true;
                }
            }
        }

        public object Next()
        {
           if (hasNext())
           {
               Iterator iterator = (Iterator)this.stack.Peek();
               MenuComponent component = (MenuComponent)iterator.Next();
               if (component is Menu)
               {
                   this.stack.Push(component.createIterator());
               }
               return component;
           } 
           else
           {
               return null;
           }
        }
    }
}
