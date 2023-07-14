using System;

int coins = 0;
int cardNumber = 0;
int totalPlayer = 0;
int totalCrupier = 0;
int tries = 2;
string chooseGame = "menu";
string anotherCard = "";
System.Random random = new System.Random();

do
{
    Console.WriteLine("Welcome to the CASINO!");
    Console.WriteLine("Enter the amount of coins you want:");
    coins = int.Parse(Console.ReadLine());
    Console.WriteLine("\n");
} while (coins <= 0);

while (coins > 0)
{
    totalPlayer = 0;
    totalCrupier = 0;
    tries = 2;

    switch (chooseGame)
    {
        case "menu":
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine();
            Console.WriteLine("Enter the game you want to play:");
            Console.WriteLine("Write 'blackjack' to play Blackjack");
            Console.WriteLine("Write 'exit' to close  the program");
            chooseGame = Console.ReadLine().ToLower();
            Console.WriteLine();
            break;
        case "blackjack":
            Console.WriteLine("Welcome to Blackjack!");
            tries++;
            cardNumber = random.Next(1, 12);
            totalPlayer += cardNumber;
            Console.WriteLine($"Try: {tries}");
            Console.WriteLine($"Here's your card: {cardNumber}");
            Console.WriteLine($"Here's your total value: {totalPlayer}");

            do
            {
                totalCrupier = random.Next(14, 23);
                Console.WriteLine("Do you want another card? (yes/no)");
                anotherCard = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (anotherCard == "yes")
                {
                    tries++;
                    cardNumber = random.Next(1, 12);
                    totalPlayer += cardNumber;
                    Console.WriteLine($"Try: {tries}");
                    Console.WriteLine($"Here's your card: {cardNumber}");
                    Console.WriteLine($"Here's your total value: {totalPlayer}");

                    if (totalPlayer > 21 && totalCrupier < 22)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You lost, your value is greater than 21");
                        Console.WriteLine();
                        break;
                    }
                    else if (totalPlayer > 21 && totalCrupier > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine("It's a tie");
                        Console.WriteLine();
                        break;
                    }
                }
            } while (anotherCard == "yes" && tries <= 5);

            if (totalPlayer <= 21 && totalPlayer > totalCrupier || (totalPlayer <= 21 && totalCrupier > 21))
            {
                Console.WriteLine("You won, you kick Crupier's ass");
                Console.WriteLine();
            }
            else if (totalPlayer <= totalCrupier && (totalPlayer <= 21 && totalCrupier <= 21))
            {
                Console.WriteLine("You lost, the Crupier beats you");
                Console.WriteLine();
            }

            Console.WriteLine($"The crupier has {totalCrupier}");
            Console.WriteLine();

            coins--;
            chooseGame = "menu";
            break;
        case "exit":
            Console.WriteLine("Bye Lovely!");
            coins = 0;
            break;
        default:
            Console.WriteLine("Invalid value, try again");
            chooseGame = "menu";
            break;
    }
}
