using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbouraniSkoly2025
{
    internal class clsKulicka
    {
        // kreslici platno
        Graphics mobjPlatno;

        // souradnice kulicky
        public int mintBallX, mintBallY;
        public int mintBallRadius;
        public Rectangle mobjBallRect;

        // posun kulicky
        public int mintBallPosunX, mintBallPosunY;
        public int mintRandomPosun;
        Random rndPosun;

        // trida cihly
        clsCihla mobjCihla;

        int x = 0;

        public bool tmrStop = false;

        //
        // konstruktor
        //
        public clsKulicka(int intBallX, int intBallY, int intBallRadius, int intBallPosunX, int intBallPosunY, Graphics objPlatno)
        {
            mintBallX = intBallX;
            mintBallY = intBallY;
            mintBallRadius = intBallRadius;
            mintBallPosunX = intBallPosunX;
            mintBallPosunY = intBallPosunY;
            mobjPlatno = objPlatno;
        }

        //
        // nakresleni koule
        //
        public void DrawBall()
        {
            mobjPlatno.FillEllipse(Brushes.BlueViolet, mintBallX, mintBallY, mintBallRadius, mintBallRadius);
        }

        //
        // posunuti koule
        //
        public void MoveBall()
        {
            // posun kulicky
            mintBallX = mintBallX + mintBallPosunX;
            mintBallY = mintBallY + mintBallPosunY;
            mobjBallRect = new Rectangle(mintBallX, mintBallY, mintBallRadius, mintBallRadius);
        }
        //
        // kolize koule s hranami 
        //
        public void KolizeBall()
        {
            // kolize s hranami obrazovky
            if (mintBallY > mobjPlatno.VisibleClipBounds.Height - mintBallRadius)
                tmrStop = true;

            if (mintBallY < 0)
                mintBallPosunY = mintBallPosunY * (-1);

            if (mintBallX > mobjPlatno.VisibleClipBounds.Width - mintBallRadius)
                mintBallPosunX = mintBallPosunX * (-1);

            if (mintBallX < 0)
                mintBallPosunX = mintBallPosunX * (-1);  
        }

        //
        // kolize koule s plosinou
        //
        public void KolizeBallAndPlosina(int PlosinaX, int PlosinaY, int PlosinaWidth)
        {
            if (mintBallY + mintBallRadius > PlosinaY)
            {
                if (mintBallX > PlosinaX)
                {
                    if (mintBallX < PlosinaX + PlosinaWidth)
                    {
                        /*rndPosun = new Random();
                        mintRandomPosun = rndPosun.Next(-2, 2);*/
                        mintBallPosunY = mintBallPosunY * (-1);
                        /*mintBallPosunX = mintBallPosunX + mintRandomPosun;*/
                    }
                }
            }
        }   

       
    }
}
