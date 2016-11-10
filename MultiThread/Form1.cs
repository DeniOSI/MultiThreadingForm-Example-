using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread
{
    public delegate void Mydelegate(string str);
    public partial class Form1 : Form
    {
        MyThread mt;
        Mydelegate md;
        MyThread mythread;
        public Form1()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            md = Sd;
            mythread = new MyThread(10, md, "first");
            mt = new MyThread(10, md, "second");
            mt.Run();
            mythread.Run();


        }
        public void Sd(string str)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(md, str);
                return;
            }
            this.richTextBox1.AppendText( str + "\n" );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mt.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mt.Pause();
            mythread.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            mt.Restart();
            mythread.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mt.GetValueState();
            listBox1.Items.Clear();
            foreach (var item in mt.valuestate)

            {
                listBox1.Items.Add(item);
            }
        }
    }
}
