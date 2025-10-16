// Day 5: Methods
// This program demonstrates method creation, parameters, return values, and organization.
using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎯 DAY 5: METHODS MASTERY");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Basic Arithmetic Methods");
            Console.WriteLine("2. Method Overloading Demo");
            Console.WriteLine("3. Calculator with Methods");
            Console.WriteLine("4. String Manipulation Methods");
            Console.WriteLine("5. Number Analysis Methods");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option (1-6): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    BasicArithmeticMethods();
                    break;
                case "2":
                    MethodOverloadingDemo();
                    break;
                case "3":
                    CalculatorWithMethods();
                    break;
                case "4":
                    StringManipulationMethods();
                    break;
                case "5":
                    NumberAnalysisMethods();
                    break;
                case "6":
                    Console.WriteLine("👋 Thank you for learning about methods!");
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

    static void BasicArithmeticMethods()
    {
        Console.Clear();
        Console.WriteLine("🧮 BASIC ARITHMETIC METHODS");
        Console.WriteLine("=".PadRight(30, '='));

        // Get user input
        double num1 = GetValidDouble("Enter first number: ");
        double num2 = GetValidDouble("Enter second number: ");

        // Call methods and display results
        Console.WriteLine("\n📊 CALCULATION RESULTS:");
        Console.WriteLine("-".PadRight(25, '-'));
        Console.WriteLine($"{num1} + {num2} = {Add(num1, num2)}");
        Console.WriteLine($"{num1} - {num2} = {Subtract(num1, num2)}");
        Console.WriteLine($"{num1} × {num2} = {Multiply(num1, num2)}");
        
        double divisionResult = Divide(num1, num2);
        if (double.IsNaN(divisionResult))
        {
            Console.WriteLine($"{num1} ÷ {num2} = ❌ Cannot divide by zero!");
        }
        else
        {
            Console.WriteLine($"{num1} ÷ {num2} = {divisionResult:F2}");
        }

        Console.WriteLine($"{num1} % {num2} = {Modulus(num1, num2)}");
        Console.WriteLine($"{num1} ^ {num2} = {Power(num1, num2):F2}");
    }

    static void MethodOverloadingDemo()
    {
        Console.Clear();
        Console.WriteLine("🔄 METHOD OVERLOADING DEMO");
        Console.WriteLine("=".PadRight(30, '='));

        // Demonstrate method overloading
        Console.WriteLine("\n🔹 Same method name, different parameters:");
        Console.WriteLine($"Add(5, 7) = {Add(5, 7)}");
        Console.WriteLine($"Add(5.5, 7.3) = {Add(5.5, 7.3)}");
        Console.WriteLine($"Add(5, 7, 9) = {Add(5, 7, 9)}");
        Console.WriteLine($"Add(\"Hello\", \" World\") = {Add("Hello", " World")}");

        // Default parameters
        Console.WriteLine("\n🔹 Methods with default parameters:");
        Console.WriteLine($"Power(2) = {Power(2)}");           // Uses default exponent 2
        Console.WriteLine($"Power(2, 3) = {Power(2, 3)}");    // Uses provided exponent
        Console.WriteLine($"Power(2, 0.5) = {Power(2, 0.5):F2}"); // Square root

        // Optional parameters
        Console.WriteLine("\n🔹 Optional parameters:");
        Console.WriteLine($"FormatName(\"John\") = {FormatName("John")}");
        Console.WriteLine($"FormatName(\"John\", \"Doe\") = {FormatName("John", "Doe")}");
        Console.WriteLine($"FormatName(\"John\", \"Doe\", true) = {FormatName("John", "Doe", true)}");
    }

    static void CalculatorWithMethods()
    {
        Console.Clear();
        Console.WriteLine("🧮 CALCULATOR WITH METHODS");
        Console.WriteLine("=".PadRight(30, '='));

        bool continueCalculating = true;

        while (continueCalculating)
        {
            double num1 = GetValidDouble("\nEnter first number: ");
            char operation = GetValidOperator("Enter operation (+, -, *, /, ^, %): ");
            double num2 = GetValidDouble("Enter second number: ");

            double result = Calculate(num1, operation, num2);

            if (double.IsNaN(result))
            {
                Console.WriteLine("❌ Invalid operation or mathematical error!");
            }
            else
            {
                Console.WriteLine($"✅ Result: {num1} {operation} {num2} = {result:F4}");
            }

            Console.Write("\nPerform another calculation? (yes/no): ");
            continueCalculating = Console.ReadLine()!.ToLower() == "yes";
        }
    }

    static void StringManipulationMethods()
    {
        Console.Clear();
        Console.WriteLine("🔤 STRING MANIPULATION METHODS");
        Console.WriteLine("=".PadRight(30, '='));

        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;

        Console.WriteLine("\n📊 STRING ANALYSIS:");
        Console.WriteLine("-".PadRight(25, '-'));
        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Reversed: {ReverseString(input)}");
        Console.WriteLine($"Uppercase: {ToUpperCase(input)}");
        Console.WriteLine($"Lowercase: {ToLowerCase(input)}");
        Console.WriteLine($"Word count: {CountWords(input)}");
        Console.WriteLine($"Character count: {input.Length}");
        Console.WriteLine($"Is palindrome? {IsPalindrome(input)}");
        Console.WriteLine($"Vowel count: {CountVowels(input)}");
        Console.WriteLine($"Consonant count: {CountConsonants(input)}");

        // String transformation
        Console.WriteLine("\n🎨 STRING TRANSFORMATIONS:");
        Console.WriteLine($"Alternating case: {ToAlternatingCase(input)}");
        Console.WriteLine($"Acronym: {CreateAcronym(input)}");
    }

    static void NumberAnalysisMethods()
    {
        Console.Clear();
        Console.WriteLine("🔢 NUMBER ANALYSIS METHODS");
        Console.WriteLine("=".PadRight(30, '='));

        int number = GetValidInt("Enter a number to analyze: ");

        Console.WriteLine("\n📊 NUMBER ANALYSIS:");
        Console.WriteLine("-".PadRight(25, '-'));
        Console.WriteLine($"Is even? {IsEven(number)}");
        Console.WriteLine($"Is odd? {IsOdd(number)}");
        Console.WriteLine($"Is prime? {IsPrime(number)}");
        Console.WriteLine($"Is perfect? {IsPerfectNumber(number)}");
        Console.WriteLine($"Factorial: {Factorial(number):N0}");
        Console.WriteLine($"Sum of digits: {SumOfDigits(number)}");
        Console.WriteLine($"Reverse digits: {ReverseDigits(number)}");
        Console.WriteLine($"Square root: {Math.Sqrt(number):F2}");

        // Fibonacci sequence
        Console.Write($"\nShow Fibonacci sequence up to {number}? (yes/no): ");
        if (Console.ReadLine()!.ToLower() == "yes")
        {
            Console.WriteLine($"Fibonacci: {string.Join(", ", GenerateFibonacci(number))}");
        }

        // Prime factors
        Console.Write($"Show prime factors of {number}? (yes/no): ");
        if (Console.ReadLine()!.ToLower() == "yes")
        {
            Console.WriteLine($"Prime factors: {string.Join(" × ", GetPrimeFactors(number))}");
        }
    }

    // ==================== ARITHMETIC METHODS ====================

    static int Add(int x, int y) => x + y;
    static double Add(double x, double y) => x + y;
    static int Add(int x, int y, int z) => x + y + z;
    static string Add(string x, string y) => x + y;

    static double Subtract(double x, double y) => x - y;
    static double Multiply(double x, double y) => x * y;
    
    static double Divide(double x, double y)
    {
        return y != 0 ? x / y : double.NaN;
    }

    static double Modulus(double x, double y)
    {
        return y != 0 ? x % y : double.NaN;
    }

    static double Power(double baseNum, double exponent = 2)
    {
        return Math.Pow(baseNum, exponent);
    }

    // ==================== STRING METHODS ====================

    static string ReverseString(string text)
    {
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static string ToUpperCase(string text) => text.ToUpper();
    static string ToLowerCase(string text) => text.ToLower();

    static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        string[] words = text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static bool IsPalindrome(string text)
    {
        string cleanText = new string(text.ToLower().Where(char.IsLetterOrDigit).ToArray());
        return cleanText == ReverseString(cleanText);
    }

    static int CountVowels(string text)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        return text.ToLower().Count(c => vowels.Contains(c));
    }

    static int CountConsonants(string text)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        return text.ToLower().Count(c => char.IsLetter(c) && !vowels.Contains(c));
    }

    static string ToAlternatingCase(string text)
    {
        char[] result = new char[text.Length];
        bool upper = true;
        
        for (int i = 0; i < text.Length; i++)
        {
            result[i] = upper ? char.ToUpper(text[i]) : char.ToLower(text[i]);
            upper = !upper;
        }
        
        return new string(result);
    }

    static string CreateAcronym(string text)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new string(words.Where(w => w.Length > 0).Select(w => char.ToUpper(w[0])).ToArray());
    }

    // ==================== NUMBER METHODS ====================

    static bool IsEven(int number) => number % 2 == 0;
    static bool IsOdd(int number) => number % 2 != 0;

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsPerfectNumber(int number)
    {
        if (number < 2) return false;
        int sum = 1;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                sum += i;
                if (i != number / i) sum += number / i;
            }
        }
        return sum == number;
    }

    static long Factorial(int number)
    {
        if (number < 0) return -1; // Error
        if (number == 0) return 1;
        
        long result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    static int SumOfDigits(int number)
    {
        return Math.Abs(number).ToString().Sum(c => c - '0');
    }

    static int ReverseDigits(int number)
    {
        string reversed = new string(Math.Abs(number).ToString().Reverse().ToArray());
        return int.Parse(reversed) * Math.Sign(number);
    }

    static List<int> GenerateFibonacci(int limit)
    {
        List<int> fibonacci = new List<int>();
        if (limit >= 0) fibonacci.Add(0);
        if (limit >= 1) fibonacci.Add(1);

        while (true)
        {
            int next = fibonacci[^1] + fibonacci[^2];
            if (next > limit) break;
            fibonacci.Add(next);
        }

        return fibonacci;
    }

    static List<int> GetPrimeFactors(int number)
    {
        List<int> factors = new List<int>();
        int n = Math.Abs(number);

        for (int i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
        }

        return factors;
    }

    // ==================== HELPER METHODS ====================

    static double Calculate(double num1, char operation, double num2)
    {
        return operation switch
        {
            '+' => Add(num1, num2),
            '-' => Subtract(num1, num2),
            '*' => Multiply(num1, num2),
            '/' => Divide(num1, num2),
            '%' => Modulus(num1, num2),
            '^' => Power(num1, num2),
            _ => double.NaN
        };
    }

    static string FormatName(string firstName, string lastName = "", bool formal = false)
    {
        if (string.IsNullOrEmpty(lastName))
            return formal ? $"Mr/Ms {firstName}" : firstName;
        
        return formal ? $"{lastName}, {firstName}" : $"{firstName} {lastName}";
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

    static char GetValidOperator(string prompt)
    {
        char[] validOperators = { '+', '-', '*', '/', '%', '^' };
        
        while (true)
        {
            Console.Write(prompt);
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            
            if (validOperators.Contains(input))
                return input;
            
            Console.WriteLine("❌ Please enter a valid operator (+, -, *, /, %, ^)!");
        }
    }
}