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

        // souradnice kulicky
        int mintBallX, mintBallY;

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

            // nastaveni koule
            mintBallX = 0;
            mintBallY = 0;

            // nastaveni timeru
            tmrRedraw.Interval = 5;
            tmrRedraw.Enabled = true;
        }
        //
        // prekresleni obrazu pri ticku timeru
        //
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // nakresli kolecko na bitmapu
            mobjBitmapGraphics.FillEllipse(Brushes.CadetBlue, mintBallX, mintBallY, 10, 10);

            // posun kulicky
            mintBallX = mintBallX + 5;
            mintBallY = mintBallY + 5; 

            // prekresli bitmapu na platno
            mobjPlatnoGraphics.DrawImage(mobjMainBitmap, 0, 0);
        }
    }
}
