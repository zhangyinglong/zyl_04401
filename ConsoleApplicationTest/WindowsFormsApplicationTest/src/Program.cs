using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using WindowsFormsApplicationTest.ui;

namespace WindowsFormsApplicationTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void ApplicationRun()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Main()
        {
#if true
            //给Application加线程锁，保证只存在一个程序在运行
            bool bCreatedNew = false;
            Mutex m = new Mutex(false, "myUniqueName", out bCreatedNew);
            if (bCreatedNew)
            {
                ApplicationRun();
            }
            else
            {
                MessageBox.Show("程序已启动！");
            }
#else
            //查询Application进程ID，保证只存在一个程序在运行
            if (RunningInstance() == null)
            {
                ApplicationRun();
            }
            else
            {
                MessageBox.Show("程序已启动！");
            }
#endif
        }

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop through the running processes in with the same name
            foreach (Process process in processes)
            {
                //Ignore the current process
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file.
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance.
                        return process;
                    }
                }
            }
            //No other instance was found, return null.
            return null;
        }
    }
}
