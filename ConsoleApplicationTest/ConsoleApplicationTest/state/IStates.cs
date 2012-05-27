using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplicationTest.state
{
    public interface IStates
    {
        void download();
        void stopDownload();
        void play();
        void stopPlay();
    }

    enum EStateType{ EDownload, EStopDownload, EPlay, EStopPlay };

    class DownloadState : IStates
    {
        public StatesContent Content { set; get; }
        public Timer timer { set; get; }
        public bool Sucusess { private set; get; }

        private void theout(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(this.ToString() + " -- switch state --");
            this.Sucusess = true;
            this.Content.setState(EStateType.EPlay);
            this.Content.Play();
        }

        public DownloadState(StatesContent content)
        {
            this.Content = content;
            this.Sucusess = false;

            Random random = new Random();
            int time = random.Next(3) + 1;
            this.timer = new Timer(time*1000);//实例化Timer类，设置间隔时间为1000毫秒； 
            this.timer.Elapsed += new ElapsedEventHandler(theout);//到达时间的时候执行事件； 
            this.timer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)； 
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        public void download()
        {
            Console.WriteLine(this.ToString() + " -- download " + this.timer.Interval + " --");
            this.timer.Start();
        }

        public void stopDownload()
        {
            Console.WriteLine(this.ToString() + " -- stop download --");
            this.timer.Stop();
            this.Content.setState(EStateType.EStopDownload);
            this.Content.StopDownload();
        }

        public void play()
        {
            Console.WriteLine(this.ToString() + " -- can not play --");
        }

        public void stopPlay()
        {
            Console.WriteLine(this.ToString() + " -- can not stop play --");
        }
    }

    class StopDownloadState : IStates
    {
        public StatesContent Content { set; get; }

        public StopDownloadState(StatesContent content)
        {
            this.Content = content;
        }

        public void download()
        {
            Console.WriteLine(this.ToString() + " -- download --");
            this.Content.setState(EStateType.EDownload);
            this.Content.download();
        }

        public void stopDownload()
        {
            //Console.WriteLine(this.ToString() + " -- can not stop download --");
        }

        public void play()
        {
            Console.WriteLine(this.ToString() + " -- can not play --");
        }

        public void stopPlay()
        {
            Console.WriteLine(this.ToString() + " -- can not stop play --");
        }
    }

    class PlayState : IStates
    {
        public StatesContent Content { set; get; }

        public PlayState(StatesContent content)
        {
            this.Content = content;
        }

        public void download()
        {
            Console.WriteLine(this.ToString() + " -- can not download --");
        }

        public void stopDownload()
        {
            Console.WriteLine(this.ToString() + " -- cant not stop download --");
        }

        public void play()
        {
            Console.WriteLine(this.ToString() + " -- playing --");
            //Console.Read();
            stopPlay();
        }

        public void stopPlay()
        {
            Console.WriteLine(this.ToString() + " -- stop play --");
            this.Content.setState(EStateType.EStopPlay);
            this.Content.StopPlay();
        }
    }

    class StopPlayState : IStates
    {
        public StatesContent Content { set; get; }

        public StopPlayState(StatesContent content)
        {
            this.Content = content;
        }

        public void download()
        {
            Console.WriteLine(this.ToString() + " -- cant not download --");
        }

        public void stopDownload()
        {
            Console.WriteLine(this.ToString() + " -- cant not stop download --");
        }

        public void play()
        {
            Console.WriteLine(this.ToString() + " -- play --");
            this.Content.setState(EStateType.EPlay);
            this.Content.Play();
        }

        public void stopPlay()
        {
            //Console.WriteLine(this.ToString() + " -- cant not stop play --");
        }
    }
}
