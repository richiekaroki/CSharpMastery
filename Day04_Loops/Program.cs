// Day 4: Loops
// This program includes multiple challenges to practice loops in C#.
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Constants for games
    private const int MIN_GUESSING_RANGE = 1;
    private const int MAX_GUESSING_RANGE = 100;
    private const int DEFAULT_MAX_ATTEMPTS = 7;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🔄 DAY 4: LOOPS MASTERY");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Basic Loops Demo");
            Console.WriteLine("2. Multiplication Table Challenge");
            Console.WriteLine("3. Number Guessing Game");
            Console.WriteLine("4. Sum & Average Calculator");
            Console.WriteLine("5. Loop Patterns & Challenges");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option (1-6): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    BasicLoopsDemo();
                    break;
                case "2":
                    MultiplicationTable();
                    break;
                case "3":
                    GuessingGame();
                    break;
                case "4":
                    SumAndAverage();
                    break;
                case "5":
                    LoopPatterns();
                    break;
                case "6":
                    Console.WriteLine("👋 Thank you for practicing loops!");
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

    static void BasicLoopsDemo()
    {
        Console.Clear();
        Console.WriteLine("🔁 BASIC LOOPS DEMO");
        Console.WriteLine("=".PadRight(30, '='));

        Console.WriteLine("\n📊 FOR LOOP (1 to 5):");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"   Iteration {i}");
        }

        Console.WriteLine("\n📊 WHILE LOOP (5 to 1):");
        int j = 5;
        while (j > 0)
        {
            Console.WriteLine($"   Countdown: {j}");
            j--; // j = j - 1
        }

        Console.WriteLine("\n📊 DO-WHILE LOOP (at least once):");
        int k = 1;
        do
        {
            Console.WriteLine($"   This runs at least once: {k}");
            k++;
        } while (k <= 3);

        Console.WriteLine("\n📊 LOOP WITH CONDITIONS:");
        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($"   {i} is even");
            }
            else
            {
                Console.WriteLine($"   {i} is odd");
            }
        }

        Console.WriteLine("\n📊 NESTED LOOPS (Mini Table):");
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 1; col <= 3; col++)
            {
                Console.Write($"   {row * col}\t");
            }
            Console.WriteLine();
        }
    }

    static void MultiplicationTable()
    {
        Console.Clear();
        Console.WriteLine("🧮 MULTIPLICATION TABLE CHALLENGE");
        Console.WriteLine("=".PadRight(30, '='));

        int number = GetValidInt("Enter a number: ");
        int size = GetValidIntInRange("Enter table size: ", 1, 20);

        Console.WriteLine($"\n📋 Multiplication Table for {number}:");
        Console.WriteLine("-".PadRight(25, '-'));

        for (int i = 1; i <= size; i++)
        {
            int result = number * i;
            Console.WriteLine($"   {number,2} × {i,2} = {result,3}");
        }

        // Bonus: Show even results in different format
        Console.WriteLine("\n🎨 Even results highlighted:");
        for (int i = 1; i <= size; i++)
        {
            int result = number * i;
            if (result % 2 == 0)
            {
                Console.WriteLine($"   {number} × {i} = {result} ← EVEN");
            }
            else
            {
                Console.WriteLine($"   {number} × {i} = {result}");
            }
        }

        // Bonus: Reverse table
        Console.WriteLine($"\n📋 Reverse Table ({size} to 1):");
        for (int i = size; i >= 1; i--)
        {
            int result = number * i;
            Console.WriteLine($"   {number} × {i} = {result}");
        }
    }

    static void GuessingGame()
    {
        Console.Clear();
        Console.WriteLine("🎮 NUMBER GUESSING GAME");
        Console.WriteLine("=".PadRight(30, '='));

        Random random = new Random();
        int secretNumber = random.Next(MIN_GUESSING_RANGE, MAX_GUESSING_RANGE + 1);
        int attempts = 0;
        int maxAttempts = DEFAULT_MAX_ATTEMPTS;
        int previousGuess = -1;
        bool won = false;

        Console.WriteLine($"I'm thinking of a number between {MIN_GUESSING_RANGE} and {MAX_GUESSING_RANGE}.");
        Console.WriteLine($"You have {maxAttempts} attempts to guess it!");

        while (attempts < maxAttempts && !won)
        {
            attempts++;
            int remaining = maxAttempts - attempts + 1;

            int guess = GetValidIntInRange($"\nAttempt {attempts}/{maxAttempts} - Enter your guess: ",
                MIN_GUESSING_RANGE, MAX_GUESSING_RANGE);

            if (guess == secretNumber)
            {
                Console.WriteLine($"🎉 CONGRATULATIONS! You guessed it in {attempts} attempts!");
                won = true;
            }
            else
            {
                // Give better hints
                if (previousGuess != -1)
                {
                    int previousDiff = Math.Abs(previousGuess - secretNumber);
                    int currentDiff = Math.Abs(guess - secretNumber);

                    if (currentDiff < previousDiff)
                    {
                        Console.WriteLine("🔥 Getting warmer!");
                    }
                    else if (currentDiff > previousDiff)
                    {
                        Console.WriteLine("❄️  Getting colder!");
                    }
                }

                if (guess < secretNumber)
                {
                    Console.WriteLine($"📈 Too low! {remaining} attempts remaining.");
                }
                else
                {
                    Console.WriteLine($"📉 Too high! {remaining} attempts remaining.");
                }

                previousGuess = guess;
            }
        }

        if (!won)
        {
            Console.WriteLine($"\n💔 Game over! The number was {secretNumber}.");
            Console.WriteLine($"🔍 You were {Math.Abs(previousGuess - secretNumber)} numbers away.");
        }

        // Show performance rating
        if (attempts <= 3 && won)
        {
            Console.WriteLine("🏆 Expert level!");
        }
        else if (attempts <= 5 && won)
        {
            Console.WriteLine("👍 Good job!");
        }
    }

    static void SumAndAverage()
    {
        Console.Clear();
        Console.WriteLine("🧮 SUM & AVERAGE CALCULATOR");
        Console.WriteLine("=".PadRight(30, '='));

        int count = GetValidIntInRange("How many numbers do you want to enter? ", 1, 50);

        int sum = 0;
        int smallest = int.MaxValue;
        int largest = int.MinValue;
        int positiveCount = 0, negativeCount = 0, zeroCount = 0;

        List<int> numbers = new List<int>();

        Console.WriteLine($"\nEnter {count} numbers:");

        for (int i = 1; i <= count; i++)
        {
            int number = GetValidInt($"Number {i}: ");

            sum += number;
            numbers.Add(number);

            if (number < smallest) smallest = number;
            if (number > largest) largest = number;

            // Count positive/negative/zero
            if (number > 0) positiveCount++;
            else if (number < 0) negativeCount++;
            else zeroCount++;
        }

        double average = (double)sum / count;

        Console.WriteLine("\n📊 RESULTS:");
        Console.WriteLine("-".PadRight(25, '-'));
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Smallest: {smallest}");
        Console.WriteLine($"Largest: {largest}");
        Console.WriteLine($"Range: {largest - smallest}");
        Console.WriteLine($"Positive numbers: {positiveCount}");
        Console.WriteLine($"Negative numbers: {negativeCount}");
        Console.WriteLine($"Zeros: {zeroCount}");

        // Bonus: Even/Odd breakdown
        Console.Write($"\nWant to see even/odd breakdown? (yes/no): ");
        if (Console.ReadLine()!.ToLower() == "yes")
        {
            int evenCount = numbers.Count(n => n % 2 == 0);
            int oddCount = numbers.Count(n => n % 2 != 0);

            Console.WriteLine("\n🔢 EVEN/ODD BREAKDOWN:");
            Console.WriteLine($"Even numbers: {evenCount}");
            Console.WriteLine($"Odd numbers: {oddCount}");

            // Bonus: Show the actual even and odd numbers
            Console.Write("\nShow which numbers are even/odd? (yes/no): ");
            if (Console.ReadLine()!.ToLower() == "yes")
            {
                Console.WriteLine("\nEven numbers: " + string.Join(", ", numbers.Where(n => n % 2 == 0)));
                Console.WriteLine("Odd numbers: " + string.Join(", ", numbers.Where(n => n % 2 != 0)));
            }
        }

        // Statistical analysis
        if (count >= 3)
        {
            double median = CalculateMedian(numbers);
            Console.WriteLine($"\n📈 Statistical Analysis:");
            Console.WriteLine($"Median: {median}");
            Console.WriteLine($"Mode: {FindMode(numbers)}");
        }
    }

    static void LoopPatterns()
    {
        Console.Clear();
        Console.WriteLine("🔷 LOOP PATTERNS & CHALLENGES");
        Console.WriteLine("=".PadRight(30, '='));

        // Pattern 1: Pyramid
        Console.WriteLine("\n🔺 PATTERN 1: NUMBER PYRAMID");
        int height = GetValidIntInRange("Enter pyramid height: ", 1, 10);

        for (int i = 1; i <= height; i++)
        {
            // Spaces for centering
            Console.Write(new string(' ', (height - i) * 2));

            // Numbers
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} ");
            }

            // Reverse numbers
            for (int j = i - 1; j >= 1; j--)
            {
                Console.Write($"{j} ");
            }

            Console.WriteLine();
        }

        // Pattern 2: Fibonacci Sequence
        Console.WriteLine("\n🔢 PATTERN 2: FIBONACCI SEQUENCE");
        int fibCount = GetValidIntInRange("How many Fibonacci numbers? ", 1, 20);

        long a = 0, b = 1;
        Console.Write("Fibonacci: ");

        for (int i = 0; i < fibCount; i++)
        {
            Console.Write($"{a} ");
            long temp = a;
            a = b;
            b = temp + b;
        }
        Console.WriteLine();

        // Challenge: Prime Numbers
        Console.WriteLine("\n🎯 CHALLENGE: PRIME NUMBER FINDER");
        int limit = GetValidIntInRange("Find primes up to: ", 2, 100);

        Console.Write($"Prime numbers up to {limit}: ");
        for (int number = 2; number <= limit; number++)
        {
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.Write($"{number} ");
            }
        }
        Console.WriteLine();

        // Challenge: Factorial Calculator
        Console.WriteLine("\n🧮 CHALLENGE: FACTORIAL CALCULATOR");
        int factorialNum = GetValidIntInRange("Enter number for factorial: ", 0, 20);

        long factorial = 1;
        for (int i = 1; i <= factorialNum; i++)
        {
            factorial *= i;
        }
        Console.WriteLine($"{factorialNum}! = {factorial:N0}");
    }

    // ==================== HELPER METHODS ====================

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

    static int GetValidIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            int result = GetValidInt(prompt);
            if (result >= min && result <= max)
                return result;
            Console.WriteLine($"❌ Please enter a number between {min} and {max}!");
        }
    }

    static double CalculateMedian(List<int> numbers)
    {
        var sorted = numbers.OrderBy(n => n).ToList();
        int count = sorted.Count;

        if (count % 2 == 0)
        {
            return (sorted[count / 2 - 1] + sorted[count / 2]) / 2.0;
        }
        else
        {
            return sorted[count / 2];
        }
    }

    static string FindMode(List<int> numbers)
    {
        var groups = numbers.GroupBy(n => n)
                           .OrderByDescending(g => g.Count())
                           .ThenBy(g => g.Key);

        var mostFrequent = groups.First();
        return $"{mostFrequent.Key} (appears {mostFrequent.Count()} times)";
    }
}