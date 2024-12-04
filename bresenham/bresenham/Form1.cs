using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bresenham
{
    public partial class Form1 : Form
    {
        bool[,] board = new bool[97, 48];
        Bitmap display = new Bitmap(775, 380);
        int size = 775 / 97;
        int clickedX = 0;
        int clickedY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void bresenham(int startX, int startY, int endX, int endY)
        {
            if (endX == startX && endY == startY)
            {
                return;
            }

            double gradient = Convert.ToDouble(endY - startY) / Convert.ToDouble(endX - startX);

            if (Math.Abs(gradient) <= 1)// if horizontal
            {
                if (startX < endX)// if right octant
                {
                    int y;
                    for (int x = startX; x <= endX; x++)
                    {
                        y = Convert.ToInt32(Math.Round(gradient * (x - startX))) + startY;
                        board[x, y] = true;
                    }
                }
                
                else// if left octant
                {
                    int y;
                    for (int x = startX; x >= endX; x--)
                    {
                        y = Convert.ToInt32(Math.Round(gradient * (x - startX))) + startY;
                        board[x, y] = true;
                    }
                }

            }

            else
            {
                if (startY < endY)// if upper octant
                {
                    int x;
                    for (int y = startY; y <= endY; y++)
                    {
                        x = Convert.ToInt32(Math.Round((y - startY) / gradient)) + startX;
                        board[x, y] = true;
                    }
                }
                else// if lower octant
                {
                    int x;
                    for (int y = startY; y >= endY; y--)
                    {
                        x = Convert.ToInt32(Math.Round((y - startY) / gradient)) + startX;
                        board[x, y] = true;
                    }
                }
            }

        }

        private void resetBoard()
        {
            for (int y = 0; y< 48; y++)
            {
                for (int x = 0; x< 97; x++)
                {
                    board[x, y] = false;
                }
            }
        }
        private void updateDisplay()
        {
            Graphics g = Graphics.FromImage(display);
            Graphics pctGraphics = pctDisplay.CreateGraphics();
            Brush white = new SolidBrush(Color.White);
            Brush grey = new SolidBrush(Color.Gray);
            Brush black = new SolidBrush(Color.Black);
            Brush currentBrush;
            g.FillRectangle(grey, 0, 0, 775, 380);
            for (int y = 0; y < 48; y++)
            {
                for (int x = 0; x < 97; x++)
                {
                    if (board[x, y])
                    {
                        currentBrush = black;
                    }
                    else
                    {
                        currentBrush = white;
                    }
                    g.FillRectangle(currentBrush, x * size, y * size, size-1, size-1);
                }
            }
            pctGraphics.DrawImage(display, 0, 0);
        }
        private void drawLine(int startX, int startY, int mouseX, int mouseY)
        {
            bresenham(startX / size, startY / size, mouseX / size, mouseY / size);
        }
        private void pctDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    drawLine(clickedX, clickedY, e.X, e.Y);
                    break;
            }
            updateDisplay();
            resetBoard();
        }

        private void pctDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            clickedX = e.X;
            clickedY = e.Y;
            //Console.WriteLine
        }
    }
}
