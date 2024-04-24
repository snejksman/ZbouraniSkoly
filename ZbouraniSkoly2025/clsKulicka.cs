using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbouraniSkoly2025
{
    internal class clsKulicka
    {
        // kreslici platno
        Graphics mobjPlatno;

        // souradnice kulicky
        int mintBallX, mintBallY;
        int mintBallRadius;

        // posun kulicky
        int mintBallPosunX, mintBallPosunY;

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
        }

        //
        // kolize koule
        //
        public void KolizeBall()
        {
            // kolize s hranami obrazovky
            if (mintBallY > mobjPlatno.VisibleClipBounds.Height - mintBallRadius)
                mintBallPosunY = mintBallPosunY * (-1);

            if (mintBallY < 0)
                mintBallPosunY = mintBallPosunY * (-1);

            if (mintBallX > mobjPlatno.VisibleClipBounds.Width - mintBallRadius)
                mintBallPosunX = mintBallPosunX * (-1);

            if (mintBallX < 0)
                mintBallPosunX = mintBallPosunX * (-1);

            // kolize s plosinou
            
        }
    }
}
