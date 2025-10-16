// Day 6: Simple Calculator App
// A fully-featured calculator application using all previous concepts
using System;
using System.Collections.Generic;

class Program
{
    private static List<string> calculationHistory = new List<string>();
    private static double memory = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🧮 DAY 6: ADVANCED CALCULATOR APP");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Standard Calculator");
            Console.WriteLine("2. Scientific Calculator");
            Console.WriteLine("3. Calculation History");
            Console.WriteLine("4. Memory Functions");
            Console.WriteLine("5. Unit Converter");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option (1-6): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    StandardCalculator();
                    break;
                case "2":
                    ScientificCalculator();
                    break;
                case "3":
                    ShowCalculationHistory();
                    break;
                case "4":
                    MemoryFunctions();
                    break;
                case "5":
                    UnitConverter();
                    break;
                case "6":
                    Console.WriteLine("👋 Thank you for using the calculator!");
                    return;
                default:
                    Console.WriteLine("❌ Invalid choice! Press any key...");
                    Console.ReadKey();
                    continue;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void StandardCalculator()
    {
        Console.Clear();
        Console.WriteLine("🧮 STANDARD CALCULATOR");
        Console.WriteLine("=".PadRight(30, '='));
        Console.WriteLine("Operations: + - * / % ^ ( )");
        Console.WriteLine("Type 'clear' to reset, 'back' to go back, 'exit' to quit");

        double currentResult = 0;
        string expression = "";

        while (true)
        {
            Console.WriteLine($"\nCurrent: {currentResult}");
            Console.Write("Enter number or operation: ");
            string input = Console.ReadLine()!.ToLower();

            if (input == "exit") return;
            if (input == "back") break;
            if (input == "clear")
            {
                currentResult = 0;
                expression = "";
                Console.WriteLine("✅ Calculator cleared!");
                continue;
            }

            if (double.TryParse(input, out double number))
            {
                if (expression == "")
                {
                    currentResult = number;
                    expression = number.ToString();
                }
                else
                {
                    Console.WriteLine("❌ Enter an operation first!");
                }
            }
            else if (IsOperator(input))
            {
                if (expression == "")
                {
                    Console.WriteLine("❌ Enter a number first!");
                    continue;
                }

                Console.Write("Enter next number: ");
                string nextInput = Console.ReadLine()!.ToLower();

                if (nextInput == "back") break;
                if (nextInput == "clear")
                {
                    currentResult = 0;
                    expression = "";
                    Console.WriteLine("✅ Calculator cleared!");
                    continue;
                }

                if (double.TryParse(nextInput, out double nextNumber))
                {
                    double newResult = Calculate(currentResult, input[0], nextNumber);
                    
                    if (double.IsNaN(newResult))
                    {
                        Console.WriteLine("❌ Mathematical error!");
                    }
                    else
                    {
                        string calculation = $"{expression} {input} {nextNumber} = {newResult}";
                        calculationHistory.Add(calculation);
                        Console.WriteLine($"✅ {calculation}");
                        currentResult = newResult;
                        expression = newResult.ToString();
                    }
                }
                else
                {
                    Console.WriteLine("❌ Invalid number!");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input!");
            }
        }
    }

    static void ScientificCalculator()
    {
        Console.Clear();
        Console.WriteLine("🔬 SCIENTIFIC CALCULATOR");
        Console.WriteLine("=".PadRight(30, '='));

        while (true)
        {
            Console.WriteLine("\nScientific Functions:");
            Console.WriteLine("1. Power (x^y)       2. Square Root (√)");
            Console.WriteLine("3. Sin/Cos/Tan       4. Log/Ln");
            Console.WriteLine("5. Factorial (!)     6. Absolute Value");
            Console.WriteLine("7. Round             8. Back to Main");

            Console.Write("\nChoose function (1-8): ");
            string choice = Console.ReadLine()!;

            if (choice == "8") break;

            double result = double.NaN;
            string operation = "";

            switch (choice)
            {
                case "1":
                    double baseNum = GetValidDouble("Enter base: ");
                    double exponent = GetValidDouble("Enter exponent: ");
                    result = Math.Pow(baseNum, exponent);
                    operation = $"{baseNum} ^ {exponent}";
                    break;

                case "2":
                    double sqrtNum = GetValidDouble("Enter number: ");
                    if (sqrtNum >= 0)
                    {
                        result = Math.Sqrt(sqrtNum);
                        operation = $"√{sqrtNum}";
                    }
                    else
                    {
                        Console.WriteLine("❌ Cannot calculate square root of negative number!");
                    }
                    break;

                case "3":
                    Console.WriteLine("a) Sin  b) Cos  c) Tan");
                    Console.Write("Choose trigonometric function: ");
                    char trigChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    
                    double angle = GetValidDouble("Enter angle in degrees: ");
                    double radians = angle * Math.PI / 180;
                    
                    switch (char.ToLower(trigChoice))
                    {
                        case 'a':
                            result = Math.Sin(radians);
                            operation = $"sin({angle}°)";
                            break;
                        case 'b':
                            result = Math.Cos(radians);
                            operation = $"cos({angle}°)";
                            break;
                        case 'c':
                            result = Math.Tan(radians);
                            operation = $"tan({angle}°)";
                            break;
                        default:
                            Console.WriteLine("❌ Invalid choice!");
                            break;
                    }
                    break;

                case "4":
                    Console.WriteLine("a) Log10  b) Natural Log (Ln)");
                    Console.Write("Choose logarithmic function: ");
                    char logChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    
                    double logNum = GetValidDouble("Enter number: ");
                    
                    if (logNum > 0)
                    {
                        switch (char.ToLower(logChoice))
                        {
                            case 'a':
                                result = Math.Log10(logNum);
                                operation = $"log10({logNum})";
                                break;
                            case 'b':
                                result = Math.Log(logNum);
                                operation = $"ln({logNum})";
                                break;
                            default:
                                Console.WriteLine("❌ Invalid choice!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Logarithm undefined for non-positive numbers!");
                    }
                    break;

                case "5":
                    int factorialNum = GetValidInt("Enter number: ");
                    if (factorialNum >= 0 && factorialNum <= 20)
                    {
                        result = Factorial(factorialNum);
                        operation = $"{factorialNum}!";
                    }
                    else
                    {
                        Console.WriteLine("❌ Please enter number between 0-20!");
                    }
                    break;

                case "6":
                    double absNum = GetValidDouble("Enter number: ");
                    result = Math.Abs(absNum);
                    operation = $"|{absNum}|";
                    break;

                case "7":
                    double roundNum = GetValidDouble("Enter number: ");
                    int decimals = GetValidInt("Enter decimal places: ");
                    result = Math.Round(roundNum, decimals);
                    operation = $"round({roundNum}, {decimals})";
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice!");
                    continue;
            }

            if (!double.IsNaN(result))
            {
                string calculation = $"{operation} = {result}";
                calculationHistory.Add(calculation);
                Console.WriteLine($"✅ {calculation}");
            }
        }
    }

    static void ShowCalculationHistory()
    {
        Console.Clear();
        Console.WriteLine("📋 CALCULATION HISTORY");
        Console.WriteLine("=".PadRight(30, '='));

        if (calculationHistory.Count == 0)
        {
            Console.WriteLine("No calculations yet!");
            return;
        }

        Console.WriteLine($"Total calculations: {calculationHistory.Count}\n");
        
        for (int i = 0; i < calculationHistory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {calculationHistory[i]}");
        }

        Console.WriteLine("\nOptions:");
        Console.WriteLine("1. Clear history");
        Console.WriteLine("2. Back to main");
        
        Console.Write("\nChoose option: ");
        string choice = Console.ReadLine()!;

        if (choice == "1")
        {
            calculationHistory.Clear();
            Console.WriteLine("✅ History cleared!");
        }
    }

    static void MemoryFunctions()
    {
        Console.Clear();
        Console.WriteLine("💾 MEMORY FUNCTIONS");
        Console.WriteLine("=".PadRight(30, '='));
        Console.WriteLine($"Current Memory: {memory}");

        while (true)
        {
            Console.WriteLine("\nMemory Operations:");
            Console.WriteLine("1. Memory Store (MS)");
            Console.WriteLine("2. Memory Recall (MR)");
            Console.WriteLine("3. Memory Add (M+)");
            Console.WriteLine("4. Memory Subtract (M-)");
            Console.WriteLine("5. Memory Clear (MC)");
            Console.WriteLine("6. Back to Main");

            Console.Write("\nChoose operation (1-6): ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1": // MS
                    memory = GetValidDouble("Enter value to store: ");
                    Console.WriteLine($"✅ Memory stored: {memory}");
                    break;

                case "2": // MR
                    Console.WriteLine($"📋 Memory recall: {memory}");
                    break;

                case "3": // M+
                    double addValue = GetValidDouble("Enter value to add: ");
                    memory += addValue;
                    Console.WriteLine($"✅ Memory updated: {memory}");
                    break;

                case "4": // M-
                    double subValue = GetValidDouble("Enter value to subtract: ");
                    memory -= subValue;
                    Console.WriteLine($"✅ Memory updated: {memory}");
                    break;

                case "5": // MC
                    memory = 0;
                    Console.WriteLine("✅ Memory cleared!");
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("❌ Invalid choice!");
                    break;
            }
        }
    }

    static void UnitConverter()
    {
        Console.Clear();
        Console.WriteLine("📐 UNIT CONVERTER");
        Console.WriteLine("=".PadRight(30, '='));

        while (true)
        {
            Console.WriteLine("\nConversion Types:");
            Console.WriteLine("1. Temperature");
            Console.WriteLine("2. Length");
            Console.WriteLine("3. Weight");
            Console.WriteLine("4. Back to Main");

            Console.Write("\nChoose type (1-4): ");
            string choice = Console.ReadLine()!;

            if (choice == "4") break;

            switch (choice)
            {
                case "1": // Temperature
                    TemperatureConversion();
                    break;

                case "2": // Length
                    LengthConversion();
                    break;

                case "3": // Weight
                    WeightConversion();
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice!");
                    break;
            }
        }
    }

    static void TemperatureConversion()
    {
        Console.WriteLine("\n🌡️ TEMPERATURE CONVERSION");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.WriteLine("3. Celsius to Kelvin");

        Console.Write("Choose conversion: ");
        string convChoice = Console.ReadLine()!;

        double value = GetValidDouble("Enter temperature: ");
        double result = 0;
        string conversion = "";

        switch (convChoice)
        {
            case "1":
                result = (value * 9 / 5) + 32;
                conversion = $"{value}°C = {result}°F";
                break;
            case "2":
                result = (value - 32) * 5 / 9;
                conversion = $"{value}°F = {result}°C";
                break;
            case "3":
                result = value + 273.15;
                conversion = $"{value}°C = {result}K";
                break;
            default:
                Console.WriteLine("❌ Invalid choice!");
                return;
        }

        calculationHistory.Add(conversion);
        Console.WriteLine($"✅ {conversion}");
    }

    static void LengthConversion()
    {
        Console.WriteLine("\n📏 LENGTH CONVERSION");
        Console.WriteLine("1. Meters to Feet");
        Console.WriteLine("2. Feet to Meters");
        Console.WriteLine("3. Kilometers to Miles");

        Console.Write("Choose conversion: ");
        string convChoice = Console.ReadLine()!;

        double value = GetValidDouble("Enter length: ");
        double result = 0;
        string conversion = "";

        switch (convChoice)
        {
            case "1":
                result = value * 3.28084;
                conversion = $"{value}m = {result:F2}ft";
                break;
            case "2":
                result = value / 3.28084;
                conversion = $"{value}ft = {result:F2}m";
                break;
            case "3":
                result = value * 0.621371;
                conversion = $"{value}km = {result:F2}mi";
                break;
            default:
                Console.WriteLine("❌ Invalid choice!");
                return;
        }

        calculationHistory.Add(conversion);
        Console.WriteLine($"✅ {conversion}");
    }

    static void WeightConversion()
    {
        Console.WriteLine("\n⚖️ WEIGHT CONVERSION");
        Console.WriteLine("1. Kilograms to Pounds");
        Console.WriteLine("2. Pounds to Kilograms");

        Console.Write("Choose conversion: ");
        string convChoice = Console.ReadLine()!;

        double value = GetValidDouble("Enter weight: ");
        double result = 0;
        string conversion = "";

        switch (convChoice)
        {
            case "1":
                result = value * 2.20462;
                conversion = $"{value}kg = {result:F2}lb";
                break;
            case "2":
                result = value / 2.20462;
                conversion = $"{value}lb = {result:F2}kg";
                break;
            default:
                Console.WriteLine("❌ Invalid choice!");
                return;
        }

        calculationHistory.Add(conversion);
        Console.WriteLine($"✅ {conversion}");
    }

    // ==================== HELPER METHODS ====================

    static bool IsOperator(string input)
    {
        char[] operators = { '+', '-', '*', '/', '%', '^' };
        return input.Length == 1 && operators.Contains(input[0]);
    }

    static double Calculate(double num1, char operation, double num2)
    {
        return operation switch
        {
            '+' => num1 + num2,
            '-' => num1 - num2,
            '*' => num1 * num2,
            '/' => num2 != 0 ? num1 / num2 : double.NaN,
            '%' => num2 != 0 ? num1 % num2 : double.NaN,
            '^' => Math.Pow(num1, num2),
            _ => double.NaN
        };
    }

    static long Factorial(int n)
    {
        if (n < 0) return -1;
        if (n == 0) return 1;
        
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static double GetValidDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            Console.WriteLine("❌ Please enter a valid number!");
        }
    }

    static int GetValidInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("❌ Please enter a valid integer!");
        }
    }
}