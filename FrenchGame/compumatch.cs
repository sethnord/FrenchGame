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

        float _time = 0.0f;

        public compumatch()
        {
            InitializeComponent();
            MessageBox.Show("In this game, each player will be shown 5 images that they will select the correct word for. " +
                "Player 1 will go first, player 4 will go last. All players except the player whose turn it is should NOT" +
                " look at the screen.", "Instructions:", MessageBoxButtons.OK);
            //Select 5 random images and answers
            LoadFromXML();
            playerTime.Enabled = true;
        }

       

        private void LoadFromXML()
        {
            Random r = new Random();
            int[] imgs = new int[4];

            for (int i = 0; i < 5; i++)
            {
                imgs[i] = r.Next(1, 12);

            }
            XmlDocument qa = new XmlDocument();
        }

        private void playerTime_Tick(object sender, EventArgs e)
        {
            _time += 0.01f;
            timerLabel.Text = _time.ToString("0.00");
        }
    }
}
