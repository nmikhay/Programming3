using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "customer_data.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            decimal totalPurchases = 0;
            decimal maxPurchases = 0;
            string customerWithMaxPurchases = "";

            foreach (string line in lines)
            {
                string[] customerData = line.Split(',');
                if (customerData.Length == 2)
                {
                    string customerName = customerData[0];
                    decimal purchases;
                    if (decimal.TryParse(customerData[1], out purchases))
                    {
                        totalPurchases += purchases;
                        if (purchases > maxPurchases)
                        {
                            maxPurchases = purchases;
                            customerWithMaxPurchases = customerName;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid purchase amount for customer: {customerName}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid data format: {line}");
                }
            }

            Console.WriteLine($"Total purchases: {totalPurchases}");
            Console.WriteLine($"Customer with the highest purchases: {customerWithMaxPurchases}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found: {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

