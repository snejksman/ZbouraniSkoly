using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbouraniSkoly2025
{
    internal class clsCihla
    {
        // list vsech cihel - mam to delat nejak jinak ale nechtelo se mi to opravovat tak se to naucim takhle
        public List<Rectangle> listRect = new List<Rectangle>();
        public int pintPocetCihel;

        // kreslici platno
        Graphics mobjGrafika;

        Rectangle mobjCihlaRect;

        // souradnice cihly
        int mintCihlaX, mintCihlaY;
        int mintCihlaWidth, mintCihlaHeight;
        int mintCihlaRozestupX, mintCihlaRozestupY;

        

        // barva cihel
        Brush mobjCihlaBrush;
        Brush mobjCihlaClear;

        //
        // konstruktor
        //
        public clsCihla(int intPocetCihelX, int intPocetCihelY, int intCihlaX, int intCihlaY, int intCihlaWidth, int intCihlaHeight, int intCihlaRozestupX, int intCihlaRozestupY, Graphics objGrafika) 
        {
            mintCihlaHeight = intCihlaHeight;
            mintCihlaWidth = intCihlaWidth;
            mintCihlaX = intCihlaX;
            mintCihlaY = intCihlaY;
            mobjGrafika = objGrafika;
            mobjCihlaBrush = new SolidBrush(Color.OrangeRed);
            mintCihlaRozestupX = intCihlaRozestupX;
            mintCihlaRozestupY = intCihlaRozestupY;
            mobjCihlaRect = new Rectangle(mintCihlaX, mintCihlaY, mintCihlaWidth, mintCihlaHeight);


            // vytvoreni vsech cihel - tim jinym zpusobem to funguje asi lip protoze nepotrebuju 2 promenny a cihly se poskladaj samy ale tohle jsem si napsal sam takze to je objektivne lepsi rip bozo
            for (int x = 0; x < intPocetCihelX; x++)
            {
                mobjCihlaRect.X = x * (mintCihlaWidth + mintCihlaRozestupX) + mintCihlaX;
                for (int y = 0; y < intPocetCihelY; y++)
                {
                    mobjCihlaRect.Y = y * (mintCihlaHeight + mintCihlaRozestupY) + mintCihlaY;
                    listRect.Add(mobjCihlaRect);
                }
            }

        }
        //
        // nakresleni cihel
        //
        public void DrawCihla()
        {
            foreach (Rectangle rect in listRect)
            {
                mobjGrafika.FillRectangle(mobjCihlaBrush, rect);
                pintPocetCihel = listRect.Count;
            }
        }
    }
}
