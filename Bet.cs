using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_at_the_Races
{
    class Bet
    {
        public int Amount; //the amount of cash that was bet
        public int Dog; //the number of the dog the bet is on
        public Guy Bettor; //the guy who placed the bet

        public Bet(int Amount, int Dog, Guy Bettor)
        {
            this.Amount = Amount;
            this.Dog = Dog;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            //return a string that says who placed the bet, how much
            //cash was bet, and which dog he bet on ("Joe bets 8 on 
            //dog #4"). If the amount is zero, no bet was placed
            //("Joe hasn't placed a bet").

            string description = "";

            if (Amount > 0)
            {
                description = String.Format("{0} bets {1} on dog #{2}",
                    Bettor.Name, Amount, Dog);
            }
            else
            {
                description = String.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int PayOut(int Winner)
        {
            //the parameter is the winner of the race. if the dog won,
            //return the amount bet. Otherwise, return the negative of the amount bet
            if (Dog == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
