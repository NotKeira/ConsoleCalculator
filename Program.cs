using System;
using System.Threading;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<string> Operations = new List<string>();

        Operations.Add("addition");
        Operations.Add("subtraction");
        Operations.Add("multiplication");
        Operations.Add("division");
        Operations.Add("exponentiation");
        string Type;
        int InputOne,
            InputTwo,
            Answer;

        Console.WriteLine("Welcome to Keira's C Sharp Calculator");
        Console.Write(
            "List of Operations:\n"
                + "1. Addition\n"
                + "2. Subtraction\n"
                + "3. Multiplication\n"
                + "4. Division\n"
                + "5. Exponentiation\n"
        );
        Console.WriteLine(
            "Please enter the name of the operation you wish to complete (case insensitive)"
        );
        Type = Console.ReadLine().ToLower();
        while (!Operations.Contains(Type))
        {
            Console.WriteLine("Invalid Choice. Choose one of the above listed.");
            Type = Console.ReadLine().ToLower();
        }
        ;
        Console.WriteLine("Please enter the 2 Inputs. Please be aware the FIRST number you enter will be divided by the SECOND number. (1/2 = 0.5)");
        InputOne = Convert.ToInt32(Console.ReadLine());
        InputTwo = Convert.ToInt32(Console.ReadLine());
        Answer = 0;
        if (Type == "addition")
        {
            Answer = InputOne + InputTwo;
            Console.WriteLine($"The equation {InputOne}+{InputTwo} responded with {Answer}");
        }
        else if (Type == "subtraction")
        {
            Answer = InputOne - InputTwo;
            Console.WriteLine($"The equation {InputOne}-{InputTwo} responded with {Answer}");
        }
        else if (Type == "multiplication")
        {
            Answer = InputOne * InputTwo;
            Console.WriteLine($"The equation {InputOne}*{InputTwo} responded with {Answer}");
        }
        else if (Type == "division")
        {
            Answer = InputOne / InputTwo;
            Console.WriteLine($"The equation {InputOne}/{InputTwo} responded with {Answer}");
        }
        else if (Type == "exponentiation")
        {
            Answer = Convert.ToInt32(Math.Pow(InputOne, InputTwo));
            Console.WriteLine($"The equation {InputOne}^{InputTwo} responded with {Answer}");
        }
        int max = 3;
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine($"Shutting down in {max - i}");
            Thread.Sleep(1000);
        }
    }
}
