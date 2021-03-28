using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Sorts4
{
    public partial class Form1 : Form
    {
        struct wand
        {
            public int number, sizeW, x;
            public wand(int number, int sizeW, int x)
            {
                this.number = number;
                this.sizeW = sizeW;
                this.x = x;
            }   
        };
        const int N = 200;
        wand[] arr = new wand[N];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();

            Bitmap bmp = new Bitmap(1500, 600);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.DarkCyan, 2);
            pictureBox1.Image = bmp;
            for (int j=0; j<N; j++) //заполняем массив структурными объектами
            {
                int a = rnd.Next(1, 600);
                arr[j] = new wand(j, a, (j+1)*5);
            }

            int t, t1;
            WSort();    
            async void OnTimedEvent()
            { 
                pictureBox1.Image = null;
                bmp = new Bitmap(1500, 600);
                graph = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                for (int q = 0; q < N; q++)
                {
                    graph.DrawLine(pen, arr[q].x, 600, arr[q].x, 600-arr[q].sizeW);
                }
                pictureBox1.Image = bmp;
            }
            wand tmp;
            async void WSort(){
                for (int i = 0; i < N; i++)
                {
                    for (int j = i; j < N; j++)
                    {
                        if (arr[i].sizeW < arr[j].sizeW)
                        {
                            
                            t = arr[i].sizeW;
                            t1 = arr[j].sizeW;
                            arr[i].sizeW = t1;
                            arr[j].sizeW = t;
                 
                            OnTimedEvent();
                            await Task.Delay(1);
                        }
                    } 
                }
            }
        }
    }
}
