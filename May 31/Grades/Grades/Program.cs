using System;

class StudentGradeTracker
{
    static void Main()
    {
        Console.WriteLine("Enter the number of students:");
        int numStudents = int.Parse(Console.ReadLine());

        string[] studentNames = new string[numStudents];
        int[] studentGrades = new int[numStudents];

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"Enter the name of student {i + 1}:");
            studentNames[i] = Console.ReadLine();

            Console.WriteLine($"Enter the grade for {studentNames[i]}:");
            studentGrades[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the name of a student to retrieve their grade:");
        string searchName = Console.ReadLine();

        int index = Array.IndexOf(studentNames, searchName);

        if (index != -1)
        {
            int grade = studentGrades[index];
            Console.WriteLine($"Grade for {searchName}: {grade}");
        }
        else
        {
            Console.WriteLine($"Student '{searchName}' not found.");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

