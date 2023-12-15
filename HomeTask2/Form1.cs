using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HomeTask2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }
        int num1, num2;
        public void ThreadMetod(object sender)
        {
            if(textBox1.Text == "") num1 = 2;
            else
                num1 = int.Parse(textBox1.Text);
            num2 = int.Parse(textBox2.Text);
            for (int i = num1; i < num2; i++)
            {
                (sender as TextBox).Text += "поток" + "  "
                    + Convert.ToString(i) + "\r\n";
                Thread.Sleep(500);
            }
        }
        
        public void ThreadMetod2(object sender)
        {
            num1 = int.Parse(textBox1.Text);
            num2 = int.Parse(textBox2.Text);
            int prev = 0;
            int current = 1;
            int temp;
            for (int i = 0; i <= num2; i++)
            {                
                temp = current;
                current = current + prev;
                prev = temp;
                if (current > num1 && current < num2)
                {
                    (sender as TextBox).Text += "поток" + "  "
                    + Convert.ToString(current) + "\r\n";
                    Thread.Sleep(500);
                }
                
            }
        }
        Thread thread;
        Thread thread1;
        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(ThreadMetod);
            thread.Start((object)textBox3);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(ThreadMetod2);
            thread1.Start((object)textBox3);
            
        }
        [Obsolete]
        private void button3_Click(object sender, EventArgs e)
        {
            //if(thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.Background)
                thread.Suspend();
            
        }
        [Obsolete]
        private void button4_Click(object sender, EventArgs e)
        {
            if (!(thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.Background))
                thread.Resume();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
        [Obsolete]
        private void button7_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
        }
        [Obsolete]
        private void button8_Click(object sender, EventArgs e)
        {
            thread1.Resume();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            thread1.Abort();
        }
    }
}
