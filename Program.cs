//menu
string userName = GetUserName();
 
int userSelection = SelectionMenu();

int controlInt = UserSelectionVerify();

//methods
static string GetUserName()
{
    System.Console.WriteLine("What is your name?");
    string userName = Console.ReadLine();
    System.Console.WriteLine($"Hello {userName} what would you like to do today?");
    return(userName);
}
static int SelectionMenu()
{
    System.Console.WriteLine("Press \"1\" for Budget Calulator | Press \"2\" for Currency Converter | Press \"3\" for Budget Calulator. Then press enter.");
    int userSelection = int.Parse(Console.ReadLine());
    return (userSelection);
}
static int UserSelectionVerify(int userSelection)
{
    System.Console.WriteLine($"You chose {userSelection} is this correct? If not enter -1");
    int controlInt = int.Parse(Console.ReadLine());
    return(controlInt);
}
/*  static void DisplayMenu()
{

    if(controlInt == -1 )
    {
        System.Console.WriteLine("Please try again!");
    }
    else if (userSelection == 1)
    {
        System.Console.WriteLine("You chose option \"1\".");
        Console.ReadLine();
    }
    else if (userSelection == 2)
    {
        System.Console.WriteLine("You chose option \"2\".");
        Console.ReadLine();
    }
    else if (userSelection == 3)
    {
        System.Console.WriteLine("You chose option \"3\".");
        Console.ReadLine();
    }
    
}
*/