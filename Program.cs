//menu
string userName = GetUserName();
 
int userSelection = SelectionMenu();

UserSelectionVerify(userSelection, userName);
 
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
    System.Console.WriteLine("");
    System.Console.WriteLine("Press \"1\" for Budget Calulator");
    System.Console.WriteLine("Press \"2\" for Currency Converter");
    System.Console.WriteLine("Type \"Exit\" to exit");
    System.Console.WriteLine("");
    System.Console.WriteLine("Then press enter");

    int userSelection = int.Parse(Console.ReadLine());
    
    return (userSelection);
}
static void UserSelectionVerify(int userSelection, string userName)
{
    System.Console.WriteLine($"You chose {userSelection} is this correct? 0 for yes, -1 for no");
    int controlInt = int.Parse(Console.ReadLine());
    if( controlInt == -1)
    {
        System.Console.WriteLine($"{userName} please try again");
    }
    SelectionMenu();
}
