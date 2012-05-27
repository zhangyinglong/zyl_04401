using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ConsoleApplicationTest.observer;
using WindowsFormsApplicationTest.src;

namespace WindowsFormsApplicationTest.ui
{
    public partial class Form1 : Form , IObserver
    {
        #region 观察者接口

        public void update(int value)
        {
            this.textBox1.Text = value.ToString();
            if (value > 0)
            {
                if (this.progressBar1.Value == 100)
                {
                    this.progressBar1.Value = 0;
                }
                this.progressBar1.PerformStep();
                
            }
        }

        #endregion

        #region 控制器接口

        public MyControl control { set; get; }
        public Model model { private set; get; }

        #endregion

        public Form1()
        {
            InitializeComponent();

            this.model = new Model();
            this.model.addObserver(this);

            this.control = new MyControl(this.model);
            this.update(0);
        }

        public void setControl()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.control != null)
            {
                this.control.start();
                if (this.control.timer.Enabled)
                {
                    this.button1.Text = "停止";
                }
                else
                {
                    this.button1.Text = "开始";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.control != null)
            {
                this.control.reset();
                this.button1.Text = "开始";
                this.progressBar1.Value = 0;
            }
        }
    }
}
