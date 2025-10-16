// Day 3: Conditionals
// This program includes multiple challenges to practice conditional statements in C#.
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Store registered users (username -> password)
    private static Dictionary<string, string> users = new Dictionary<string, string> {
        {"admin", "1234"}  // Default admin user
    };

    // Constants for validation
    private const int MIN_USERNAME_LENGTH = 3;
    private const int MIN_PASSWORD_LENGTH = 4;
    private const int STRONG_PASSWORD_LENGTH = 8;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎯 DAY 3: CONDITIONALS");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Temperature Check");
            Console.WriteLine("2. Even/Odd & Positive/Negative");
            Console.WriteLine("3. Grade Calculator");
            Console.WriteLine("4. Login System");
            Console.WriteLine("5. Register New User");
            Console.WriteLine("6. Show All Users");
            Console.WriteLine("7. Delete User");
            Console.WriteLine("8. Sum & Average Calculator");
            Console.WriteLine("9. Exit to Day 4");
            Console.Write("\nChoose an option (1-9): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    TemperatureCheck();
                    break;
                case "2":
                    NumberAnalysis();
                    break;
                case "3":
                    GradeCalculator();
                    break;
                case "4":
                    LoginSystem();
                    break;
                case "5":
                    RegisterUser();
                    break;
                case "6":
                    ShowAllUsers();
                    break;
                case "7":
                    DeleteUser();
                    break;
                case "8":
                    SumAndAverage();
                    break;
                case "9":
                    Console.WriteLine("👋 Thank you for using the program!");
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

    static void TemperatureCheck()
    {
        Console.Clear();
        Console.WriteLine("🌡️  TEMPERATURE CHECK");
        Console.WriteLine("=".PadRight(30, '='));

        int temperature = GetValidInt("Enter temperature: ");

        if (temperature > 30)
        {
            Console.WriteLine("🔥 Hot - Stay hydrated!");
        }
        else if (temperature >= 20)
        {
            Console.WriteLine("😊 Warm - Perfect weather!");
        }
        else if (temperature >= 10)
        {
            Console.WriteLine("😐 Cool - Wear a jacket");
        }
        else if (temperature >= 0)
        {
            Console.WriteLine("🥶 Cold - Bundle up!");
        }
        else
        {
            Console.WriteLine("❄️  Freezing - Stay indoors!");
        }
    }

    static void NumberAnalysis()
    {
        Console.Clear();
        Console.WriteLine("🔢 NUMBER ANALYSIS CHALLENGE");
        Console.WriteLine("=".PadRight(30, '='));

        int number = GetValidInt("Enter a number: ");

        // Even/Odd check
        if (number % 2 == 0)
        {
            Console.WriteLine($"📊 {number} is EVEN");
        }
        else
        {
            Console.WriteLine($"📊 {number} is ODD");
        }

        // Positive/Negative/Zero check
        if (number > 0)
        {
            Console.WriteLine($"➕ {number} is POSITIVE");
        }
        else if (number < 0)
        {
            Console.WriteLine($"➖ {number} is NEGATIVE");
        }
        else
        {
            Console.WriteLine($"0️⃣  {number} is ZERO");
        }

        // Bonus: Multiple of 5 check
        if (number % 5 == 0)
        {
            Console.WriteLine($"5️⃣  {number} is a multiple of 5");
        }
        else
        {
            Console.WriteLine($"5️⃣  {number} is NOT a multiple of 5");
        }
    }

    static void GradeCalculator()
    {
        Console.Clear();
        Console.WriteLine("📚 GRADE CALCULATOR");
        Console.WriteLine("=".PadRight(30, '='));

        int score = GetValidIntInRange("Enter your score (0-100): ", 0, 100);

        if (score >= 90 && score <= 100)
        {
            Console.WriteLine("🎉 Grade: A - Excellent!");
        }
        else if (score >= 80)
        {
            Console.WriteLine("👍 Grade: B - Very Good!");
        }
        else if (score >= 70)
        {
            Console.WriteLine("✅ Grade: C - Good");
        }
        else if (score >= 60)
        {
            Console.WriteLine("⚠️  Grade: D - Pass");
        }
        else
        {
            Console.WriteLine("❌ Grade: F - Fail");
        }

        // Additional feedback
        if (score >= 60)
        {
            Console.WriteLine("💫 You passed the course!");
        }
        else
        {
            Console.WriteLine("📖 Better luck next time!");
        }
    }

    static void LoginSystem()
    {
        Console.Clear();
        Console.WriteLine("🔐 ENHANCED LOGIN SYSTEM");
        Console.WriteLine("=".PadRight(30, '='));

        if (users.Count == 0)
        {
            Console.WriteLine("❌ No users registered yet!");
            Console.WriteLine("Please register a user first.");
            return;
        }

        Console.Write("Enter username: ");
        string username = Console.ReadLine()!;

        Console.Write("Enter password: ");
        string password = ReadPassword();

        // Check if user exists
        if (users.ContainsKey(username))
        {
            // Check if password matches
            if (users[username] == password)
            {
                Console.WriteLine("✅ Login successful! Welcome back!");

                // Special message for admin
                if (username == "admin")
                {
                    Console.WriteLine("👑 Welcome, Administrator!");
                    Console.WriteLine($"📊 Total registered users: {users.Count}");
                }
                else
                {
                    Console.WriteLine($"👋 Hello, {username}!");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid password!");
                Console.WriteLine("💡 Hint: Passwords are case-sensitive");
            }
        }
        else
        {
            Console.WriteLine("❌ Invalid username!");
            Console.WriteLine("💡 This username is not registered");

            // Suggest similar usernames
            foreach (var user in users.Keys)
            {
                if (user.ToLower().Contains(username.ToLower()) || username.ToLower().Contains(user.ToLower()))
                {
                    Console.WriteLine($"💡 Did you mean: {user}?");
                    break;
                }
            }
        }
    }

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("👤 REGISTER NEW USER");
        Console.WriteLine("=".PadRight(30, '='));

        Console.Write("Enter new username: ");
        string username = Console.ReadLine()!;

        // Validate username
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("❌ Username cannot be empty!");
            return;
        }

        if (users.ContainsKey(username))
        {
            Console.WriteLine("❌ Username already exists!");
            Console.WriteLine("💡 Please choose a different username");
            return;
        }

        if (username.Length < MIN_USERNAME_LENGTH)
        {
            Console.WriteLine($"❌ Username must be at least {MIN_USERNAME_LENGTH} characters long!");
            return;
        }

        Console.Write("Enter password: ");
        string password = ReadPassword();

        // Validate password
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("❌ Password cannot be empty!");
            return;
        }

        if (password.Length < MIN_PASSWORD_LENGTH)
        {
            Console.WriteLine($"❌ Password must be at least {MIN_PASSWORD_LENGTH} characters long!");
            return;
        }

        // Confirm password
        Console.Write("Confirm password: ");
        string confirmPassword = ReadPassword();

        if (password != confirmPassword)
        {
            Console.WriteLine("❌ Passwords do not match!");
            return;
        }

        // Register the user
        users[username] = password;
        Console.WriteLine("✅ User registered successfully!");
        Console.WriteLine($"👋 Welcome, {username}! You can now login.");

        // Show password strength
        AssessPasswordStrength(password);
    }

    static void ShowAllUsers()
    {
        Console.Clear();
        Console.WriteLine("📋 REGISTERED USERS");
        Console.WriteLine("=".PadRight(30, '='));

        if (users.Count == 0)
        {
            Console.WriteLine("❌ No users registered yet!");
            return;
        }

        Console.WriteLine($"Total users: {users.Count}\n");

        int count = 1;
        foreach (var user in users)
        {
            string role = user.Key == "admin" ? "👑 Administrator" : "👤 Regular User";
            string passwordStars = new string('*', user.Value.Length);
            Console.WriteLine($"{count}. {user.Key} ({role})");
            Console.WriteLine($"   Password: {passwordStars}");
            count++;
        }

        Console.WriteLine($"\n💡 Note: {users.Count - 1} user(s) can be managed by admin");
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("🗑️  DELETE USER");
        Console.WriteLine("=".PadRight(30, '='));

        if (users.Count == 0)
        {
            Console.WriteLine("❌ No users registered yet!");
            return;
        }

        Console.WriteLine("Registered users:");
        foreach (var user in users.Keys)
        {
            string role = user == "admin" ? "(Administrator)" : "";
            Console.WriteLine($"- {user} {role}");
        }

        Console.Write("\nEnter username to delete: ");
        string username = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("❌ Username cannot be empty!");
            return;
        }

        if (!users.ContainsKey(username))
        {
            Console.WriteLine("❌ User not found!");
            return;
        }

        if (username == "admin")
        {
            Console.WriteLine("❌ Cannot delete administrator account!");
            return;
        }

        Console.Write($"Are you sure you want to delete user '{username}'? (yes/no): ");
        string confirmation = Console.ReadLine()!.ToLower();

        if (confirmation == "yes" || confirmation == "y")
        {
            users.Remove(username);
            Console.WriteLine($"✅ User '{username}' deleted successfully!");
        }
        else
        {
            Console.WriteLine("✅ Deletion cancelled.");
        }
    }

    static void SumAndAverage()
    {
        Console.Clear();
        Console.WriteLine("🧮 SUM & AVERAGE CALCULATOR");
        Console.WriteLine("=".PadRight(30, '='));
        
        int count = GetValidIntInRange("How many numbers do you want to enter? ", 1, 100);
        
        int sum = 0;
        int smallest = int.MaxValue;
        int largest = int.MinValue;
        
        List<int> numbers = new List<int>();
        
        Console.WriteLine($"\nEnter {count} numbers:");
        
        for (int i = 1; i <= count; i++)
        {
            int number = GetValidInt($"Number {i}: ");
            
            sum += number;
            numbers.Add(number);
            
            if (number < smallest) smallest = number;
            if (number > largest) largest = number;
        }
        
        double average = (double)sum / count;
        
        Console.WriteLine("\n📊 RESULTS:");
        Console.WriteLine("-".PadRight(20, '-'));
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Smallest: {smallest}");
        Console.WriteLine($"Largest: {largest}");
        
        // Bonus: Count even and odd numbers
        Console.Write($"\nWant to see even/odd breakdown? (yes/no): ");
        if (Console.ReadLine()!.ToLower() == "yes")
        {
            int evenCount = 0, oddCount = 0;
            
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            
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
    }

    // ==================== HELPER METHODS ====================

    static int GetValidInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("❌ Please enter a valid number!");
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

    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;
        
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);
        
        Console.WriteLine();
        return password;
    }

    static void AssessPasswordStrength(string password)
    {
        if (password.Length >= STRONG_PASSWORD_LENGTH && ContainsMixedCharacters(password))
        {
            Console.WriteLine("💪 Strong password!");
        }
        else if (password.Length >= 6)
        {
            Console.WriteLine("👍 Good password");
        }
        else
        {
            Console.WriteLine("⚠️  Weak password - consider making it longer");
        }
    }

    static bool ContainsMixedCharacters(string password)
    {
        bool hasLetter = false;
        bool hasDigit = false;
        bool hasSpecial = false;

        foreach (char c in password)
        {
            if (char.IsLetter(c)) hasLetter = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else hasSpecial = true;
        }

        return hasLetter && hasDigit && hasSpecial;
    }
}