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
        int mintBallWidth, mintBallHeight;

        // posun kulicky
        int mintBallPosunX, mintBallPosunY;

        //
        // konstruktor
        //
        public clsKulicka(int intBallX, int intBallY, int intBallWidth, int intBallHeight, int intBallPosunX, int intBallPosunY, Graphics objPlatno)
        {
            mintBallX = intBallX;
            mintBallY = intBallY;
            mintBallWidth = intBallWidth;
            mintBallHeight = intBallHeight;
            mintBallPosunX = intBallPosunX;
            mintBallPosunY = intBallPosunY;
            mobjPlatno = objPlatno;
        }

        //
        // nakresleni koule
        //
        public void DrawBall()
        {
            mobjPlatno.FillEllipse(Brushes.BlueViolet, mintBallX, mintBallY, mintBallWidth, mintBallHeight);
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

        public void KolizeBall()
        {
            if (mintBallY > mobjPlatno.VisibleClipBounds.Height - mintBallHeight)
                mintBallPosunY = mintBallPosunY * (-1);

            if (mintBallY < 0)
                mintBallPosunY = mintBallPosunY * (-1);

            if (mintBallX > mobjPlatno.VisibleClipBounds.Width - mintBallWidth)
                mintBallPosunX = mintBallPosunX * (-1);

            if (mintBallX < 0)
                mintBallPosunX = mintBallPosunX * (-1);
        }
    }
}
