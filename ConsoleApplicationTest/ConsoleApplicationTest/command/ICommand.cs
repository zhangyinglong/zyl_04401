using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.command
{
    public interface ICommand
    {
        void execute();
        void undo();
    }
}
