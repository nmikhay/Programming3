using System;

class Dice
{
    public int Sides { get; }
    public int Value { get; private set; }
    private Random random;

    public Dice(int sides)
    {
        Sides = sides;
        random = new Random();
    }

    public void Roll()
    {
        Value = random.Next(1, Sides + 1);
    }

    public override string ToString()
    {
        return $"Dice Value: {Value}";
    }
}

class DiceGame
{
    static void Main()
    {
        Console.WriteLine("Enter the number of players:");
        int numPlayers = int.Parse(Console.ReadLine());

        Dice[] diceArray = new Dice[numPlayers];

        for (int i = 0; i < numPlayers; i++)
        {
            diceArray[i] = new Dice(6);
        }

        Console.WriteLine("Rolling the dice...");

        int maxRoll = 0;
        int winningPlayer = -1;

        for (int i = 0; i < numPlayers; i++)
        {
            diceArray[i].Roll();
            Console.WriteLine($"Player {i + 1}: {diceArray[i]}");

            if (diceArray[i].Value > maxRoll)
            {
                maxRoll = diceArray[i].Value;
                winningPlayer = i + 1;
            }
        }

        Console.WriteLine($"Player {winningPlayer} wins with the highest roll of {maxRoll}!");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

