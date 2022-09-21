//Program Main
string userName = GetUserName();

int userMenuSelection = AskSelection(userName);

VerifySelection(ref userMenuSelection, userName);

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
    System.Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine($"Hello {userName}, what would you like to do today?");
    System.Console.WriteLine("");
    System.Console.WriteLine("Press \"1\" for Budget Calulator");
    System.Console.WriteLine("Press \"2\" for Currency Converter");
    System.Console.WriteLine("Press \"3\" to exit");
    System.Console.WriteLine("");
    System.Console.WriteLine("Then press enter");

    return (int.Parse(Console.ReadLine()));
}

static int VerifySelection(ref int userMenuSelection, string userName)
{
    while(userMenuSelection < 1 || userMenuSelection > 3 )
    {
        System.Console.WriteLine($"Sorry, {userMenuSelection} is not a valid selection please try again.");
        userMenuSelection = AskSelection(userName);   
    }
    return(userMenuSelection);
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
    //constants
    const double savingsPortion = .2;
    const double housingPortion = .25;
    const double foodPortion = .16;
    const double transportPortion = .15;
    const double entertainPortion = .25;
    const double utilitesPortion = .11;
    const double clothingPortion = .08;
    

    //Program Start
    System.Console.WriteLine("Welcome to the Budget Calculator!");
    System.Console.WriteLine("");
    System.Console.WriteLine("What is your monthly income? (Do not enter a dollar sign)");
    double monthlyIncome = double.Parse(Console.ReadLine());

    System.Console.WriteLine("For Entertainment or Personal uses, how many people do wish to split this between?(Enter as a single digit value, for example \"5\" for 5 people");
    int entertainSplitNumber = int.Parse(Console.ReadLine());

    //Monthly Savings
    System.Console.WriteLine($"Your monthly savings amount should be {(monthlyIncome * savingsPortion).ToString("C2")}");
    System.Console.WriteLine("");

    //Math for monthly Income - Savings
    double newMonthlyIncome = monthlyIncome - savingsPortion;

    //Housing Portion
    System.Console.WriteLine($"Your monthly Housing amount is {(newMonthlyIncome * housingPortion).ToString("C2")}");
    System.Console.WriteLine("");

    //Food Portion
    System.Console.WriteLine($"Your monthly Food amount is {(newMonthlyIncome * foodPortion).ToString("C2")} ");
    System.Console.WriteLine("");

    //Transport Portion
    System.Console.WriteLine($"Your monthly Transport amount is {(newMonthlyIncome * transportPortion).ToString("C2")} ");
    System.Console.WriteLine("");

    //Entertainment/Personal Portion
    System.Console.WriteLine($"Your monthly Entertainment and Personal amount is {(newMonthlyIncome * entertainPortion).ToString("C2")} ");
    System.Console.WriteLine("");

    //Entertainment per Person
    double moneyPerPerson = (newMonthlyIncome * entertainPortion) / entertainSplitNumber;
    System.Console.WriteLine($"Each person should receive {(moneyPerPerson).ToString("C2")}");
    System.Console.WriteLine("");
    
    //Utilites Portion
    System.Console.WriteLine($"Your monthly Utilites amount is {(newMonthlyIncome * utilitesPortion).ToString("C2")} ");
    System.Console.WriteLine("");

    //Clothing Portion
    System.Console.WriteLine($"Your monthly Clothing amount is {(newMonthlyIncome * clothingPortion).ToString("C2")} ");
    System.Console.WriteLine("");

    //Closing
    System.Console.WriteLine("Thank you for using the budget calculator!");
}

static void CurrencyConverter()
{
    System.Console.WriteLine("Ths is the Currency Converter!");
}

static void ProgramExit()

{
    System.Console.WriteLine("The program is now closing.");
}