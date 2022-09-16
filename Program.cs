//Program Main
string userName = GetUserName();

int userMenuSelection = AskSelection(userName);

int userVerificationNumber = UserSelectionVerification(userMenuSelection);

while(userVerificationNumber != 0 )
{
    Console.Clear();
    System.Console.WriteLine("I'm sorry, please try that again.");
    System.Console.WriteLine("");
    userMenuSelection = AskSelection(userName);
    userVerificationNumber = UserSelectionVerification(userMenuSelection);
}

ProgramRun(userMenuSelection);
 
//Main Methods
static string GetUserName()
{
    Console.Clear();
    System.Console.WriteLine("What is your name?");
    return (Console.ReadLine());
}

static int AskSelection(string userName)
{
    Console.Clear();
    System.Console.WriteLine($"Hello {userName} what would you like to do today?");
    System.Console.WriteLine("");
    System.Console.WriteLine("Press \"1\" for Budget Calulator");
    System.Console.WriteLine("Press \"2\" for Currency Converter");
    System.Console.WriteLine("Press \"3\" to exit");
    System.Console.WriteLine("");
    System.Console.WriteLine("Then press enter");

    return (int.Parse(Console.ReadLine()));
}

static int UserSelectionVerification(int userMenuSelection)
{
    Console.Clear();
    System.Console.WriteLine($"You chose {userMenuSelection}, is this correct?");
    System.Console.WriteLine("0 for yes, -1 for no");
    System.Console.WriteLine("Then press enter");
    return(int.Parse(Console.ReadLine()));
}

static void ProgramRun(int userMenuSelection)
{
    switch(userMenuSelection)
    {
        case 1:
        {
            BudgetCalculator();
        }
        break;

        case 2:
        {
            CurrencyConverter();
        }
        break;
        case 3:
        {
            ProgramExit();
        }
        break;
    };
}

//Program Methods
static void BudgetCalculator()
{
    System.Console.WriteLine("This is the Budget Calculator!");

}

static void CurrencyConverter()
{
    System.Console.WriteLine("Ths is the Currency Converter!");
}

static void ProgramExit()
{
    System.Console.WriteLine("The program is now closing.");
}