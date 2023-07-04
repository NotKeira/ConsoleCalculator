using System;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;

class Program
{
    static void Main(string[] args)
    {
        List<string> operations = new List<string>();

        operations.Add("addition");
        operations.Add("subtraction");
        operations.Add("multiplication");
        operations.Add("division");
        operations.Add("exponentiation");
        string type;
        int input_1, input_2, output;
        
        Console.WriteLine("Welcome to Keira's C Sharp Calculator");
        Console.Write("List of Operations:\n" +
            "1. Addition\n" +
            "2. Subtraction\n" +
            "3. Multiplication\n" +
            "4. Division\n" +
            "5. Exponentiation\n");
        Console.WriteLine("Please enter the name of the operation you wish to complete (case insensitive)");
       type = Console.ReadLine().ToLower();
        while (!operations.Contains(type))
        {
            Console.WriteLine("Invalid Choice. Choose one of the above listed.");
            type = Console.ReadLine().ToLower();
        };
        Console.WriteLine("Please enter the numbers you wish to add together: ");
        input_1 = Convert.ToInt32(Console.ReadLine());
        input_2 = Convert.ToInt32(Console.ReadLine());
        output = 0;
        if (type == "addition")
        {
            output = input_1 + input_2;
        }
        else if (type == "subtraction")
        {
            output = input_1 - input_2;
        }
            else if (type == "multiplication")
        {
            output = input_1 * input_2;
        }
        else if (type == "division")
        {
            output = input_1 / input_2;
        }
        else if (type == "exponentiation")
        {
            output = Convert.ToInt32(Math.Pow(input_1, input_2));
        }
        Console.WriteLine($"The output of the operation ({type}) outputted as {output}");
        for (int i=0; i <5; i++)
        {
            Console.WriteLine($"Shutting down in {5-i}");
            Thread.Sleep(1000);
        }
        
    }
}