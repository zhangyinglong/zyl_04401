using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConsoleApplicationTest.iterator;

namespace ConsoleApplicationTest.composite
{
    abstract class MenuComponent
    {
        public string Name { set; get; }

        public MenuComponent Parent { private set; get; }
        public MenuComponent() { this.Parent = null; }

        public virtual void add(MenuComponent menuComponent) { menuComponent.Parent = this; }
        public virtual void remove(MenuComponent menuComponent) { }
        public virtual MenuComponent getChild(int index) { return null; }

        public virtual void print()
        {
            for (MenuComponent tmp = this.Parent; tmp != null; tmp = tmp.Parent)
            {
                Console.Write("  ");
            }
        }

        public abstract Iterator createIterator();
    }

    class Menu : MenuComponent
    {
        public ArrayList MenuList { set; get; }
        
        public Menu(string Name)
        {
            this.MenuList = new ArrayList();
            this.Name = Name;
        }

        public override void add(MenuComponent menuComponent)
        {
            base.add(menuComponent);
            this.MenuList.Add(menuComponent);
        }

        public override void remove(MenuComponent menuComponent)
        {
            this.MenuList.Remove(menuComponent);
        }

        public override MenuComponent getChild(int index)
        {
            return (MenuComponent)this.MenuList[index];
        }

        public override void print()
        {
            base.print();
            Console.WriteLine(this.Name);
            Iterator iterator = createIterator();
            while (iterator.hasNext())
            {
                MenuComponent component = (MenuComponent)iterator.Next();
                //if (component is Menu)
                {
                    component.print();
                }
            }
        }

        public override Iterator createIterator()
        {
            //return new ComponentIterator(new ArrayListIterator(this.MenuList));
            return new ArrayListIterator(this.MenuList);
        }
    }

    class MenuItem : MenuComponent
    {
        public MenuItem(string Name)
        {
            this.Name = Name;
        }

        public override void print()
        {
            base.print();
            Console.WriteLine(this.Name);
        }

        public override Iterator createIterator()
        {
            return new NullIterator();
        }
    }
}
