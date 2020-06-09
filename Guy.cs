using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    class Guy
    {
        public string Name; //the guy's name
        public Bet MyBet; //an instance of Bet() that has his bet
        public int Cash; //how much cash he has

        //the last two fields are the guy's GUI controls on the form
        public RadioButton MyRadioButton; //my radiobutton
        public Label MyLabel; //my label

        public Guy(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }

        public void UpdateLabels()
        {
            //set my label to my bet's description, and the label on my
            //radiobutton to show my cash ("Joe has 43 bucks")
            if (MyBet == null)
            {
                MyLabel.Text = String.Format("{0} hasn't placed any bets", Name);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = Name + " has " + Cash + " bucks";

        }

        public void ClearBet() {
            MyBet.Amount = 0; //reset my bet so it's zero
        } 

        public bool PlaceBet(int Amount, int Dog)
        {
            //place a new bet and store it in my bet field
            //return true if the guy has enough money to bet
            if (Amount <= Cash)
            {
                MyBet = new Bet(Amount, Dog, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            //ask my bet to pay out
            Cash += MyBet.PayOut(Winner);
        }
    }
}
