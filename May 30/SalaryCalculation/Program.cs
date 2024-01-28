using System;

class SalaryCalculator
{
    static void Main()
    {
        int employmentType;
        double hourlyRate;
        int totalHoursWorked;
        double monthlySalary;
        double totalPay;

        do
        {
            Console.WriteLine("Choose your employment type:");
            Console.WriteLine("1. Hourly");
            Console.WriteLine("2. Monthly");
            Console.WriteLine("Enter '0' to quit");
            Console.Write("Choice: ");
            if (!int.TryParse(Console.ReadLine(), out employmentType))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
                continue;
            }

            if (employmentType == 1)
            {
                Console.Write("Enter your hourly rate: ");
                if (!double.TryParse(Console.ReadLine(), out hourlyRate))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Enter the total hours you worked in the week: ");
                if (!int.TryParse(Console.ReadLine(), out totalHoursWorked))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                if (totalHoursWorked > 40)
                {
                    totalPay = (40 * hourlyRate) + ((totalHoursWorked - 40) * hourlyRate * 1.5);
                }
                else
                {
                    totalPay = totalHoursWorked * hourlyRate;
                }

                Console.WriteLine("Your total weekly pay is: " + totalPay);
            }
            else if (employmentType == 2)
            {
                Console.Write("Enter your monthly salary: ");
                if (!double.TryParse(Console.ReadLine(), out monthlySalary))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("Your monthly salary is: " + monthlySalary);
            }
            else if (employmentType != 0)
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        } while (employmentType != 0);
    }
}
