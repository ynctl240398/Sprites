using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sprites
{
    public partial class Form1 : Form
    {
        private Bitmap sprite;
        private Bitmap backbuffer;
        private Timer timer;
        public Graphics graphics;
        private int index;
        private int curframecolumn;
        private int curframerow;
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            backbuffer = new Bitmap(this.ClientSize.Width,this.ClientSize.Height);
            sprite = new Bitmap("..\\..\\Sprite.png");


            index = 0;
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 60;
            timer.Tick += new EventHandler(timer_Tick);
        }


        public void render()
        {
            graphics = Graphics.FromImage(backbuffer);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            curframecolumn = index % 5;
            curframerow = index / 4;
            graphics.DrawImage(sprite, 120, 120, new Rectangle(curframecolumn * 64, curframerow * 64, 64, 64), GraphicsUnit.Pixel);
            graphics.Dispose();
            index++;

            if (index > 20)
                index = 0;
            else index++;

        }


        private void timer_Tick(object sender, EventArgs e)
        {
     
            render();
            Point x = new Point(0, 0);
            graphics.DrawImageUnscaled(backbuffer, x);




        }



    }
}
