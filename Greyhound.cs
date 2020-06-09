using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace A_Day_at_the_Races
{
    class Greyhound
    {
        public int StartingPosition; //where my picturebox starts
        public int RacetrackLength; //how long the racetrack is
        public PictureBox MyPictureBox = null; //my picturebox object
        public int Location = 0; //my location on the racetrack
        public Random Randomizer; //an instance of Random
        
        public void MoveMyPictureBox(int distance)
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }
        
        public bool Run()
        {
            //move forward either 1, 2, 3 or 4 spaces at random
            //update the position of my picturebox on the form
            Randomizer = new Random();
            int distance = Randomizer.Next(1, 5);
            MoveMyPictureBox(distance);

            Location += distance;

            //return true if I won the race

            if (Location >= (RacetrackLength - StartingPosition))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            //reset my location to the start line.
            MoveMyPictureBox(-Location);
            Location = 0;
        }

        
    }
}
