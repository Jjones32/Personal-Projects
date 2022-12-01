using System.Globalization;

var storeItems = new Dictionary<string, decimal>()
{
    { "Nutella", 5.75m },
    { "Bread", 1.00m },
    { "Apples", 2.00m },
    { "Oranges", 3.50m },
    { "Bananas", 2.75m },
    { "Peanut Butter", 5.25m },
    { "Sack Of Potatoes", 4.25m },
    { "Oreos", 1.25m },
    { "Foie Gras", 125.75m }
};

bool chooseItem = true;

List<string> currentShoppingList = new List<string>();
List<decimal> currentPriceList = new List<decimal>();

Console.WriteLine("Welcome to Quik Shopper. Here are your options.");
do
{
    Console.WriteLine();
    PrintMenu(storeItems);

    Console.WriteLine();
    Console.WriteLine("What would you like?");

    var userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput))
    {
        //This is if they just hit enter and type nothing in
        continue;
    }


    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    userInput = textInfo.ToTitleCase(userInput);

    //my unhappy case
    if (!storeItems.ContainsKey(userInput))
    {
        //Continue the loop with a message
        Console.WriteLine("So sorry, we don't have that. Please look at our offerings one more time and choose from there.");
        continue;
    }
    //my happy case
    else
    {
        currentShoppingList.Add(userInput);
        currentPriceList.Add(storeItems[userInput]);

        Console.WriteLine("Are you finished shopping?");
        var continueShopping = Console.ReadLine();

        if (string.IsNullOrEmpty(continueShopping))
        {
            continue;
        }
        //they want to leave
        else if (string.IsNullOrEmpty(continueShopping) || continueShopping.ToLower() == "y" || continueShopping.ToLower() == "yes")
        {
            Console.WriteLine("You bought: ");

            //alphabetize
            currentShoppingList.Sort();

            //Iterate through the shopping list and print
            foreach (var s in currentShoppingList)
            {
                Console.WriteLine(PrintMenuLine(s, storeItems[s].ToString(), 15, currentShoppingList.Max(x => x.Length), currentPriceList.Select(x => x.ToString()).Max(x => x.Length) + 1));
            }

            Console.WriteLine($"Your total is ${currentPriceList.Sum()}. Have a nice day!");
            break;
        }
        else
        {
            continue;
        }
    }
}
while (chooseItem);

void PrintMenu(Dictionary<string, decimal> storeItems)
{
    
    var nameList = storeItems.Keys.ToList();

    
    nameList.Sort();

    int longestProductNameSize = nameList.Max(c => c.Length);

    //The select allows me to perform a function for each value in this case turning them into strings so I can get the max length easier
    //The plus one is to account for the dollar sign later
    int longestPriceSize = storeItems.Values.Select(x => x.ToString()).Max(c => c.Length) + 1;


    int bufferSize = 15;

    //Dictionaries don't sort so I need to keep the keys in a list if I want them to be in alphabetical order
    foreach (string s in nameList)
    {
        Console.WriteLine(PrintMenuLine(s, storeItems[s].ToString(), bufferSize, longestProductNameSize, longestPriceSize));
    }
}

string PrintMenuLine(string productName, string price, int bufferSize, int maxSize, int maxSizePrice)
{

    productName =  productName.PadRight(productName.Length + (maxSize - productName.Length));

    //uniform buffer
    productName = productName.PadRight(productName.Length + bufferSize);

    price = "$" + price;

    price = price.PadLeft(price.Length + (maxSizePrice - price.Length));

    return productName + price;
}
