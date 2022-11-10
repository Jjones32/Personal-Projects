//category: animated, drama, horror, scifi

using MovieDatabase;

List<Movie> movieDatabase = new List<Movie>()
{
    new Movie("Forest Gump", "drama"),
    new Movie("Friday the 13th", "horror"),
    new Movie("Star Trek", "scifi"),
    new Movie("The Notebook", "drama"),
    new Movie("Bolt", "animated"),
    new Movie("Matrix Reloaded", "scifi"),
    new Movie("Last House On The Left", "horror"),
    new Movie("Godfather", "drama"),
    new Movie("Moana", "animated"),
    new Movie("The Color Purple", "drama")
};

string repeat;

do
{
    Console.WriteLine("Pick a category: animated, drama, horror, scifi");
    Console.Write("\n\n");
    var userInput = Console.ReadLine().ToLower();
    Console.Write("\n\n");
    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("Sorry that isnt a genre, please choose between the mentioned genres.");
    }
    
    List<Movie> selectedList = movieDatabase.Where(x => x.GetCategory() == userInput).ToList();

    //iterating through list to display titles of the movies
    foreach (Movie movie in selectedList)
    {
        Console.WriteLine(movie.GetTitle());
    }
    Console.Write("\n\n");
    Console.WriteLine("Would you like to continue? (y/n)");
    repeat = Console.ReadLine();
    

}
while (repeat == ("y"));
Console.WriteLine("Thanks for using the MovieDatabase app, have a nice day.");


//The app stores a list of 10 movies and displays them by category.
//the user can enter any of the following categories to display the films in the list that match the category.
//After the list is displayed, the user is asked if he or she wants to continue if no, the program ends.