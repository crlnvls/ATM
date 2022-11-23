using System;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;

    }

    public string getFirstName()
    {
        return firstName;

    }

    public string getLastName()
    {
        return lastName;

    }

    public double getBalance()
    {
        return balance;

    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFisrtName(String newFirstName)
    {
        firstName= newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to withdraw: ");
            double withdrawal = double.Parse(Console.ReadLine());
            // Checkif the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you!");
            };
            
        }

        void balanceUser(CardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("165924", 1798, "Antony", "Wright", 254.53));
        cardHolders.Add(new CardHolder("486385", 2063, "Albert", "Harper", 263.33));
        cardHolders.Add(new CardHolder("358865", 4120, "Mary", "Foster", 260.01));
        cardHolders.Add(new CardHolder("797984", 9122, "Emma", "Crawford", 785.29));
        cardHolders.Add(new CardHolder("483032", 2954, "Roman", "Bennett", 570.78));

        // Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                { break; }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }
        }


        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2)
                {
                    withdraw(currentUser);
                }
                else if (option == 3)
                {
                    balanceUser(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    option = 0;
                }
            }
            catch
            {
                Console.WriteLine("There's been a error!");
            }
           
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");

    }

}

 			
				
				
				
				