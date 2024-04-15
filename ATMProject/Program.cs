using ATMProject;

void printOptions()
{
    Console.WriteLine("Please choose from one of the following options.....");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Show Balance");
    Console.WriteLine("4. Exit");
}

void deposit(CardHolder currentUser)
{
    Console.WriteLine("How much $$ would you like to deposit: ");
    double deposit = double.Parse(Console.ReadLine());
    currentUser.setBalance(deposit);
    Console.WriteLine("Thank you for depositing your money. Your new balance is:  " + currentUser.getBalance());
}

void withdrawal(CardHolder currentUser)
{
    Console.WriteLine("How much $$ would you like to withdraw: ");
    double Withdrawal = double.Parse(Console.ReadLine());
    //check if the user has enough money
    if (currentUser.getBalance() > Withdrawal)
    {
        Console.WriteLine("Insufficient balance: (");
    }
    else
    {
        currentUser.setBalance(currentUser.getBalance() - Withdrawal);
        Console.WriteLine("You're good to go! Thank you :)");
    }

}
void balance(CardHolder currentUser)
{
    Console.WriteLine("Current balance: " + currentUser.getBalance()); //It took me hours to spot this error. I declared cardUser instead of currentUser
}

List<CardHolder> CardHolders = new List<CardHolder>();
CardHolders.Add(new CardHolder("4563783644936373", 1234, "John", "Griffith", 9070.31));
CardHolders.Add(new CardHolder("4563783574436373", 4334, "Ashley", "Bald", 9050.31));
CardHolders.Add(new CardHolder("4563783644178373", 1084, "Fred", "Saint", 5650.31));
CardHolders.Add(new CardHolder("4534583644936373", 1230, "Vic", "Gold", 9870.31));
CardHolders.Add(new CardHolder("4563783644936309", 1239, "Bola", "Greg", 1090.31));

//Prompt User
Console.WriteLine("Welcome to my ATM Gallery");
Console.WriteLine("Please insert your debit card");
string debitCardNum = "";
CardHolder currentUser;

while (true)
{
    try
    {
        debitCardNum = Console.ReadLine();
        // Check against our db
        currentUser = CardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
        if (currentUser != null) { break; }
        else { Console.WriteLine("Card not recognised. Please try again"); }
    }
    catch { Console.WriteLine("Incorrect pin. Please try again "); }
}

Console.WriteLine("Welcome" + currentUser.getfirstName() + " : )");
int option = 0;
while (true)
{
    try
    {
        int userPin = int.Parse(Console.ReadLine());
        if (currentUser.getPin() == userPin) { break; }
        else { Console.WriteLine("Incorrect Pin. Please try again"); }
    }
    catch { Console.WriteLine("Incorrect Pin. Please try again"); }
}

Console.WriteLine("Welcome " + currentUser.getfirstName() + " : )");
int Option = 0;
do
{

    printOptions();
    try
    {
        option = int.Parse(Console.ReadLine());
    }
    catch { }
    if (option == 1) { deposit(currentUser); }
    else if (option == 2) { withdrawal(currentUser); }
    else if (option == 3) { deposit(currentUser); }
    else if (option == 4) { break; }
    else { option = 0; }
}
while (option != 4);
Console.WriteLine("Thank you! Have a nice a day :)");