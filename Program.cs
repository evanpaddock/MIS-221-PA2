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
    double monthlyIncome = 0;
    monthlyIncome = AskUserIncome();

    //Tests if Monthly Income is negative. If so will rerun until it is not, this is because monthly income cannot be negative for an individual
    monthlyIncome = MonthlyIncomeNegative(ref monthlyIncome);

    //Ask Number to Split Entertainment
    int entertainPersonsNumber = AskEntertainPersNumber();

    //Displayed Amounts for user budget below

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

    //Entertainment Per Person
    double moneyPerPerson = MoneyPerPerson(newMonthlyIncome, entertainPersonsNumber);

    //Utilites Portion
    double userUtilites = UserUtilites(newMonthlyIncome);

    //Clothing Portion
    double userClothing = UserClothing(newMonthlyIncome);

    //User verification to move to amounts already used/leftover or exit
    int userLeftoverVerificationNumber = UserContinueToLeftover();

    //Ask user spending amounts or exit
    if(userLeftoverVerificationNumber == 1)
    {
        //Input User Amounts Used Already
        double userSavingSpent = AskUserSavingSpent();

        double userHousingSpent = AskUserHousingSpent();

        double userFoodSpent = AskUserFoodSpent();

        double userTransportSpent = AskUserTransportSpent();

        double userEntertainPersonalSpent = AskUserEntertainPersonalSpent();

        double userUtilitesSpent = AskUserUtilitesSpent();

        double userClothingSpent = AskUserClothingSpent();

        //Display totals after spending

        System.Console.WriteLine("");

        MonthlySavingsAfterSpent(userSaving, userSavingSpent);

        MonthlyHousingAfterSpent(userHousing, userHousingSpent);

        MonthlyFoodAfterSpent(userFood, userFoodSpent);

        MonthlyTransportAfterSpent(userTransport, userTransportSpent);

        double userEntertainPersonalLeftover = MonthlyEntertainPersonalAfterSpent(userEntertainPersonal, userEntertainPersonalSpent);

        MonthlyPerPersonAfterSpent(userEntertainPersonalLeftover, entertainPersonsNumber);

        MonthlyUtilitesAfterSpent(userUtilites, userUtilitesSpent);

        MonthlyClothingAfterSpent(userClothing, userClothingSpent);
    
    }
    else
    {
        ProgramExit();
    }
    

    //Program Input Methods
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

    static double MonthlyIncomeNegative(ref double monthlyIncome)
    {
        while(monthlyIncome < 0)
        {
            System.Console.WriteLine($"Sorry, the amount you entered:{monthlyIncome}, should not be negative. ");
            System.Console.WriteLine("Please press enter to try that again.");
            Console.ReadKey();
            Console.Clear();
            monthlyIncome = AskUserIncome();
        }
        return(monthlyIncome);
    }

    //Calculating Methods
    static double MonthlySavings(double monthlyIncome)
    {
        double userSavings = monthlyIncome * savingsPortion;
        System.Console.WriteLine($"Savings: {userSavings.ToString("C2")}");

        return(userSavings);
    }

    static double UserHousing(double newMonthlyIncome)
        {
        double userHousing = (newMonthlyIncome * housingPortion);
        System.Console.WriteLine($"Housing: {userHousing.ToString("C2")}");

        return(userHousing);
        }

    static double UserFood(double newMonthlyIncome)
        {
        double userFood = (newMonthlyIncome * foodPortion);
        System.Console.WriteLine($"Food: {userFood.ToString("C2")} ");

        return(userFood);
        }

    static double UserTransport(double newMonthlyIncome)
    {
        double userTransport = (newMonthlyIncome * transportPortion);
        System.Console.WriteLine($"Transport: {userTransport.ToString("C2")} ");

        return(userTransport);
    }

    static double UserClothing(double newMonthlyIncome)
        {
        double userClothing = (newMonthlyIncome * clothingPortion);
        System.Console.WriteLine($"Clothing: {userClothing.ToString("C2")} ");

        return(userClothing);
        }
    
    static double UserEntertainPersonal(double newMonthlyIncome)
    {
        double userEntertain = (newMonthlyIncome * entertainPortion);
        System.Console.WriteLine($"Entertainment and Personal: {userEntertain.ToString("C2")} ");

        return(userEntertain);
    }

    static double MoneyPerPerson(double newMonthlyIncome, int entertainPersonsNumber)
    {
        double moneyPerPerson = (newMonthlyIncome * entertainPortion) / entertainPersonsNumber;
        System.Console.WriteLine($"Per person amount: {(moneyPerPerson).ToString("C2")}");

        return(moneyPerPerson);
    }

    static double UserUtilites(double newMonthlyIncome)
    {
        double userUtilities = (newMonthlyIncome * utilitesPortion);
        System.Console.WriteLine($"Utilites: {userUtilities.ToString("C2")} ");

        return(userUtilities);
    }

    //After spending calculations
    static void MonthlySavingsAfterSpent(double userSavings, double userSavingSpent)
    {
        double userSavingsLeftover = userSavings - userSavingSpent;
        System.Console.WriteLine($"Savings Leftover: {userSavingsLeftover.ToString("C2")}");

    }

    static void MonthlyHousingAfterSpent(double userHousing, double userHousingSpent)
    {
        double userHousingLeftover = userHousing - userHousingSpent;
        System.Console.WriteLine($"Housing Leftover: {userHousingLeftover.ToString("C2")}");

    }

    static void MonthlyFoodAfterSpent(double userFood, double userFoodSpent)
    {
        double userFoodLeftover = userFood - userFoodSpent;
        System.Console.WriteLine($"Food Leftover: {userFoodLeftover.ToString("C2")}");

    }

    static void MonthlyTransportAfterSpent(double userTransport, double userTransportSpent)
    {
        double userTransportLeftover = userTransport - userTransportSpent;
        System.Console.WriteLine($"Transport Leftover: {userTransportLeftover.ToString("C2")}");

    }

    static void MonthlyClothingAfterSpent(double userClothing, double userClothingSpent)
    {
        double userClothingLeftover = userClothing - userClothingSpent;
        System.Console.WriteLine($"Clothing Leftover: {userClothingLeftover.ToString("C2")}");

    }

    static double MonthlyEntertainPersonalAfterSpent(double userEntertainPersonal, double userEntertainPersonalSpent)
    {
        double userEntertainPersonalLeftover = userEntertainPersonal - userEntertainPersonalSpent;
        System.Console.WriteLine($"Entertain/Personal Leftover: {userEntertainPersonalLeftover.ToString("C2")}");

        return(userEntertainPersonalLeftover);
    }

    static void MonthlyPerPersonAfterSpent( double userEntertainPersonalLeftover, int entertainPersonsNumber)
    {
        double userMonthlyPerPersonRemaining = (userEntertainPersonalLeftover / entertainPersonsNumber);
        System.Console.WriteLine($"Money Per Person Leftover: {userMonthlyPerPersonRemaining.ToString("C2")}");

    }

    static void MonthlyUtilitesAfterSpent(double userUtilites, double userUtilitesSpent)
    {
        double userUtilitesLeftover = userUtilites - userUtilitesSpent;
        System.Console.WriteLine($"Utilites Leftover: {userUtilitesLeftover.ToString("C2")}");

    }

    //Methods for to get user amounts already used
    static int UserContinueToLeftover()
    {
        System.Console.WriteLine("");
        System.Console.WriteLine("Please enter 1 to continue to see amounts minus money you've already spent, or 0 to exit");
        int userSavingsVerificationNumber = int.Parse(Console.ReadLine());
        
        return(userSavingsVerificationNumber);
    }

    static double AskUserSavingSpent()
        {
            System.Console.WriteLine("How much have you already added to savings?");
            double userSavingSpent = double.Parse(Console.ReadLine());
            return(userSavingSpent);
        }

    static double AskUserHousingSpent()
        {
            System.Console.WriteLine("How much have you already spent on housing?");
            double userHousingSpent = double.Parse(Console.ReadLine());
            return(userHousingSpent);
        }

    static double AskUserFoodSpent()
        {
            System.Console.WriteLine("How much have you already spent on food?");
            double userFoodSpent = double.Parse(Console.ReadLine());
            return(userFoodSpent);
        }

    static double AskUserTransportSpent()
        {
            System.Console.WriteLine("How much have you already spent on transport?");
            double userTransportSpent = double.Parse(Console.ReadLine());
            return(userTransportSpent);
        }

    static double AskUserClothingSpent()
        {
            System.Console.WriteLine("How much have you already spent on clothing?");
            double userClothingSpent = double.Parse(Console.ReadLine());
            return(userClothingSpent);
        }

    static double AskUserEntertainPersonalSpent()
        {
            System.Console.WriteLine("How much have you already spent on entertainment/personal?");
            double userEntertainPersonalSpent = double.Parse(Console.ReadLine());
            return(userEntertainPersonalSpent);
        }

    static double AskUserUtilitesSpent()
        {
            System.Console.WriteLine("How much have you already spent on utilites?");
            double userUtilitesSpent = double.Parse(Console.ReadLine());
            return(userUtilitesSpent);
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