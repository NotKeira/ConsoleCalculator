using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Keira's C Sharp Calculator");

        string input = GetEquationFromUser();
        double result = EvaluateExpression(input);

        Console.WriteLine($"Result: {result}");

        int max = 3;
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine($"Shutting down in {max - i}");
            Thread.Sleep(1000);
        }
    }

    static string GetEquationFromUser()
    {
        Console.WriteLine("Please enter an equation:");
        return Console.ReadLine();
    }

    static double EvaluateExpression(string equation)
    {
        equation = equation.Replace(" ", "");
        equation = ReplaceVariablesWithValues(equation);

        if (equation.Contains("("))
        {
            equation = EvaluateInnermostParentheses(equation);
        }
        else if (equation.Contains("^"))
        {
            equation = EvaluateExponentiation(equation);
        }
        else if (equation.Contains("x"))
        {
            return HandleAlgebraicTerm();
        }

        double result = Evaluate(equation);

        return result;
    }

    static string ReplaceVariablesWithValues(string equation)
    {
        var variables = Regex.Matches(equation, @"\b[a-zA-Z]+\b");
        foreach (Match variable in variables)
        {
            string variableName = variable.Value;
            string variableValue = GetVariableValue(variableName);
            equation = equation.Replace(variableName, variableValue);
        }
        return equation;
    }

    static string EvaluateInnermostParentheses(string equation)
    {
        string pattern = @"\(([^()]+)\)";
        Match match = Regex.Match(equation, pattern);
        if (match.Success)
        {
            string innerExpression = match.Groups[1].Value;
            double innerResult = EvaluateExpression(innerExpression);
            equation = equation.Replace(match.Value, innerResult.ToString());
        }
        return equation;
    }

    static string EvaluateExponentiation(string equation)
    {
        string pattern = @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)";
        Match match = Regex.Match(equation, pattern);
        if (match.Success)
        {
            double baseValue = double.Parse(match.Groups[1].Value);
            double exponentValue = double.Parse(match.Groups[3].Value);
            double result = Math.Pow(baseValue, exponentValue);
            equation = equation.Replace(match.Value, result.ToString());
        }
        return equation;
    }

    static double Evaluate(string expression)
    {
        try
        {
            DataTable dataTable = new DataTable();
            var result = dataTable.Compute(expression, "");
            return Convert.ToDouble(result);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Expression evaluation failed: {ex.Message}");
        }
    }

    static string GetVariableValue(string variableName)
    {
        Console.Write($"Enter the value for {variableName}: ");
        return Console.ReadLine();
    }

    static double HandleAlgebraicTerm()
    {
        Console.WriteLine("Algebraic terms have not been implemented yet.");
        return 0;
    }
}
