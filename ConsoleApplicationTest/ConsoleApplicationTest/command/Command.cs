using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.command
{
    abstract class Command : ICommand
    {
        private Reciver _reciver = null;
        public Command(Reciver reciver)
        {
            _reciver = reciver;
        }

        public virtual void execute()
        {
            _reciver.action();
        }

        public virtual void undo()
        {
            _reciver.undo();
        }
    }

    class MacroCommand : Command
    {
        private Command[] _commands;
        public MacroCommand(Command[] commands, Reciver reciver = null)
            : base(reciver)
        {
            _commands = commands;
        }

        public override void execute()
        {
            foreach (Command i in _commands)
            {
                i.execute();
            }
        }

        public override void undo()
        {
            for (int i = (_commands.Length - 1); i >= 0; i--)
            {
                _commands[i].undo();
            }
        }
    }

    class NoCommand : Command
    {
        public NoCommand(Reciver reciver) 
            : base(reciver)
        {

        }

        public override void execute()
        {
            Console.WriteLine(" - NoCommand -");
        }

        public override void undo()
        {
            Console.WriteLine(" - NoCommand undo -");
        }
    }

    class Command_1 : Command
    {
        public Command_1(Reciver reciver)
            : base(reciver)
        {

        }
    }

    class Command_2 : Command
    {
        public Command_2(Reciver reciver)
            : base(reciver)
        {

        }
    }
}
