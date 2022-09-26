//Program Main
string userName = GetUserName();

int userMenuSelection = AskSelection(userName);

VerifySelection(ref userMenuSelection, userName);

ProgramRun(userMenuSelection, userName);

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

static void ProgramRun(int userMenuSelection, string userName)
{
    switch(userMenuSelection)
    {
        case 1:
        {
            BudgetCalculator(userName);
        }
        break;

        case 2:
        {
            CurrencyConverter(userName);
        }
        break;
        case 3:
        {
            ProgramExit(userName);
        }
        break;
    };
}

//Program Methods
static void BudgetCalculator(string userName)
{
    //constants
    const double SAVINGS_PORTION = .2;
    const double HOUSING_PORTION = .25;
    const double FOOD_PORTION = .16;
    const double TRANSPORT_PORTION = .15;
    const double ENTERTAIN_PORTION = .25;
    const double UTILITES_PORTION = .11;
    const double CLOTHING_PORTION = .08;
    

    //Program Start
    Console.Clear();


    System.Console.WriteLine("Welcome to the Budget Calculator!");
    System.Console.WriteLine("");

    //Ask Monthly Income
    double monthlyIncome = 0;
    monthlyIncome = AskUserIncome();

    //EXTRA***
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

    //Ask user spending amounts or exit ***EXTRA
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

        System.Console.WriteLine("If the number is in (), it is how much over you have spent");

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
        ProgramExit(userName);
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
        double userSavings = monthlyIncome * SAVINGS_PORTION;
        System.Console.WriteLine($"Savings: {userSavings.ToString("C2")}");

        return(userSavings);
    }

    static double UserHousing(double newMonthlyIncome)
        {
        double userHousing = (newMonthlyIncome * HOUSING_PORTION);
        System.Console.WriteLine($"Housing: {userHousing.ToString("C2")}");

        return(userHousing);
        }

    static double UserFood(double newMonthlyIncome)
        {
        double userFood = (newMonthlyIncome * FOOD_PORTION);
        System.Console.WriteLine($"Food: {userFood.ToString("C2")} ");

        return(userFood);
        }

    static double UserTransport(double newMonthlyIncome)
    {
        double userTransport = (newMonthlyIncome * TRANSPORT_PORTION);
        System.Console.WriteLine($"Transport: {userTransport.ToString("C2")} ");

        return(userTransport);
    }

    static double UserClothing(double newMonthlyIncome)
        {
        double userClothing = (newMonthlyIncome * CLOTHING_PORTION);
        System.Console.WriteLine($"Clothing: {userClothing.ToString("C2")} ");

        return(userClothing);
        }
    
    static double UserEntertainPersonal(double newMonthlyIncome)
    {
        double userEntertain = (newMonthlyIncome * ENTERTAIN_PORTION);
        System.Console.WriteLine($"Entertainment and Personal: {userEntertain.ToString("C2")} ");

        return(userEntertain);
    }

    static double MoneyPerPerson(double newMonthlyIncome, int entertainPersonsNumber)
    {
        double moneyPerPerson = (newMonthlyIncome * ENTERTAIN_PORTION) / entertainPersonsNumber;
        System.Console.WriteLine($"Per person amount: {(moneyPerPerson).ToString("C2")}");

        return(moneyPerPerson);
    }

    static double UserUtilites(double newMonthlyIncome)
    {
        double userUtilities = (newMonthlyIncome * UTILITES_PORTION);
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
    ProgramExit(userName);
}

static void CurrencyConverter(string userName)
{
    //Constants
    const double USD_USD_RATE = 1;
    const double USD_POUND_RATE = 0.683;
    const double USD_FRANCS_RATE = 0.98;
    const double USD_RUPEES_RATE = 79.58;
    const double USD_CAN_RATE = 1.315;

    //Main
    System.Console.WriteLine("This is the Currency Converter!");
    System.Console.WriteLine("");

    int userCurrencySelection = UserSelection();

    userCurrencySelection = VerifyCurrencySelection(ref userCurrencySelection);

    double startNumber = StartNumber();

    BreakIntoCalculations(userCurrencySelection, startNumber, userName);

    //Main Methods
    static int UserSelection()
    {
        System.Console.WriteLine("Press:");
        System.Console.WriteLine("0 for USD to USD");
        System.Console.WriteLine("1 for USD to POUND");
        System.Console.WriteLine("2 for USD to FRANC");
        System.Console.WriteLine("3 for USD to RUPEE");
        System.Console.WriteLine("4 for USD to CAN_$");
        System.Console.WriteLine("5 for POUND to USD");
        System.Console.WriteLine("6 for FRANC to USD");
        System.Console.WriteLine("7 for RUPEE to USD");
        System.Console.WriteLine("8 for CAN_$ to USD");
        return(int.Parse(Console.ReadLine()));
    }

    static int VerifyCurrencySelection(ref int userCurrencySelection)
    {   
        while(userCurrencySelection > 8 || userCurrencySelection < 0)
        {   
            Console.Clear();
            System.Console.WriteLine("Please try that again. Your selection is not valid");
            System.Console.WriteLine("");
            userCurrencySelection = UserSelection();
            
        }

        return(userCurrencySelection);
    }

    static double StartNumber()
    {
        System.Console.WriteLine("What number do you wish to convert from?");
        return(double.Parse(Console.ReadLine()));
    }

    static void BreakIntoCalculations(int userCurrencySelection, double startNumber, string userName)
    {
        switch(userCurrencySelection)
        {   
            case 0:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * USD_USD_RATE).ToString("C2")} Dollars.");
            }
            break;
            case 1:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * USD_POUND_RATE).ToString("C2")} Pounds."); 
            }
            break;
            case 2:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * USD_FRANCS_RATE).ToString("C2")} Francs."); 
            }
            break;
            case 3:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * USD_RUPEES_RATE).ToString("C2")} Rupees."); 
            }
            break;
            case 4:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * USD_CAN_RATE).ToString("C2")} Canadian Dollars."); 
            }
            break;
            case 5:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * ((1 - USD_POUND_RATE) + 1)).ToString("C2")} US Dollars."); 
            }
            break;
            case 6:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * ((1 - USD_FRANCS_RATE) + 1)).ToString("C2")} US Dollars."); 
            }
            break;
            case 7:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * ((1 - USD_RUPEES_RATE) + 1)).ToString("C2")} US Dollars."); 
            }
            break;
            case 8:
            {
                System.Console.WriteLine($"{userName}, this conversion gives you {(startNumber * ((1 - USD_CAN_RATE) + 1)).ToString("C2")} US Dollars."); 
            }
            break;
        }
    }
}

static void ProgramExit(string userName)

{
    System.Console.WriteLine($"{userName}, thank you for using the program! This application is now closing.");
}