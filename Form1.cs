using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[3];   //creating an array of 3 Guy() references.
        Greyhound[] dogs = new Greyhound[4];
        
        public Form1()
        {
            InitializeComponent();

            int startingPosition = pictureBox2.Right - pictureBox1.Left;
            int raceTrackLength = pictureBox1.Size.Width;


            guys[0] = new Guy( "Joe", null, 50, radioButton1, label1 );
            guys[1] = new Guy( "Bob", null, 75, radioButton2, label2 );
            guys[2] = new Guy( "Al", null, 45, radioButton3, label3 );

            dogs[0] = new Greyhound {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = pictureBox1.Width - pictureBox2.Width,
            };
            dogs[1] = new Greyhound {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = pictureBox1.Width - pictureBox3.Width,
            };
            dogs[2] = new Greyhound {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = pictureBox1.Width - pictureBox4.Width,
            };
            dogs[3] = new Greyhound {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = pictureBox1.Width - pictureBox5.Width,
            };

            radioButton1.Text = guys[0].Name + " has " + guys[0].Cash + " bucks";
            radioButton2.Text = guys[1].Name + " has " + guys[1].Cash + " bucks";
            radioButton3.Text = guys[2].Name + " has " + guys[2].Cash + " bucks";

            foreach (Guy guy in guys)
            {
                guy.UpdateLabels();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = "Minimum Bet: " + numericUpDown1.Value +" bucks";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = guys[0].Name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = guys[1].Name;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = guys[2].Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningDog;
            timer1.Enabled = false;

            while (NoWinner)
            {
                Application.DoEvents();
                for (int i = 0; i < dogs.Length; i++)
                {
                    if (dogs[i].Run())
                    {
                        winningDog = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - dog #" + winningDog);
                        foreach (Guy guy in guys)
                        {
                            if (guy.MyBet != null)
                            {
                                guy.Collect(winningDog);
                                guy.MyBet = null;
                                guy.UpdateLabels();
                            }
                        }
                        foreach (Greyhound dog in dogs)
                        {
                            dog.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }

            timer1.Enabled = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (dogs[i].Run())
                    timer1.Enabled = true;
                else
                    timer1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int GuyNumber = 0;

            if (radioButton1.Checked)
            {
                GuyNumber = 0;
            }
            if (radioButton2.Checked)
            {
                GuyNumber = 1;
            }
            if (radioButton3.Checked)
            {
                GuyNumber = 2;
            }

            guys[GuyNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            guys[GuyNumber].UpdateLabels();
        }
    }
}
