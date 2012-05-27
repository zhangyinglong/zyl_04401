using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.state
{
    class StatesContent
    {
        public ArrayList arrayList { set; get; }
        public IStates CurrentState { set; get; }

        public StatesContent()
        {
            this.arrayList = new ArrayList();
        }

        public void addState(IStates state)
        {
            this.arrayList.Add(state);
            this.CurrentState = (IStates)this.arrayList[0];
        }

        public void setState(EStateType index)
        {
            this.CurrentState = (IStates)this.arrayList[(int)index];
        }

        public void download()
        {
            this.CurrentState.download();
        }

        public void StopDownload()
        {
            this.CurrentState.stopDownload();
        }

        public void Play()
        {
            this.CurrentState.play();
        }

        public void StopPlay()
        {
            this.CurrentState.stopPlay();
        }
    }
}
