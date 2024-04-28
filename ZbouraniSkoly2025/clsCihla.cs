using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbouraniSkoly2025
{
    internal class clsCihla
    {

        // kreslici platno
        Graphics mobjGrafika;

        // souradnice kulicky
        int mintCihlaX, mintCihlaY;
        int mintCihlaWidth, mintCihlaHeight;
        int mintCihlaRozestup;

        // barva cihel
        Brush mobjCihlaBrush;

        //
        // konstruktor
        //
        public clsCihla(int intCihlaX, int intCihlaY, int intCihlaWidth, int intCihlaHeight, int intCihlaRozestup, Graphics objGrafika) 
        {
            mintCihlaHeight = intCihlaHeight;
            mintCihlaWidth = intCihlaWidth;
            mintCihlaX = intCihlaX;
            mintCihlaY = intCihlaY;
            mobjGrafika = objGrafika;
            mobjCihlaBrush = new SolidBrush(Color.OrangeRed);
            mintCihlaRozestup = intCihlaRozestup;
        }
        public void DrawCihla(int length)
        {
            mobjGrafika.FillRectangle(mobjCihlaBrush, mintCihlaX, mintCihlaY, mintCihlaWidth, mintCihlaHeight);

        }
    }
}
