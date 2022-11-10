

using System.Data;

Console.WriteLine("Hello thanks for choosing Jake's PowersTable application lets learn squares and cubes!");

    
Console.Write("\n\n");
    string repeat;


do
{

    Console.WriteLine("Enter an integer to get started!");
    int baseNum = Convert.ToInt32(Console.ReadLine());

    Console.Write("\n\n");
    Console.Write("===========================================================================");
    Console.Write("\n\n");

    int sqr = baseNum * baseNum;
    int cube = baseNum * baseNum * baseNum;
    int length = baseNum + 1;
    Console.WriteLine("User Int" + "\t Squared Int" + "\t Cubed int");


   //for(int i = 0; i < baseNum ; i++)
    //{
        Console.Write("\n\n");
        //baseNum--;
        
        Console.WriteLine("      " + baseNum + "                  " +  sqr + "               " + cube);
   // }
    Console.Write("\n\n");
    Console.WriteLine("Would you like to go again? (y/n)");
    repeat = Console.ReadLine();

}
while (repeat == "y");
Console.WriteLine("Way to go! now you know some more powers than yesterday! Come back later to learn more!");




//Display a table of powers. Ask the user if they would like to go again, and if so loop back to the beginning.

//1 Point: The app prompts the user to enter an integer.
//3 Point: The app displays a table of squares and cubes from 1 to the value entered.
//1 Point: The app prompts the user to continue

//Assume that the user will enter valid data.
//The app should continue only if the user agrees to continue.

//***Don't mess up the difference between squares and cubes.
//***Use /t to tabe to line up columns properly.

