using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        // kulicka
        clsKulicka mobjBall;



        // souradnice plosiny
        int mintPlosinaX, mintPlosinaY;
        int mintPlosinaWidth, mintPlosinaHeight;



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
            mobjBall = new clsKulicka(2, 2, 13, 13, 3, 4, mobjBitmapGraphics);

            // nastaveni plosiny
            mintPlosinaX = 500;
            mintPlosinaY = 500;
            mintPlosinaWidth = 150;
            mintPlosinaHeight = 20;

            // nastaveni timeru
            tmrRedraw.Interval = 30;
            tmrRedraw.Enabled = true;
        }
        //
        // prekresleni obrazu pri ticku timeru
        //
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // vymazat predchozi kulicku
            mobjBitmapGraphics.Clear(Color.White);

            // nakresli kolecko na bitmapu
            mobjBall.DrawBall();

            // posun kulicky
            mobjBall.MoveBall();

            // prekresli bitmapu na platno
            mobjPlatnoGraphics.DrawImage(mobjMainBitmap, 0, 0);

            // kolize
            mobjBall.KolizeBall();
        }

        //
        // plosina
        //
        private void tmrPlosina_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs Klavesa)
        {

            switch (Klavesa.KeyCode) 
            {
                case Keys.Left:

                    break;

            }
        }
    }
}
