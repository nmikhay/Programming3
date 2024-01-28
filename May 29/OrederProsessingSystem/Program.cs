using System;

namespace OrderProcessingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int OrderNumber = 1; OrderNumber <= 5; OrderNumber++)
            {
                Console.WriteLine("Welcome to our bookstore");
                Console.WriteLine("1. Buy a book");
                Console.WriteLine("2. Buy a magazine");
                Console.WriteLine("3. Buy a newspaper");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");

                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice))
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("You've chosen a book. Enjoy reading!");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("You've chosen a magazine. Happy reading!");
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("You've chosen a newspaper. Stay informed!");
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Thank you for visiting our store!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please choose a number between 1 and 4.");
                    }

                    Console.WriteLine($"Processing order number: {OrderNumber}");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine();
            }
        }
    }
}


