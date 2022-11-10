
//Calculate the perimeter and area of various rooms.
//The app prompts the user to enter values of length and width of the classroom
//The application displays the area and perimeter of that classrom.
//Assume that the rooms are perfect rectangles
//Assume that the user will enter valid numeric data for length and width.
//The app should accept decimal enteries.
string repeat;
do 
{
    Console.WriteLine("Welcome to the room calculator, please enter the values of the LENGTH of the room in feet.");
    decimal length = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Please enter the values of the WIDTH of the room in feet next.");
    decimal breadth = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("The length of the room is: " + length + "ft and the width of the room is: " + breadth + "ft.");
    var area = length* breadth;
    var perimeter = 2 * (length + breadth);



    Console.WriteLine("The area of the room is " + area + "sq. ft. and the perimeter of the room is " + perimeter + "feet.");
    Console.WriteLine("Would you like to calculate another room? Yes (y) or No (n)?");
    repeat = Console.ReadLine();
}
while (repeat == "y");
Console.WriteLine("Thank you for using Room Calculator. Have a nice day!");



//area (Length (L) * Breadth (B))
//perimeter (2 * L) + (2 * w) or (L+W+L+W) .
//The Snug is 24'6" x 20'0". The pentouse is 42'6" x 16'6".

