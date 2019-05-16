using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace FrenchGame
{
    public partial class Form1 : Form
    {
        int _selGame = -1; //If it stays -1, something went wrong.

        string _pl1Name = "Player 1 Didn't Enter A Name";
        string _pl2Name = "Player 2 Didn't Enter A Name";
        string _pl3Name = "Player 3 Didn't Enter A Name";
        string _pl4Name = "Player 4 Didn't Enter A Name";
        string _pl5Name = "Player 5 Didn't Enter A Name";
        int _numPlayers = 1;

        public Form1()
        {
            InitializeComponent();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            button8.Hide();
            int hour = DateTime.Now.Hour;
            if(hour >= 0 && hour <= 11)
            {
                label1.Text = "BONJOUR!";
            }
            if (hour >= 12 && hour <= 16)
            {
                label1.Text = "BONNE APRES-MIDI!";
                label1.Left = 60;
            }
            if (hour >= 17 && hour <= 23)
            {
                label1.Text = "BONSOIR!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Exit the program
            //Drag the program out of RAM by its ear and blow its brains out all over the cache
            KillMeNow();
        }

        public void KillMeNow()
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //L'electronique labeling

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //L'electronique translate
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //L'ordianteur labelling
            compumatch f = new compumatch();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //L'ordinateur translate
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Random
            _selGame = GetRan();
            PlayGame(_selGame);
        }

        private int GetRan()
        {
            Random ran = new Random();
            int toReturn = ran.Next(0, 3);
            return toReturn;
        }

        public void PlayGame(int gameNo)
        {
            //Initiate gameplay.
            //First, determine how many names to show.
            int players = (int)numericUpDown1.Value;
            HideAll();
            ShowNames();
        }

        public void HideAll()
        {
            label2.Hide();
            numericUpDown1.Hide();
            label3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button7.Hide();
            button9.Hide();
        }

        public void ShowNames()
        {
            switch (_numPlayers)
            {
                case 1:
                    textBox5.Show();
                    label4.Show();
                    break;
                case 2:
                    textBox5.Show();
                    label4.Show();
                    textBox4.Show();
                    label5.Show();
                    break;
                case 3:
                    textBox5.Show();
                    label4.Show();
                    textBox4.Show();
                    label5.Show();
                    textBox3.Show();
                    label6.Show();
                    break;
                case 4:
                    textBox5.Show();
                    label4.Show();
                    textBox4.Show();
                    label5.Show();
                    textBox3.Show();
                    label6.Show();
                    textBox2.Show();
                    label7.Show();
                    break;
                case 5:
                    textBox5.Show();
                    label4.Show();
                    textBox4.Show();
                    label5.Show();
                    textBox3.Show();
                    label6.Show();
                    textBox2.Show();
                    label7.Show();
                    textBox1.Show();
                    label8.Show();
                    break;
                default:
                    break;
            }
            
            label9.Show(); //Player names
            button8.Show(); //Start game
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Display leaderboard

            //First, read leaderbord.xml
            XmlDocument leaderboard = new XmlDocument();
            try
            {
                leaderboard.Load("leaderboard.xml");

                XmlNode firstPlace = leaderboard.DocumentElement.SelectSingleNode("/xml/first");
                XmlNode secondPlace = leaderboard.DocumentElement.SelectSingleNode("/xml/second");
                XmlNode thirdPlace = leaderboard.DocumentElement.SelectSingleNode("/xml/third");
                XmlNode fourthPlace = leaderboard.DocumentElement.SelectSingleNode("/xml/fourth");
                XmlNode fifthPlace = leaderboard.DocumentElement.SelectSingleNode("/xml/fifth");

                //Read the names and corresponding time scores.
                string firstName = firstPlace.Attributes["name"]?.InnerText;
                string secondName = secondPlace.Attributes["name"]?.InnerText;
                string thirdName = thirdPlace.Attributes["name"]?.InnerText;
                string fourthName = fourthPlace.Attributes["name"]?.InnerText;
                string fifthName = fifthPlace.Attributes["name"]?.InnerText;

                string firstScore = firstPlace.Attributes["time"]?.InnerText;
                string secondScore = secondPlace.Attributes["time"]?.InnerText;
                string thirdScore = thirdPlace.Attributes["time"]?.InnerText;
                string fourthScore = fourthPlace.Attributes["time"]?.InnerText;
                string fifthScore = fifthPlace.Attributes["time"]?.InnerText;
                //last, display in text box form:
                MessageBox.Show(
                    "1st Place: " + firstName + ", " + firstScore + " Seconds" + "\n" +
                    "2nd Place: " + secondName + ", " + secondScore + " Seconds" + "\n" +
                    "3rd Place: " + thirdName + ", " + thirdScore + " Seconds" + "\n" +
                    "4th Place: " + fourthName + ", " + fourthScore + " Seconds" + "\n" +
                    "5th Place: " + fifthName + ", " + fifthScore + " Seconds"
                    );
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Could not locate leaderboard.xml- Did someone delete the file?", "Error!", MessageBoxButtons.OK);
            }
            catch (System.Xml.XPath.XPathException)
            {
                MessageBox.Show("Error reading the XML file, did someone edit it?", "Error!", MessageBoxButtons.OK);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error reading the XML file, did someone edit it?", "Error!", MessageBoxButtons.OK);
            }

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Display credits message
            MessageBox.Show("Code & UI: Seth Nordahl" + "\n" + "Questions and Answers (XML Format): Jordan Hendrickson", "Credits:", MessageBoxButtons.OK);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _numPlayers = (int)numericUpDown1.Value;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool shouldStart = true;
            //Make sure all the text boxes are filled, then start the right game
            if(_numPlayers >= 1)
            {
                if(textBox5.Text == "")
                {
                    shouldStart = false;
                }
            }
            if (_numPlayers >= 2)
            {
                if (textBox4.Text == "")
                {
                    shouldStart = false;
                }
            }
            if (_numPlayers >= 3)
            {
                if (textBox3.Text == "")
                {
                    shouldStart = false;
                }
            }
            if (_numPlayers >= 4)
            {
                if (textBox2.Text == "")
                {
                    shouldStart = false;
                }
            }
            if (_numPlayers >= 5)
            {
                if (textBox1.Text == "")
                {
                    shouldStart = false;
                }
            }
            if(shouldStart == true)
            {
                switch (_selGame)
                {
                    case 0:
                        //L'Electronique labelling
                        break;
                    case 1:
                        //L'Electronique translate
                        break;
                    case 2:
                        //L'Ordinateur labelling
                        break;
                    case 3:
                        //L'Ordinateur translate
                        break;
                }
            }
        }
    }
}
