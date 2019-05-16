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
            MessageBox.Show("In this game, each player will be shown 5 random images that they will select the correct word for. " +
                "The player that can identify all 5 images the fastest is the winner.", "Instructions:", MessageBoxButtons.OK);
            //Select 5 random images and answers
            int[] images = LoadFromXML();
            LoadImages(images); //Load the images.
            playerTime.Enabled = true;
        }

       

        private int[] LoadFromXML()
        {
            Random r = new Random();
            int[] imgs = new int[5];

            for (int i = 0; i < 5; i++)
            {
                int random = r.Next(1, 12);
                foreach(int j in imgs)
                {
                    if(j == random)
                    {
                        while(j == random)
                        {
                            random = r.Next(1,12);
                        }
                        imgs[i] = random;
                    }
                    else
                    {
                        imgs[i] = random;
                    }
                }
            }
            XmlDocument qa = new XmlDocument();
            qa.Load("qa.xml");
            XmlNode Box1 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box1");
            XmlNode Box2 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box2");
            XmlNode Box3 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box3");
            XmlNode Box4 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box4");
            XmlNode Box5 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box5");
            XmlNode Box6 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box6");
            XmlNode Box7 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box7");
            XmlNode Box8 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box8");
            XmlNode Box9 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box9");
            XmlNode Box10 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box10");
            XmlNode Box11 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box11");
            XmlNode Box12 = qa.DocumentElement.SelectSingleNode("/xml/Game0/Version1/Box12");

            string box1 = Box1.InnerText;
            string box2 = Box2.InnerText;
            string box3 = Box3.InnerText;
            string box4 = Box4.InnerText;
            string box5 = Box5.InnerText;
            string box6 = Box6.InnerText;
            string box7 = Box7.InnerText;
            string box8 = Box8.InnerText;
            string box9 = Box9.InnerText;
            string box10 = Box10.InnerText;
            string box11 = Box11.InnerText;
            string box12 = Box12.InnerText;

            //Populate the buttons, and return an array of image numbers
            for (int x = 1; x < 6; x++)
            {
                switch (imgs[x-1])
                {
                    case 1:
                        PopulateButton(box1, x);
                        break;
                    case 2:
                        PopulateButton(box2, x);
                        break;
                    case 3:
                        PopulateButton(box3, x);
                        break;
                    case 4:
                        PopulateButton(box4, x);
                        break;
                    case 5:
                        PopulateButton(box5, x);
                        break;
                    case 6:
                        PopulateButton(box6, x);
                        break;
                    case 7:
                        PopulateButton(box7, x);
                        break;
                    case 8:
                        PopulateButton(box8, x);
                        break;
                    case 9:
                        PopulateButton(box9, x);
                        break;
                    case 10:
                        PopulateButton(box10, x);
                        break;
                    case 11:
                        PopulateButton(box11, x);
                        break;
                    case 12:
                        PopulateButton(box12, x);
                        break;
                }
            }

            return imgs;
        }

        private void playerTime_Tick(object sender, EventArgs e)
        {
            _time += 0.01f;
            timerLabel.Text = _time.ToString("0.00");
        }

        private void PopulateButton(string whattoSay, int whichButton)
        {
            switch (whichButton)
            {
                case 1:
                    button1.Text = whattoSay;
                    break;
                case 2:
                    button2.Text = whattoSay;
                    break;
                case 3:
                    button3.Text = whattoSay;
                    break;
                case 4:
                    button4.Text = whattoSay;
                    break;
                case 5:
                    button5.Text = whattoSay;
                    break;
            }    
        }


        private void LoadImages(int[] img)
        {
            //Start from 5 and go to 1.
            pictureBox5.Image = Image.FromFile("0" + img[0].ToString() + ".jpg");
            pictureBox4.Image = Image.FromFile("0" + img[1].ToString() + ".jpg");
            pictureBox3.Image = Image.FromFile("0" + img[2].ToString() + ".jpg");
            pictureBox2.Image = Image.FromFile("0" + img[3].ToString() + ".jpg");
            pictureBox1.Image = Image.FromFile("0" + img[4].ToString() + ".jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
