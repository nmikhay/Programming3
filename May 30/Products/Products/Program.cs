using System;
using System.Collections.Generic;

enum ProductCategory
{
    Fruits,
    Vegetables,
    Dairy,
    Meats,
    Bakery
}

class InventoryTracker
{
    static void Main()
    {
        List<(string, ProductCategory)> products = new List<(string, ProductCategory)>();

        string productName;
        int categoryChoice;

        Console.WriteLine("Welcome!");

        do
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Finish and see inventory");

            int optionChoice;
            if (!int.TryParse(Console.ReadLine(), out optionChoice) || optionChoice < 1 || optionChoice > 2)
            {
                Console.WriteLine("Invalid option choice. Please try again.");
                Console.WriteLine();
                continue;
            }

            if (optionChoice == 2)
                break;

            Console.WriteLine("Enter the product name:");
            productName = Console.ReadLine();

            Console.WriteLine("Select the product category:");
            Console.WriteLine("1. Fruits");
            Console.WriteLine("2. Vegetables");
            Console.WriteLine("3. Dairy");
            Console.WriteLine("4. Meats");
            Console.WriteLine("5. Bakery");

            if (!int.TryParse(Console.ReadLine(), out categoryChoice) || categoryChoice < 1 || categoryChoice > 5)
            {
                Console.WriteLine("Invalid category choice. Please try again.");
                Console.WriteLine();
                continue;
            }

            ProductCategory productCategory = (ProductCategory)(categoryChoice - 1);
            products.Add((productName, productCategory));

            Console.WriteLine("Product added successfully.");
            Console.WriteLine();
        } while (true);

        Console.WriteLine();
        Console.WriteLine("Inventory List:");
        Console.WriteLine("----------------");

        foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
        {
            Console.WriteLine($"Category: {category}");
            Console.WriteLine("Products:");

            foreach ((string name, ProductCategory prodCategory) in products)
            {
                if (prodCategory == category)
                    Console.WriteLine("- " + name);
            }

            Console.WriteLine();
        }
    }
}