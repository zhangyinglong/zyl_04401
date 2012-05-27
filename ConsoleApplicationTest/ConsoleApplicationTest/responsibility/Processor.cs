using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.responsibility
{
    abstract class Processor
    {
        public Processor Parent { set; get; }
        public Processor Child { set; get; }

        public Processor(Processor processor)
        {
            this.Parent = processor;
            if (this.Parent != null)
            {
                this.Parent.Child = this;
            }
            else
            {
                this.Child = null;
            }
        }

        // 事件由下往上传递
        public virtual void onKeyEvent(KeyEvent keyEvent)
        {
            if (this.Parent != null)
            {
                this.Parent.onKeyEvent(keyEvent);
            }
            else
            {
                Console.WriteLine("All not process!");
            }
        }

        // 事件由上往下传递
        public virtual void onSystemEvent(SystemEvent systemEvent)
        {
            if (this.Child != null)
            {
                this.Child.onSystemEvent(systemEvent);
            }
            else
            {
                Console.WriteLine("All not process!");
            }
        }
    }

    class ProcessorA : Processor
    {
        public ProcessorA(Processor parent)
            : base(parent)
        {
        }

        public override void onKeyEvent(KeyEvent keyEvent)
        {
            if (keyEvent.Type == Event.EEventType.LISTEN)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else
            {
                Console.WriteLine(this.ToString() + " not process!");
                base.onKeyEvent(keyEvent);
            }
        }

        public override void onSystemEvent(SystemEvent systemEvent)
        {
            if (systemEvent.Type == Event.EEventType.LISTEN)
            {
                Console.WriteLine(this.ToString() + " command over!");
            } 
            else if (this.Child != null)
            {
                Console.WriteLine(this.ToString() + " not process!");
                this.Child.onSystemEvent(systemEvent);
            }
        }
    }

    class ProcessorB : Processor
    {
        public ProcessorB(Processor parent)
            : base(parent)
        {
        }

        public override void onKeyEvent(KeyEvent keyEvent)
        {
            if (keyEvent.Type == Event.EEventType.SAID)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else
            {
                Console.WriteLine(this.ToString() + " not process!");
                base.onKeyEvent(keyEvent);
            }
        }

        public override void onSystemEvent(SystemEvent systemEvent)
        {
            if (systemEvent.Type == Event.EEventType.SAID)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else if (this.Child != null)
            {
                Console.WriteLine(this.ToString() + " not process!");
                this.Child.onSystemEvent(systemEvent);
            }
        }
    }

    class ProcessorC : Processor
    {
        public ProcessorC(Processor parent)
            : base(parent)
        {
        }

        public override void onKeyEvent(KeyEvent keyEvent)
        {
            if (keyEvent.Type == Event.EEventType.READ)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else
            {
                Console.WriteLine(this.ToString() + " not process!");
                base.onKeyEvent(keyEvent);
            }
        }

        public override void onSystemEvent(SystemEvent systemEvent)
        {
            if (systemEvent.Type == Event.EEventType.READ)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else if (this.Child != null)
            {
                Console.WriteLine(this.ToString() + " not process!");
                this.Child.onSystemEvent(systemEvent);
            }
        }
    }

    class ProcessorD : Processor
    {
        public ProcessorD(Processor parent)
            : base(parent)
        {
        }

        public override void onKeyEvent(KeyEvent keyEvent)
        {
            if (keyEvent.Type == Event.EEventType.WRITE)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else
            {
                Console.WriteLine(this.ToString() + " not process!");
                base.onKeyEvent(keyEvent);
            }
        }

        public override void onSystemEvent(SystemEvent systemEvent)
        {
            if (systemEvent.Type == Event.EEventType.WRITE)
            {
                Console.WriteLine(this.ToString() + " command over!");
            }
            else if (this.Child != null)
            {
                Console.WriteLine(this.ToString() + " not process!");
                this.Child.onSystemEvent(systemEvent);
            }
        }
    }
}
