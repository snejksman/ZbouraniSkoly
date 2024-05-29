﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbouraniSkoly2025
{
    public partial class Form1 : Form
    {
      

        // hlavni nastroje pro 
        Bitmap mobjMainBitmap;
        Graphics mobjBitmapGraphics;

        // grafika pro picturebox
        Graphics mobjPlatnoGraphics;

        // vytvoreni kulicky
        clsKulicka mobjBall;

        // vytvoreni plosiny
        clsPlosina mobjPlosina;

        // vytvoreni cihly
        clsCihla mobjCihla;

        // mackam klavesnici
        bool mbjOvladam;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            // vytvoreni grafiky v pictureboxu
            mobjPlatnoGraphics = pbPlatno.CreateGraphics();
            
            // vytvoreni hlavni grafiky
            mobjMainBitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            mobjBitmapGraphics = Graphics.FromImage(mobjMainBitmap);

            // nastaveni kulicky
            mobjBall = new clsKulicka(350, 350, 13, 3, 3, mobjBitmapGraphics);

            // nastaveni plosiny
            mobjPlosina = new clsPlosina((int)(mobjPlatnoGraphics.VisibleClipBounds.Width / 2), 500, 100, 10, 6, mobjBitmapGraphics);

            // nastaveni cihel
            mobjCihla = new clsCihla(7, 4, 100, 100, 120, 40, 130, 50, mobjBitmapGraphics);

            // nastaveni timeru
            tmrRedraw.Interval = 30;
            tmrRedraw.Enabled = true;
        }

        //
        // prekresleni obrazu pri ticku timeru
        //
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // vymazat platno a grafiku
            mobjBitmapGraphics.Clear(Color.White);

            // nakresli kulicku na bitmapu a jeji kolize
            mobjBall.DrawBall();
            mobjBall.MoveBall();
            mobjBall.KolizeBall();

            // nakresli plosinu a jeji kolize
            mobjPlosina.DrawPlosina();
            if (mbjOvladam == true)
                mobjPlosina.MovePlosina();
            mobjBall.KolizeBallAndPlosina(mobjPlosina.pintPlosinaX, mobjPlosina.pintPlosinaY, mobjPlosina.pintPlosinaWidth);

            // nakresli cihly
            mobjCihla.DrawCihla();
            TestKolizeBallCihla();

            // nakresleni na platno
            mobjPlatnoGraphics.DrawImage(mobjMainBitmap, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs Klavesa)
        {
            try
            {
                switch (Klavesa.KeyCode)
                {
                    case Keys.Left:
                        mobjPlosina.PosunLeft();
                        mbjOvladam = true;
                        break;
                    case Keys.Right:
                        mobjPlosina.PosunRight();
                        mbjOvladam = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                mbjOvladam = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            mbjOvladam = false;
        }
        //
        // kolize kulicky s cihalmi - nevim proc nefunguje v clsKulicce ale tady funguje tak to necham tady protoze sem linej to predelavat
        //
        /*public void KolizeBallAndCihla()
        {
            foreach (Rectangle rect in mobjCihla.listRect)
            {
                if (mobjBall.mintBallY + mobjBall.mintBallRadius < rect.Y + rect.Height)
                {
                    if (mobjBall.mintBallX > rect.X)
                    {
                        if (mobjBall.mintBallX < rect.X + rect.Width)
                        {
                            mobjBall.mintBallPosunY = mobjBall.mintBallPosunY * (-1);
                            mobjBall.mintBallPosunX = mobjBall.mintBallPosunX + mobjBall.mintRandomPosun;

                        }
                    }
                }
            }  
        }*/

        //
        // jina kolize kulicky s cihlou - ma to byt jednodussi ale proste to nefunguje a nemam tuseni proc kdyz to proste funovat ma 
        //
        private void TestKolizeBallCihla()
        {
            foreach (Rectangle rect in mobjCihla.listRect)
            {
                Rectangle lobjPrekryv;
                lobjPrekryv = Rectangle.Intersect(rect, mobjBall.mobjBallRect);
                if (lobjPrekryv.Width > 0 && lobjPrekryv.Height > 0)
                {
                    mobjBall.mintBallPosunY = mobjBall.mintBallPosunY * (-1);
                    mobjBall.mintBallPosunX = mobjBall.mintBallPosunX + mobjBall.mintRandomPosun;
                }
            }
        }
    }
}
