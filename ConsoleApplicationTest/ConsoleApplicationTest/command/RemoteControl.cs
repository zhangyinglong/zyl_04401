using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.command
{
    class RemoteControl
    {
        private int _commandCount = 5;
        private Command[] _commands;
        private Stack<Command> _undoCommands;
        private Stack<Command> _redoCommands;

        public RemoteControl()
        {
            NoCommand command = new NoCommand(null);
            _commands = new Command[_commandCount];
            for ( int i = 0; i < _commandCount; i++ )
            {
                _commands[i] = command;
            }
            _undoCommands = new Stack<Command>();
            _redoCommands = new Stack<Command>();
        }

        public int getCommandCount()
        {
            return _commandCount;
        }

        public void setCommand(int slot, Command cmd)
        {
            if (slot >= 0 && slot < _commandCount)
            {
                _commands[slot] = cmd;
            }
        }

        public void onButtonPressed(int slot)
        {
            if ( slot >= 0 && slot < _commandCount )
            {
                _commands[slot].execute();
                _undoCommands.Push(_commands[slot]);
                _redoCommands.Clear();
            }
        }

        public void onUndo()
        {
            if ( _undoCommands.Count() > 0 )
            {
                Command cmd = _undoCommands.Pop();
                cmd.undo();
                _redoCommands.Push(cmd); 
            }
        }

        public void onRedo()
        {
            if ( _redoCommands.Count() > 0 )
            {
                Command cmd = _redoCommands.Pop();
                cmd.execute();
                _undoCommands.Push(cmd);
            }
        }

        public void toString()
        {
            string buf = null;
            Console.WriteLine("       command list");
            for ( int i = 0; i < _commandCount; i++ )
            {
                buf = "    slot[" + i + "] = " + _commands[i].ToString() + ";";
                Console.WriteLine(buf);
                buf.Remove(0);
            }
            Console.WriteLine("");
        }
    }
}
