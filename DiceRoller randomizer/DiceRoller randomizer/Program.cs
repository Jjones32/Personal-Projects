
using DiceRoller_randomizer;

string yn = "y";
do
{
    Console.Write("Enter number of sides for each dice and roll: ");
    int numbSidesDice = int.Parse(Console.ReadLine());

    int die1 = Dice.RollDice(numbSidesDice);
    int die2 = Dice.RollDice(numbSidesDice);
    int total = die1 + die2;
    Console.WriteLine($"Dice 1: {die1}");
    Console.WriteLine($"Dice 2: {die2}");
    Console.WriteLine($"Total for Roll: {total}");

    if (numbSidesDice == 6)
    {
        Console.WriteLine(Dice.CheckCombos(die1, die2));
        Console.WriteLine(Dice.CheckCombos(total));
    }
    Console.Write("Do you want to roll again? Enter y or n: ");
    yn = Console.ReadLine().ToLower();
}
while (yn == "y");













//1.)Create a static method to generate the random numbers 
//          a.) Proper method header
//          b.) Program generates random numbers validly within the user-specified range
//          c.) Method returns meanigful value of proper type
//2.)Create a static method for six-sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations (e.g. Snake Eyes, etc.) or an empty sting if the dice doesn't match one of the combinations
//3.)Create a static method to implement output for different dice combinations
//          a.) Proper Method Header
//          b.) Method recognizes all specified cases correctly
//          c.) Method displays properly to console
//4.)App takes all user input correctly
//5.)Application loops properly
