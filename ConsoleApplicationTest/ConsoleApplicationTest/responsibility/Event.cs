using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.responsibility
{
    abstract class Event
    {
        public enum EEventType
        {
            LISTEN,
            SAID,
            READ,
            WRITE
        }

        public EEventType Type { set; get; }

        public Event(EEventType Type)
        {
            this.Type = Type;
        }
    }

    class KeyEvent : Event
    {
        public KeyEvent(EEventType Type)
            : base(Type)
        {
        }
    }

    class SystemEvent : Event
    {
        public SystemEvent(EEventType Type)
            : base(Type)
        {
        }
    }
}
