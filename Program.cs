using System;

// Interface for student operations
interface IStudent
{
    void Details();
    void Calculate();
    void Result();
}

// Student class implements the interface
class Student : IStudent
{
    string name;
    int[] marks = new int[5];
    int total;
    float average;
    string grade;

    public void Details()
    {
        Console.Write("Enter student name: ");
        name = Console.ReadLine();

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter marks for Subject {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out marks[i]) || marks[i] < 0 || marks[i] > 100)
            {
                Console.Write("Invalid input. Enter marks (0-100): ");
            }
        }
    }

    public void Calculate()
    {
        total = 0;
        foreach (int mark in marks)
        {
            total += mark;
        }

        average = total / 5.0f;

        if (average >= 90) 
             grade = "A+";
        else if (average >= 80) 
             grade = "A";
        else if (average >= 70) 
             grade = "B";
        else if (average >= 60) 
             grade = "C";
        else if (average >= 50) 
             grade = "D";
        else 
              grade = "F";
    }

    public void Result()
    {
        Console.WriteLine("\n--- Student Report ---");
        Console.WriteLine($"Name   : {name}");
        Console.WriteLine($"Total  : {total}/500");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Grade  : {grade}");
    }
}

// Main program
class Program
{
    static void Main()
    {
        Console.Write("Enter the number of students: ");
        int count;

        // Validate input for number of students
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Invalid number. Enter a positive integer: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n--- Entering details for Student {i + 1} ---");

            IStudent student = new Student();
            student.Details();
            student.Calculate();
            student.Result();
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

