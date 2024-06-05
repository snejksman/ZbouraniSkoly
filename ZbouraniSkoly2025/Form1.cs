using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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

        // vytvoreni kulicky
        clsKulicka mobjBall;

        // vytvoreni plosiny
        clsPlosina mobjPlosina;

        // vytvoreni cihly
        clsCihla mobjCihla;

        // mackam klavesnici
        public bool mbjOvladam;

        // veci pro mazani cihel
        bool mbjCihlaNeni;
        int mintRectCislo;

        // bool pro start hry
        bool mbjStart;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // startovaci okynko
            DialogResult Start = MessageBox.Show("START", "Bourani Skoly", MessageBoxButtons.OKCancel);
            switch (Start)
            {
                case DialogResult.OK:
                    tmrRedraw.Enabled = true;
                    break;
                case DialogResult.Cancel:
                    Application.Exit();
                    break;
            }
            // vytvoreni grafiky v pictureboxu
            mobjPlatnoGraphics = pbPlatno.CreateGraphics();

            // vytvoreni hlavni grafiky
            mobjMainBitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            mobjBitmapGraphics = Graphics.FromImage(mobjMainBitmap);

            // nastaveni kulicky
            mobjBall = new clsKulicka(600, 350, 13, 4, 4, mobjBitmapGraphics);

            // nastaveni plosiny
            mobjPlosina = new clsPlosina((int)(mobjPlatnoGraphics.VisibleClipBounds.Width / 2), 550, 100, 10, 8, mobjBitmapGraphics);

            // nastaveni cihel
            mobjCihla = new clsCihla(8, 5, 20, 20, 120, 40, 20, 10, mobjBitmapGraphics);

            // nastaveni timeru
            tmrRedraw.Interval = 30;

        }

        //
        // prekresleni obrazu pri ticku timeru
        //
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // vymazat platno a grafiku
            mobjBitmapGraphics.Clear(Color.White);

            // nakresli kulicku na bitmapu a jeji kolize
            mobjBall.DrawBall();
            mobjBall.MoveBall();
            mobjBall.KolizeBall();

            // nakresli plosinu a jeji kolize
            mobjPlosina.DrawPlosina();
            if (mbjOvladam == true)
            {
                mobjPlosina.MovePlosina();
            }
            mobjBall.KolizeBallAndPlosina(mobjPlosina.pintPlosinaX, mobjPlosina.pintPlosinaY, mobjPlosina.pintPlosinaWidth);

            // nakresli cihly
            mobjCihla.DrawCihla();
            TestKolizeBallCihla();

            // nakresleni na platno
            mobjPlatnoGraphics.DrawImage(mobjMainBitmap, 0, 0);

            // vyhra nebo prohra
            if (mobjBall.mbjGameOver == true)
            {
                tmrRedraw.Enabled = false;
                GameOver();
            }
            if (mobjCihla.mbjGameWin == true)
            {
                tmrRedraw.Enabled = false;
                GameWin();
            }
        }

        //
        // ovladani plosiny
        //
        private void Form1_KeyDown(object sender, KeyEventArgs Klavesa)
        {
            try
            {
                switch (Klavesa.KeyCode)
                {
                    case Keys.Left:
                        mobjPlosina.PosunLeft();

                        // zastavuje plosiny proti vyjeti doleva
                        if (mobjPlosina.pintPlosinaX < 0)
                        {
                            mbjOvladam = false;
                        }
                        else 
                        { 
                            mbjOvladam = true; 
                        }
                        break;
                    case Keys.Right:
                        mobjPlosina.PosunRight();

                        // zastavuje plosiny proti vyjeti doleva
                        if (mobjPlosina.pintPlosinaX + mobjPlosina.pintPlosinaWidth > mobjPlatnoGraphics.VisibleClipBounds.Width)
                        {
                            mbjOvladam = false;
                        }
                        else
                        {
                            mbjOvladam = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                mbjOvladam = false;
            }
        }

        // zrusi pohyb
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            mbjOvladam = false;
        }

        //
        // kolize cihel s kulickou
        //
        private void TestKolizeBallCihla()
        {

            // plati pro kazdy rect v listu
            foreach (Rectangle rect in mobjCihla.listRect)
            {
                Rectangle lobjPrekryv;

                // lobjprekryv je rectangle ktery je prostor prekryti dvou jinych rectanglu
                lobjPrekryv = Rectangle.Intersect(rect, mobjBall.mobjBallRect);

                // kdyz jsou rozmery prekryvu vetsi jak 0, zaznamena se kolize
                if (lobjPrekryv.Width > 0 && lobjPrekryv.Height > 0)
                {
                    mobjBall.mintBallPosunY = mobjBall.mintBallPosunY * (-1);
                    mobjBall.mintBallPosunX = mobjBall.mintBallPosunX + mobjBall.mintRandomPosun;

                    // smaze jeden z rectanglu z listu
                    mintRectCislo = mobjCihla.listRect.IndexOf(rect);
                    mbjCihlaNeni = true;
                }
            }

            // odstrani jeden rectangle z listu
            if (mbjCihlaNeni == true)
            {
                mobjCihla.listRect.RemoveAt(mintRectCislo);
                mbjCihlaNeni = false;
            }
            
        }

        // popup okynko s prohrou
        public void GameOver()
        {
            DialogResult Restartovat = MessageBox.Show("chces bourat znova?", "skola porad stoji (prohra)", MessageBoxButtons.YesNo);
            switch (Restartovat)
            {
                case DialogResult.Yes:
                    Application.Restart();
                    break;
                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        // popup okynko s vyhrou
        public void GameWin()
        {
            DialogResult Restartovat = MessageBox.Show("chces bourat znova?", "skola uz nestoji (vyhra)", MessageBoxButtons.YesNo);
            switch (Restartovat)
            {
                case DialogResult.Yes:
                    Application.Restart();
                    break;
                case DialogResult.No:
                    this.Close();
                    break;
            }
        }
    }
}
