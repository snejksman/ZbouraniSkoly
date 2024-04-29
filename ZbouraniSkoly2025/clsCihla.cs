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

        Rectangle[] mobjRectangle;

        // souradnice cihly
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

            Rectangle[] objRectangle = 
                {
                    new Rectangle(mintCihlaX, mintCihlaY, mintCihlaWidth, mintCihlaHeight), 
                    new Rectangle(mintCihlaX + mintCihlaRozestup, mintCihlaY, mintCihlaWidth, mintCihlaHeight),
                    new Rectangle(mintCihlaX + mintCihlaRozestup * 2, mintCihlaY, mintCihlaWidth, mintCihlaHeight),
                    new Rectangle(mintCihlaX + mintCihlaRozestup * 3, mintCihlaY, mintCihlaWidth, mintCihlaHeight),
                    new Rectangle(mintCihlaX + mintCihlaRozestup * 4, mintCihlaY, mintCihlaWidth, mintCihlaHeight),
                };
            mobjRectangle = objRectangle;
        }
        public void DrawCihla()
        {
            
            mobjGrafika.FillRectangles(mobjCihlaBrush, mobjRectangle);

        }
    }
}
