using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Xml.Linq;
using System.Xml;

namespace FrenchGame
{
    public partial class compumatch : Form
    {
        int xN = 0;
        int xT = -1;
        int yN = 0;
        int yT = -1;

        public compumatch()
        {
            InitializeComponent();
            MessageBox.Show("In this game, each player will have 5 words in a random order to label an image with. " +
                "Player 1 will go first, player 4 will go last. All players except the player whose turn it is should NOT" +
                " look at the screen.", "Instructions:", MessageBoxButtons.OK);
            LoadFromXML();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            xT = -1;
            yT = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Get mouse position
            xN = Cursor.Position.X;
            yN = Cursor.Position.Y;

            //Check if we have set the previous position yet, or if this is our first loop
            if(xT != -1 && yT != -1)
            {
                //We have, so move the object a scaled amount
                int distMoveX = xN - xT;
                int distMoveY = yN - yT;
                label1.Left = label1.Left + distMoveX;
                label1.Top = label1.Top + distMoveY;
            }

            xT = xN;
            yT = yN;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Get mouse position
            xN = Cursor.Position.X;
            yN = Cursor.Position.Y;

            //Check if we have set the previous position yet, or if this is our first loop
            if (xT != -1 && yT != -1)
            {
                //We have, so move the object a scaled amount
                int distMoveX = xN - xT;
                int distMoveY = yN - yT;
                label2.Left = label2.Left + distMoveX;
                label2.Top = label2.Top + distMoveY;
            }

            xT = xN;
            yT = yN;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Get mouse position
            xN = Cursor.Position.X;
            yN = Cursor.Position.Y;

            //Check if we have set the previous position yet, or if this is our first loop
            if (xT != -1 && yT != -1)
            {
                //We have, so move the object a scaled amount
                int distMoveX = xN - xT;
                int distMoveY = yN - yT;
                label3.Left = label3.Left + distMoveX;
                label3.Top = label3.Top + distMoveY;
            }

            xT = xN;
            yT = yN;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //Get mouse position
            xN = Cursor.Position.X;
            yN = Cursor.Position.Y;

            //Check if we have set the previous position yet, or if this is our first loop
            if (xT != -1 && yT != -1)
            {
                //We have, so move the object a scaled amount
                int distMoveX = xN - xT;
                int distMoveY = yN - yT;
                label4.Left = label4.Left + distMoveX;
                label4.Top = label4.Top + distMoveY;
            }

            xT = xN;
            yT = yN;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Enabled = true;
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            timer2.Enabled = false;
            xT = -1;
            yT = -1;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            timer3.Enabled = true;
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
            xT = -1;
            yT = -1;
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            timer4.Enabled = true;
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            timer4.Enabled = false;
            xT = -1;
            yT = -1;
        }

        private void LoadFromXML()
        {

        }
    }
}
