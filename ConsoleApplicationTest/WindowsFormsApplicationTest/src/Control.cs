using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Timers;
using System.Windows.Forms;

using ConsoleApplicationTest.observer;
using ConsoleApplicationTest.iterator;

namespace WindowsFormsApplicationTest.src
{
    public interface IControl : IObserver
    {
        void start();
        void reset();
    }

    public class MyControl : IControl
    {
        #region 观察者接口

        public void update(int value)
        {
            this.model.Value = value;
        }

        #endregion

        #region 控制器接口

        public Model model { private set; get; }

        #endregion

        private void timer_Tick(object source, EventArgs e)
        {
            this.update(this.model.Value + 1);
        }

        public MyControl(Model model)
        {
            this.model = model;
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick +=  new EventHandler(timer_Tick);
        }

        public void start()
        {
            if (this.timer.Enabled)
            {
                this.timer.Stop();
            }
            else
            {
                this.timer.Start();
            }
        }

        public void reset()
        {
            this.timer.Stop();
            this.update(0);
        }
        
        public Timer timer { private set; get; }
    }
}
