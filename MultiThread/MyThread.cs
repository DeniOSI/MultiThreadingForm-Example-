using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThread
{
    class MyThread
    {
   public List<string> valuestate;
        List<Thread> threadlist;
        int _threadcount;
        Mydelegate _md;
        string _threadname;
        public MyThread(int threadcount, Mydelegate md, string name)
        {
            _threadcount = threadcount;
            _md = md;
            _threadname = name;

        }
        public void Restart()
        {
            foreach(var value in threadlist)
            {
                if ( (int)value.ThreadState == 68 )
                 value.Resume();
            }
        }
        public void Pause()
        {

            foreach(var value in threadlist)
            {
               
                value.Suspend();
            }
        }
        public void Run()
        {
            threadlist = new List<Thread>();
            for(int i=0; i< 10; i++)
            {
              var _thread = new Thread(new ThreadStart(MyFunc));
                _thread.IsBackground = true;
                threadlist.Add(_thread);
                threadlist[i].Start();
            }
        }
       
        public void Abort()
        {
            foreach(var value in threadlist)
            {
                value.Abort();
                
            }
            threadlist.Clear();
        }
        public void MyFunc()
        {
            int i = 0;
            while(true)
            {
                _md(i.ToString()+_threadname);
                i++;
             Thread.Sleep(100);
            }   
        }
        public void GetValueState()
        {
            valuestate = new List<string>();
            foreach(var value in threadlist)
            {
                valuestate.Add(value.ThreadState.ToString());
            }
        }
    }
}
