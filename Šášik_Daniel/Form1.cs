using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Šášik_Daniel
{
    public partial class Form1 : Form
    {

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  
            //e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
            Pen p = new Pen(Color.Black);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(p, 320, 0, 320, 480);
            g.DrawLine(p, 0, 240, 640, 240);


           
                if (impVal == true)
            {
                SolidBrush sb = new SolidBrush(Color.Black);
                p = new Pen(Color.Red);
                Point v1 = new Point(0 + 320, 0 + 240);
                Point v2 = new Point(100 + 320, 0 + 240);
                Point v3 = new Point(50 + 320, 80 + 240);
                Point[] points = { v1, v2, v3 };
                // g.DrawPolygon(p, points);
                //g.DrawPolygon(p, Coordinates(int.Parse(tbZakladna.Text), int.Parse(tbVyska.Text), int.Parse(tbPosunutieX.Text), int.Parse(tbPosunutieY.Text), 50, 80));
                //g.DrawPolygon(p,Coordinates(int.Parse(tbV1x.Text), int.Parse(tbV1y.Text), int.Parse(tbV2x.Text), int.Parse(tbV2y.Text), 50, 80));
                g.DrawPolygon(p, Coordinates(int.Parse(tbPosunutieX.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbVyska.Text) + int.Parse(tbPosunutieY.Text)));

                p = new Pen(Color.Black);
                //g.DrawPolygon(p, TransCoordinates(int.Parse(tbZakladna.Text), int.Parse(tbVyska.Text), int.Parse(tbPosunutieX.Text), int.Parse(tbPosunutieY.Text), 50, 80));
                g.DrawPolygon(p, TransCoordinates(int.Parse(tbPosunutieX.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbVyska.Text) + int.Parse(tbPosunutieY.Text)));

               // impVal = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        



    Boolean impVal = false;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public static int[] Multiply(int[] matrix1, int[,] matrix2)
        {
            var matrix1Cols = matrix1.GetLength(0);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            int[] product = new int[matrix2Cols];

            for (int matrix2_col = 0; matrix2_col < matrix2Cols; matrix2_col++)
            {
                for (int matrix1_col = 0; matrix1_col < matrix1Cols; matrix1_col++)
                {
                    product[matrix2_col] = 0;
                }
            }

            for (int matrix2_col = 0; matrix2_col < matrix2Cols; matrix2_col++)
            {
                for (int matrix1_col = 0; matrix1_col < matrix1Cols; matrix1_col++)
                {
                    product[matrix2_col] += matrix1[matrix1_col] * matrix2[matrix1_col, matrix2_col];
                }
            }

            return product;
        }

        public Point[] Coordinates(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {

            Point v1 = new Point(v1x + 320, v1y + 240);
            Point v2 = new Point(v2x + 320, v2y + 240);
            Point v3 = new Point(v3x + 320, v3y + 240);

            Point[] Mat = { v1, v2, v3 };
            return Mat;
        }

        public Point[] TransCoordinates(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y) {

            SolidBrush sb = new SolidBrush(Color.Black);
            Pen p = new Pen(Color.Red);
            Graphics g = pictureBox1.CreateGraphics();

            int startX = 320;
            int startY = 240;

            int[] matrix1 = { v1x, v1y };
            int[] matrix2 = { v2x, v2y };
            int[] matrix3 = { v3x, v3y };

            int[,] mTransOsaX = new int[2, 2] {{ 0, 0 },{ 0,0} };
       
            if (radioButton1.Checked)
            {
                mTransOsaX = new int[2, 2] { { -1, 0 }, { 0, -1 } } ;
            }
            if (radioButton2.Checked)
            {
                mTransOsaX = new int[2, 2] { { 1, 0 }, { 0, -1 } };
            }
            if (radioButton3.Checked)
            {
                mTransOsaX = new int[2, 2] { { -1, 0 }, { 0, 1 } };
            }


            int[] matrix1Trans = (int[])Multiply(matrix1, mTransOsaX).Clone();
            int[] matrix2Trans = (int[])Multiply(matrix2, mTransOsaX).Clone();
            int[] matrix3Trans = (int[])Multiply(matrix3, mTransOsaX).Clone();

            Point v1Trans = new Point(matrix1Trans[0] + startX, matrix1Trans[1] + startY);
            Point v2Trans = new Point(matrix2Trans[0] + startX, matrix2Trans[1] + startY);
            Point v3Trans = new Point(matrix3Trans[0] + startX, matrix3Trans[1] + startY);

            Point[] TransMat = { v1Trans , v2Trans, v3Trans}; 

            return TransMat;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        public bool typeNumber(String checkString)
        {

            int number = 0;
            return int.TryParse(checkString, out number);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int num = 4;
            //if (typeNumber(tbPosunutieX.Text))
            //{
            //    MessageBox.Show("chyba");
            //}
            try {
                SolidBrush sb = new SolidBrush(Color.Black);
                Pen p = new Pen(Color.Red);
                Graphics g = pictureBox1.CreateGraphics();
                //g.DrawPolygon(p, Coordinates(int.Parse(tbZakladna.Text), int.Parse(tbVyska.Text), int.Parse(tbPosunutieX.Text), int.Parse(tbPosunutieY.Text), 50, 80));
                g.DrawPolygon(p, Coordinates(int.Parse(tbPosunutieX.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbVyska.Text) + int.Parse(tbPosunutieY.Text)));

                Point v1 = new Point(0 + 320, 0 + 240);
                Point v2 = new Point(100 + 320, 0 + 240);
                Point v3 = new Point(50 + 320, 80 + 240);
                Point[] points = { v1, v2, v3 };
                //g.DrawPolygon(p, points);

                p = new Pen(Color.Black);
                g.DrawPolygon(p, TransCoordinates(int.Parse(tbPosunutieX.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbPosunutieY.Text),

                    int.Parse(tbPosunutieX.Text) + int.Parse(tbZakladna.Text),
                    int.Parse(tbVyska.Text) + int.Parse(tbPosunutieY.Text)));
            }
            catch
            {
                MessageBox.Show("Pravdepodobne ste nezadali cislo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            Pen p = new Pen(Color.Black);
            g.DrawLine(p, 320, 0, 320, 480);
            g.DrawLine(p, 0, 240, 640, 240);

            impVal = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
        }

        private void návodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program je pre znázornenie zrkadlenia pravouhlých trojuholníkov. \n " +
                "Na pravo môžete zadať zákdladňu, výšku a posun trojuholníka na osi x alebo y. \n " +
                "Tiež môžete jedno z troh druhov zrkadlení pomocou radiobuttonov. \n " +
                "Veľkosť je 640x480 myslím, takže maximalne čo to dokáže zobraziť od stredu je 320 na x osi a 240 na y osi." +
                "Na koniec ostáva tlačítko zmazať a kresliť.");
        }

        private void informácieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alpha Verzia 1.0 \n Jednoduchý program pre znázornenie zrkadlenia " +
                "\n autor Daniel Šášik AIA 02 \n Zadanie 1 PGCSO \n Vedúci projektu doc. Ing. Jozef Vaský, CSc.");
        }

        private void zadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Toto zadanie by sa určite dalo vylepšiť napr. esteticky ale hlavne" +
                " v oblasti kreslenia toho trojuholnika lebo teraz ho môžeme nakresliť iba vodorovne" +
                " zaťiaľ čo taký istý trojuhoľník by mohol byť na krivo alebo pootočený ale" +
                " nebolo to definované v zadaní. Takýto kód by bol určite náročnejší a dlhší ošetriť všetky " +
                "pootočené trojuholníky či sú pravouhlé. A nakoniec ty to bolo asi lepšie nakresliť cez bitmapy +" +
                "a potom by tie všetky nakreslené objekty mohli vždy ostate pri minimalizácii okna ale takto to dopadne" +
                "keď sú ľudia demotivovaný pandémiou, neustále zatvorený doma a tiež je lepšie v keď sa normálne chodí do školi \n");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Maximized)
                impVal = true;
        }
    }
}