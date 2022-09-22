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
    Console.Clear();


    System.Console.WriteLine("Welcome to the Budget Calculator!");
    System.Console.WriteLine("");

    //Ask Monthly Income
    double monthlyIncome = AskUserIncome();

    //Ask Number to Split Entertainment
    int entertainPersonNumber = AskEntertainPersNumber();

    //Monthly Savings
    double userSaving = MonthlySavings(monthlyIncome);

    //Math for monthly Income - Savings
    double newMonthlyIncome = monthlyIncome - userSaving;

    //Housing Portion
    double userHousing = UserHousing(newMonthlyIncome);

    //Food Portion
    double userFood = UserFood(newMonthlyIncome);

    //Transport Portion
    double userTransport = UserTransport(newMonthlyIncome);

    //Entertainment/Personal Portion
    double userEntertainPersonal = UserEntertainPersonal(newMonthlyIncome);

    //Entertainment per Person
    double moneyPerPerson = MoneyPerPerson(newMonthlyIncome, entertainPersonNumber);
    
    //Utilites Portion
    double userUtilites = UserUtilites(newMonthlyIncome);

    //Clothing Portion
    double userClothing = UserClothing(newMonthlyIncome);

    //User Amount Used Already 

    
    
    
    
    //Methods
    static double AskUserIncome()
    {
        System.Console.WriteLine("What is your monthly income? (Do not enter a dollar sign)");
        double monthlyIncome = double.Parse(Console.ReadLine());
        return(monthlyIncome);
    }

    static int AskEntertainPersNumber()
    {
        System.Console.WriteLine("For Entertainment or Personal uses, how many people do wish to split this between?(Enter as a single digit value, for example \"5\" for 5 people");
        return(int.Parse(Console.ReadLine()));
    }

    static double MonthlySavings(double monthlyIncome)
    {
        double userSavings = monthlyIncome * savingsPortion;
        System.Console.WriteLine($"Savings: {userSavings.ToString("C2")}");
        System.Console.WriteLine("");

        return(userSavings);
    }

    //Calculating Methods

    static double UserHousing(double newMonthlyIncome)
        {
        double userHousing = (newMonthlyIncome * housingPortion);
        System.Console.WriteLine($"Housing: {userHousing.ToString("C2")}");
        System.Console.WriteLine("");

        return(userHousing);
        }

    static double UserFood(double newMonthlyIncome)
        {
        double userFood = (newMonthlyIncome * foodPortion);
        System.Console.WriteLine($"Food: {userFood.ToString("C2")} ");
        System.Console.WriteLine("");
        return(userFood);
        }

    static double UserTransport(double newMonthlyIncome)
    {
        double userTransport = (newMonthlyIncome * transportPortion);
        System.Console.WriteLine($"Transport: {userTransport.ToString("C2")} ");
        System.Console.WriteLine("");

        return(userTransport);
    }

    static double UserClothing(double newMonthlyIncome)
        {
        double userClothing = (newMonthlyIncome * clothingPortion);
        System.Console.WriteLine($"Clothing: {userClothing.ToString("C2")} ");
        System.Console.WriteLine("");

        return(userClothing);
        }
    
    static double UserEntertainPersonal(double newMonthlyIncome)
    {
        double userEntertain = (newMonthlyIncome * entertainPortion);
        System.Console.WriteLine($"Entertainment and Personal: {userEntertain.ToString("C2")} ");
        System.Console.WriteLine("");

        return(userEntertain);
    }

    static double MoneyPerPerson(double newMonthlyIncome, int entertainPersonNumber)
    {
        double moneyPerPerson = (newMonthlyIncome * entertainPortion) / entertainPersonNumber;
        System.Console.WriteLine($"Per person amount: {(moneyPerPerson).ToString("C2")}");
        System.Console.WriteLine("");

        return(moneyPerPerson);
    }

    static double UserUtilites(double newMonthlyIncome)
    {
        double userUtilities = (newMonthlyIncome * utilitesPortion);
        System.Console.WriteLine($"Utilites: {userUtilities.ToString("C2")} ");
        System.Console.WriteLine("");

        return(userUtilities);
    }

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