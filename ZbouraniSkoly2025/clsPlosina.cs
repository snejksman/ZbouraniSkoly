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
        //integery pro pouziti venku
        public int pintPlosinaX, pintPlosinaY, pintPlosinaWidth;

        // grafika
        Graphics mobjGrafika;

        // souradnice plosiny
        int mintPlosinaX, mintPlosinaY;
        int mintPlosinaWidth, mintPlosinaHeight;

        // posun plosiny
        int mintPlosinaPosun;

        // barva plosiny
        Brush mobjPlosinaBrush;

        // trida plosiny pro kolize
        clsKulicka mobjKulicka;

        //
        // konstruktor
        //
        public clsPlosina(int intPlosinaX, int intPlosinaY, int intPlosinaWidth, int intPlosinaHeight, int intPlosinaPosun, Graphics objGrafika)
        {
            pintPlosinaX = mintPlosinaX = intPlosinaX;
            pintPlosinaY = mintPlosinaY = intPlosinaY;
            pintPlosinaWidth = mintPlosinaWidth = intPlosinaWidth;
            mintPlosinaHeight = intPlosinaHeight;
            mintPlosinaPosun = intPlosinaPosun;
            mobjGrafika = objGrafika;
            mobjPlosinaBrush = new SolidBrush(Color.Green);
            // nastaveni kulicky
            mobjKulicka = new clsKulicka(2, 2, 13, 3, 3, mobjGrafika);

        }

        // posune souradnice plosiny
        public void MovePlosina()
        {
            mintPlosinaX = mintPlosinaX + mintPlosinaPosun;
            pintPlosinaX = mintPlosinaX;
        }

        // nakresli plosinu
        public void DrawPlosina()
        {
            mobjGrafika.FillRectangle(mobjPlosinaBrush, mintPlosinaX, mintPlosinaY, mintPlosinaWidth, mintPlosinaHeight);
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
