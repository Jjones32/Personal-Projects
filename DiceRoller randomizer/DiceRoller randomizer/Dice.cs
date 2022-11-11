using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller_randomizer
{
    public class Dice
    {
        private static readonly Random _random = new Random();

        public static int RollDice (int diceSides)
        {
            int rollDice = _random.Next(1, diceSides + 1);
            return rollDice;
        }

        public static string CheckCombos(int die1, int die2)
        {
            string combo = "";

            if (Dice.CheckSnakeEyes(die1, die2))
            {
                combo= "Snake Eyes";
            }
            else if (Dice.CheckSnakeEyes(die1, die2))
            {
                combo = "Ace Deuce";
            }
            else if (Dice.CheckBoxCars(die1, die2)) ;
            {
                combo = "Box Cars";
            }
            return combo;
        }
        public static string CheckCombos(int total)
        {
            string combo = "";
            if (Dice.CheckWin(total))
            {
                combo = "Win!";
            }
            else if (Dice.CheckCraps(total))
            {
                combo = "craps!";
            }
            return combo;
        }
        public static bool CheckSnakeEyes(int die1, int die2)
        {
            return (die1 == 1 && die2 == 1);
        }
        public static bool CheckAceDeuce(int die1, int die2)
        {
            return ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1)); 
        }
        public static bool CheckBoxCars(int die1, int die2)
        {
            return (die1 == 6 && die2 == 6);
        }
        public static bool CheckWin (int total)
        {
            return (total == 7 || total == 11);
        }
        public static bool CheckCraps(int total)
        {
            return (total == 2 || total == 3 || total == 12);
        }
    }
}
