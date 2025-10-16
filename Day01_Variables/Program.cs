// Day 1: Variables & Data Types
// This program demonstrates the use of variables and data types in C#.
using System;

class Program
{
    // Constants for validation
    private const int MIN_AGE = 1;
    private const int MAX_AGE = 120;
    private const decimal MIN_SALARY = 0;
    private const decimal MAX_SALARY = 1000000;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎯 DAY 1: VARIABLES & DATA TYPES");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Run Basic Examples");
            Console.WriteLine("2. Create Personal Bio (Fixed)");
            Console.WriteLine("3. Create Interactive Bio");
            Console.WriteLine("4. Data Type Challenges");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option (1-5): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    RunBasicExamples();
                    break;
                case "2":
                    RunFixedBio();
                    break;
                case "3":
                    RunInteractiveBio();
                    break;
                case "4":
                    DataTypeChallenges();
                    break;
                case "5":
                    Console.WriteLine("👋 Thank you for learning about variables and data types!");
                    return;
                default:
                    Console.WriteLine("❌ Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }

    static void RunBasicExamples()
    {
        Console.Clear();
        Console.WriteLine("📘 BASIC VARIABLES EXAMPLES");
        Console.WriteLine("=".PadRight(40, '='));

        // Example 1: Basic Variables
        Console.WriteLine("\n🎯 EXAMPLE 1: BASIC VARIABLE TYPES");
        Console.WriteLine("-".PadRight(30, '-'));

        int age = 25;
        double salary = 55000.50;
        string name = "Richard";
        bool employed = true;
        char grade = 'A';
        decimal preciseValue = 123.456m;
        DateTime birthDate = new DateTime(1998, 5, 15);

        Console.WriteLine($"🔹 int: Age = {age}");
        Console.WriteLine($"🔹 double: Salary = {salary:C}");
        Console.WriteLine($"🔹 string: Name = {name}");
        Console.WriteLine($"🔹 bool: Employed = {employed}");
        Console.WriteLine($"🔹 char: Grade = {grade}");
        Console.WriteLine($"🔹 decimal: Precise Value = {preciseValue}");
        Console.WriteLine($"🔹 DateTime: Birth Date = {birthDate:yyyy-MM-dd}");

        // Example 2: Variable Operations
        Console.WriteLine("\n🎯 EXAMPLE 2: VARIABLE OPERATIONS");
        Console.WriteLine("-".PadRight(30, '-'));

        int yearsToRetire = 65 - age;
        double monthlySalary = salary / 12;
        string fullGreeting = $"Hello, {name}!";
        bool canVote = age >= 18;
        int daysAlive = (DateTime.Now - birthDate).Days;

        Console.WriteLine($"Years to retirement: {yearsToRetire}");
        Console.WriteLine($"Monthly salary: {monthlySalary:C}");
        Console.WriteLine($"Greeting: {fullGreeting}");
        Console.WriteLine($"Can vote: {canVote}");
        Console.WriteLine($"Days alive: {daysAlive:N0}");

        // Example 3: Type Demonstrations
        Console.WriteLine("\n🎯 EXAMPLE 3: DATA TYPE RANGES & DEFAULTS");
        Console.WriteLine("-".PadRight(30, '-'));

        Console.WriteLine($"int range: {int.MinValue:N0} to {int.MaxValue:N0}");
        Console.WriteLine($"double range: {double.MinValue:E} to {double.MaxValue:E}");
        Console.WriteLine($"char size: {sizeof(char)} bytes");
        Console.WriteLine($"bool default: {default(bool)}");
        Console.WriteLine($"DateTime now: {DateTime.Now}");
    }

    static void RunFixedBio()
    {
        Console.Clear();
        Console.WriteLine("📗 FIXED PERSONAL BIO");
        Console.WriteLine("=".PadRight(40, '='));

        string myName = "Alex";
        int myAge = 28;
        string course = "C# Mastery 28-Day Challenge";
        string currentRole = "Software Developer";
        double yearsOfExperience = 3.5;
        bool isEnrolled = true;
        string skills = "C#, SQL, JavaScript, Git, Problem Solving";
        char englishLevel = 'C';
        decimal targetSalary = 85000.00m;
        DateTime courseStartDate = new DateTime(2024, 1, 1);

        Console.WriteLine("🌟 PERSONAL DEVELOPER PROFILE");
        Console.WriteLine("=".PadRight(35, '='));

        Console.WriteLine($"👤 Name: {myName}");
        Console.WriteLine($"🎂 Age: {myAge}");
        Console.WriteLine($"💼 Current Role: {currentRole}");
        Console.WriteLine($"📚 Experience: {yearsOfExperience} years");
        Console.WriteLine($"🎓 Course: {course}");
        Console.WriteLine($"✅ Enrolled: {(isEnrolled ? "Yes" : "No")}");
        Console.WriteLine($"🔤 English Level: {englishLevel}2");
        Console.WriteLine($"💰 Target Salary: {targetSalary:C}");
        Console.WriteLine($"📅 Course Start: {courseStartDate:MMMM dd, yyyy}");

        Console.WriteLine("\n🛠️  Technical Skills:");
        string[] skillList = skills.Split(", ");
        foreach (string skill in skillList)
        {
            Console.WriteLine($"   • {skill}");
        }

        // Additional calculations
        int birthYear = DateTime.Now.Year - myAge;
        double monthsExperience = yearsOfExperience * 12;
        DateTime careerStartDate = DateTime.Now.AddYears(-(int)yearsOfExperience)
                                            .AddMonths(-(int)((yearsOfExperience - (int)yearsOfExperience) * 12));

        Console.WriteLine($"\n📅 Additional Info:");
        Console.WriteLine($"   • Birth Year: {birthYear}");
        Console.WriteLine($"   • Months of Experience: {monthsExperience:F1}");
        Console.WriteLine($"   • Career Started: {careerStartDate:yyyy-MM}");
        Console.WriteLine($"   • Senior Developer in: {10 - yearsOfExperience:F1} years");
    }

    static void RunInteractiveBio()
    {
        Console.Clear();
        Console.WriteLine("🎤 INTERACTIVE PERSONAL BIO");
        Console.WriteLine("=".PadRight(40, '='));

        Console.WriteLine("Let's create your personal developer profile!\n");

        // Get user input with validation
        Console.Write("Enter your name: ");
        string name = GetNonEmptyInput("Name");

        int age = GetValidIntInRange("Enter your age: ", MIN_AGE, MAX_AGE);

        Console.Write("Enter your current role: ");
        string role = GetNonEmptyInput("Role");

        double experience = GetValidDoubleInRange("Enter years of experience: ", 0, 50);

        Console.Write("Enter your skills (comma separated): ");
        string skills = GetNonEmptyInput("Skills");

        bool enrolled = GetYesNoInput("Are you currently enrolled? (yes/no): ");

        decimal targetSalary = GetValidDecimalInRange("Enter your target salary: ", MIN_SALARY, MAX_SALARY);

        char englishLevel = GetValidEnglishLevel("Enter your English level (A/B/C): ");

        // Display the created bio
        Console.Clear();
        Console.WriteLine("🎉 YOUR PERSONAL DEVELOPER PROFILE");
        Console.WriteLine("=".PadRight(40, '='));

        Console.WriteLine($"👤 Name: {name}");
        Console.WriteLine($"🎂 Age: {age}");
        Console.WriteLine($"💼 Current Role: {role}");
        Console.WriteLine($"📚 Experience: {experience} years");
        Console.WriteLine($"🎓 Course: C# Mastery 28-Day Challenge");
        Console.WriteLine($"✅ Enrolled: {(enrolled ? "Yes" : "No")}");
        Console.WriteLine($"🔤 English Level: {englishLevel}2");
        Console.WriteLine($"💰 Target Salary: {targetSalary:C}");

        Console.WriteLine("\n🛠️  Your Skills:");
        string[] skillList = skills.Split(',');
        foreach (string skill in skillList)
        {
            Console.WriteLine($"   • {skill.Trim()}");
        }

        // Interactive calculations
        int birthYear = DateTime.Now.Year - age;
        double monthsExperience = experience * 12;
        int yearsToSenior = Math.Max(0, 5 - (int)experience);
        bool canWorkInUS = age >= 18 && englishLevel >= 'B';

        Console.WriteLine($"\n📊 Career Insights:");
        Console.WriteLine($"   • Birth Year: {birthYear}");
        Console.WriteLine($"   • Months of Experience: {monthsExperience:F1}");
        Console.WriteLine($"   • Years to Senior Developer: {yearsToSenior}");
        Console.WriteLine($"   • Can work in US: {(canWorkInUS ? "Yes" : "No")}");
        Console.WriteLine($"   • Experience Level: {GetExperienceLevel(experience)}");

        // Motivation message
        Console.WriteLine($"\n💫 Welcome to the C# Mastery Challenge, {name}!");
        Console.WriteLine($"You're starting an amazing journey to become a C# developer! 🚀");
    }

    static void DataTypeChallenges()
    {
        Console.Clear();
        Console.WriteLine("🏆 DATA TYPE CHALLENGES");
        Console.WriteLine("=".PadRight(40, '='));

        // Challenge 1: Type Conversion
        Console.WriteLine("\n🔤 CHALLENGE 1: TYPE CONVERSION");
        Console.WriteLine("-".PadRight(30, '-'));
        
        Console.Write("Enter a number: ");
        string numberInput = Console.ReadLine()!;
        
        if (int.TryParse(numberInput, out int number))
        {
            double doubled = number * 2.5;
            string asString = number.ToString();
            char firstDigit = numberInput[0];
            
            Console.WriteLine($"Original: {number} ({number.GetType()})");
            Console.WriteLine($"As double: {doubled} ({doubled.GetType()})");
            Console.WriteLine($"As string: \"{asString}\" ({asString.GetType()})");
            Console.WriteLine($"First digit as char: '{firstDigit}'");
        }
        else
        {
            Console.WriteLine("❌ Invalid number format!");
        }

        // Challenge 2: DateTime Operations
        Console.WriteLine("\n📅 CHALLENGE 2: DATE TIME OPERATIONS");
        Console.WriteLine("-".PadRight(30, '-'));
        
        DateTime today = DateTime.Today;
        DateTime nextYear = today.AddYears(1);
        DateTime newYears = new DateTime(today.Year + 1, 1, 1);
        TimeSpan untilNewYear = newYears - today;
        
        Console.WriteLine($"Today: {today:dddd, MMMM dd, yyyy}");
        Console.WriteLine($"One year from now: {nextYear:MMMM dd, yyyy}");
        Console.WriteLine($"Days until New Year: {untilNewYear.Days}");
        Console.WriteLine($"Day of week: {today.DayOfWeek}");
        Console.WriteLine($"Is leap year: {DateTime.IsLeapYear(today.Year)}");

        // Challenge 3: Boolean Logic
        Console.WriteLine("\n🎯 CHALLENGE 3: BOOLEAN LOGIC PUZZLES");
        Console.WriteLine("-".PadRight(30, '-'));
        
        int a = 15, b = 10, c = 5;
        
        bool puzzle1 = (a > b) && (b > c);
        bool puzzle2 = (a + b == 25) || (a - c == 10);
        bool puzzle3 = !(a == b) && (c != 0);
        
        Console.WriteLine($"({a} > {b}) && ({b} > {c}) = {puzzle1}");
        Console.WriteLine($"({a} + {b} == 25) || ({a} - {c} == 10) = {puzzle2}");
        Console.WriteLine($"!({a} == {b}) && ({c} != 0) = {puzzle3}");
    }

    // ==================== HELPER METHODS ====================

    static string GetNonEmptyInput(string fieldName)
    {
        while (true)
        {
            string input = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            Console.Write($"{fieldName} cannot be empty. Please enter again: ");
        }
    }

    static int GetValidIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                return result;
            Console.WriteLine($"❌ Please enter a valid number between {min} and {max}!");
        }
    }

    static double GetValidDoubleInRange(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result) && result >= min && result <= max)
                return result;
            Console.WriteLine($"❌ Please enter a valid number between {min} and {max}!");
        }
    }

    static decimal GetValidDecimalInRange(string prompt, decimal min, decimal max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal result) && result >= min && result <= max)
                return result;
            Console.WriteLine($"❌ Please enter a valid number between {min:C} and {max:C}!");
        }
    }

    static bool GetYesNoInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!.ToLower();
            if (input == "yes" || input == "y") return true;
            if (input == "no" || input == "n") return false;
            Console.WriteLine("❌ Please enter 'yes' or 'no'!");
        }
    }

    static char GetValidEnglishLevel(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!.ToUpper();
            if (input.Length == 1 && "ABC".Contains(input))
                return input[0];
            Console.WriteLine("❌ Please enter A, B, or C!");
        }
    }

    static string GetExperienceLevel(double years)
    {
        return years switch
        {
            < 1 => "Junior",
            < 3 => "Mid-Level",
            < 7 => "Senior",
            _ => "Expert"
        };
    }
}