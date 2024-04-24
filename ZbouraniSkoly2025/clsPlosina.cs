using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbouraniSkoly2025
{
    internal class clsPlosina
    {
        // grafika
        Graphics mobjGrafika;

        // souradnice plosiny
        int mintPlosinaX, mintPlosinaY;
        int mintPlosinaWidth, mintPlosinaHeight;

        // posun plosiny
        int mintPlosinaPosun;

        // barva plosiny
        Brush mobjPlosinaBrush;

        //
        // konstruktor
        //
        public clsPlosina(int intPlosinaX, int intPlosinaY, int intPlosinaWidth, int intPlosinaHeight, int intPlosinaPosun, Graphics objGrafika)
        {
            mintPlosinaX = intPlosinaX;
            mintPlosinaY = intPlosinaY;
            mintPlosinaWidth = intPlosinaWidth;
            mintPlosinaHeight = intPlosinaHeight;
            mintPlosinaPosun = intPlosinaPosun;
            mobjGrafika = objGrafika;
            mobjPlosinaBrush = new SolidBrush(Color.Green);
        }

        // posune souradnice plosiny
        public void MovePlosina()
        {
            mintPlosinaX = mintPlosinaX + mintPlosinaPosun;
        }

        // nakresli plosinu
        public void DrawPlosina()
        {
            mobjGrafika.FillRectangle(mobjPlosinaBrush, mintPlosinaX, mintPlosinaY, mintPlosinaWidth, mintPlosinaHeight);
        }

        // kolize plosiny s kulickou
        public void KolizePlosina()
        {

        }

        // ovladani plosiny
        public void PosunRight()
        {
            if (mintPlosinaPosun < 0)
            {
                mintPlosinaPosun = mintPlosinaPosun * (-1);
            }
        }
        public void PosunLeft()
        {
            if (mintPlosinaPosun > 0)
            {
                mintPlosinaPosun = mintPlosinaPosun * (-1);
            }
        }
    }
}
