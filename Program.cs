//Program Main
string userName = GetUserName();
 
int userSelection = SelectionMenu();

UserSelectionVerify(userSelection, userName);

BreakIntoProgram(userSelection);
 
//Main Methods
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
    System.Console.WriteLine("Press \"3\" to exit");
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
        SelectionMenu();
    }
    
}
static void BreakIntoProgram(int userSelection)
{
    switch(userSelection)
    {
        case 1:
        System.Console.WriteLine("You are now using the Budget Calculator");
        BudgetCalculator();
        break;

        case 2:
        System.Console.WriteLine("You are now using the Currency Converter");
        CurrencyConverter();
        break;

        case 3:
        System.Console.WriteLine("You are now exiting the program");
        break;
    }
}
//Program Methods
static void BudgetCalculator()
{
    System.Console.WriteLine("This is the Budget Calculator");

}
static void CurrencyConverter()
{
    System.Console.WriteLine("Ths is the Currency Converter");
}
static void ProgramExit()
{
    System.Console.WriteLine("The program is now closing");
}