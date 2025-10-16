// Day 2: Operators
// This program includes fixed and interactive versions to practice operators in C#.
using System;

class Program
{
    // Constants for calculations
    private const double PAINT_COVERAGE = 10.0; // sq units per liter
    private const double BORDER_EXTRA_PERCENTAGE = 0.1; // 10% extra

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎯 DAY 2: OPERATORS MASTERY");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Fixed Values Version");
            Console.WriteLine("2. Interactive User Input Version");
            Console.WriteLine("3. Operator Challenges");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option (1-4): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    RunFixedVersion();
                    break;
                case "2":
                    RunInteractiveVersion();
                    break;
                case "3":
                    OperatorChallenges();
                    break;
                case "4":
                    Console.WriteLine("👋 Thank you for practicing operators!");
                    return;
                default:
                    Console.WriteLine("❌ Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }

            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }

    static void RunFixedVersion()
    {
        Console.Clear();
        Console.WriteLine("🎯 DAY 2: OPERATORS MASTERY - FIXED VALUES");
        Console.WriteLine("=".PadRight(40, '='));

        // ==========================================
        // PART 1: ORIGINAL RECTANGLE CALCULATOR
        // ==========================================
        Console.WriteLine("\n📐 PART 1: ORIGINAL RECTANGLE");
        Console.WriteLine("-".PadRight(30, '-'));

        double width = 8.5;
        double height = 12.3;

        double area = width * height;
        double perimeter = 2 * (width + height);

        Console.WriteLine($"Width: {width}, Height: {height}");
        Console.WriteLine($"Area: {area}, Perimeter: {perimeter}");
        Console.WriteLine($"Is Square? {width == height}");

        // ==========================================
        // 🔧 MODIFICATION 1: DIFFERENT DIMENSIONS
        // ==========================================
        Console.WriteLine("\n🔧 MOD 1: DIFFERENT DIMENSIONS");
        Console.WriteLine("-".PadRight(30, '-'));

        width = 15;
        height = 7;
        area = width * height;
        perimeter = 2 * (width + height);

        Console.WriteLine($"Width: {width}, Height: {height}");
        Console.WriteLine($"Area: {area}, Perimeter: {perimeter}");
        Console.WriteLine($"Width > Height? {width > height}");

        // ==========================================
        // 🔧 MODIFICATION 2: INTEGER VERSION
        // ==========================================
        Console.WriteLine("\n🔧 MOD 2: INTEGER VERSION");
        Console.WriteLine("-".PadRight(30, '-'));

        int intWidth = 10;
        int intHeight = 5;
        int intArea = intWidth * intHeight;
        int intPerimeter = 2 * (intWidth + intHeight);

        Console.WriteLine($"Width: {intWidth}, Height: {intHeight}");
        Console.WriteLine($"Area: {intArea}, Perimeter: {intPerimeter}");
        Console.WriteLine($"Division test: {intWidth / intHeight} (integer division)");
        Console.WriteLine($"Modulus: {intWidth % intHeight} (remainder)");

        // ==========================================
        // 🔧 MODIFICATION 3: COMPLEX CALCULATIONS
        // ==========================================
        Console.WriteLine("\n🔧 MOD 3: COMPLEX CALCULATIONS");
        Console.WriteLine("-".PadRight(30, '-'));

        width = 15;
        height = 7;
        area = width * height;

        // Paint needed (1 liter per 10 sq units)
        double paintNeeded = area / PAINT_COVERAGE;

        // Cost calculation ($5 per liter)
        double paintCost = paintNeeded * 5.0;

        // Border length (perimeter + 10% extra)
        double borderLength = perimeter * (1 + BORDER_EXTRA_PERCENTAGE);

        Console.WriteLine($"Area: {area} sq units");
        Console.WriteLine($"Paint needed: {paintNeeded:F1} liters");
        Console.WriteLine($"Paint cost: ${paintCost:F2}");
        Console.WriteLine($"Border length needed: {borderLength:F1} units");

        // ==========================================
        // 🎪 BONUS CHALLENGE: SHAPE COMPARISON
        // ==========================================
        Console.WriteLine("\n🎪 BONUS: SHAPE AREA COMPARISON");
        Console.WriteLine("-".PadRight(30, '-'));

        // Circle calculations
        double radius = 6.0;
        double circleArea = Math.PI * Math.Pow(radius, 2);

        // Triangle calculations  
        double triangleBase = 10.0;
        double triangleHeight = 8.0;
        double triangleArea = 0.5 * triangleBase * triangleHeight;

        // Comparison operations
        bool circleLarger = circleArea > triangleArea;
        bool triangleLarger = triangleArea > circleArea;
        bool areasEqual = Math.Abs(circleArea - triangleArea) < 0.001;

        // Area difference
        double areaDifference = Math.Abs(circleArea - triangleArea);

        Console.WriteLine($"Circle (radius {radius}): {circleArea:F2} sq units");
        Console.WriteLine($"Triangle (base {triangleBase}, height {triangleHeight}): {triangleArea:F2} sq units");
        Console.WriteLine($"Circle larger? {circleLarger}");
        Console.WriteLine($"Triangle larger? {triangleLarger}");
        Console.WriteLine($"Areas equal? {areasEqual}");
        Console.WriteLine($"Area difference: {areaDifference:F2} sq units");

        // ==========================================
        // 🏆 EXTRA: OPERATOR DEMONSTRATION
        // ==========================================
        Console.WriteLine("\n🏆 EXTRA: OPERATOR TYPES DEMO");
        Console.WriteLine("-".PadRight(30, '-'));

        int x = 20, y = 6;

        // Arithmetic operators
        Console.WriteLine($"Arithmetic: {x} + {y} = {x + y}");
        Console.WriteLine($"Arithmetic: {x} - {y} = {x - y}");
        Console.WriteLine($"Arithmetic: {x} * {y} = {x * y}");
        Console.WriteLine($"Arithmetic: {x} / {y} = {x / y} (int) / {(double)x / y:F2} (double)");
        Console.WriteLine($"Arithmetic: {x} % {y} = {x % y} (remainder)");

        // Comparison operators
        Console.WriteLine($"Comparison: {x} > {y} ? {x > y}");
        Console.WriteLine($"Comparison: {x} == {y} ? {x == y}");
        Console.WriteLine($"Comparison: {x} <= {y} ? {x <= y}");

        // Logical operators
        bool condition1 = x > 10;
        bool condition2 = y < 5;
        Console.WriteLine($"Logical: {condition1} AND {condition2} = {condition1 && condition2}");
        Console.WriteLine($"Logical: {condition1} OR {condition2} = {condition1 || condition2}");
        Console.WriteLine($"Logical: NOT {condition1} = {!condition1}");

        // Compound assignment
        int z = 10;
        Console.WriteLine($"\nCompound: z = {z}");
        z += 5; Console.WriteLine($"z += 5 → {z}");
        z *= 2; Console.WriteLine($"z *= 2 → {z}");
        z %= 7; Console.WriteLine($"z %= 7 → {z}");

        Console.WriteLine("\n🎉 FIXED VALUES VERSION COMPLETE!");
        Console.WriteLine("=".PadRight(40, '='));
    }

    static void RunInteractiveVersion()
    {
        Console.Clear();
        Console.WriteLine("🎯 DAY 2: OPERATORS MASTERY - INTERACTIVE");
        Console.WriteLine("=".PadRight(40, '='));

        // ==========================================
        // PART 1: ORIGINAL RECTANGLE CALCULATOR
        // ==========================================
        Console.WriteLine("\n📐 PART 1: RECTANGLE CALCULATOR");
        Console.WriteLine("-".PadRight(30, '-'));

        double width = GetValidDouble("Enter rectangle width: ");
        double height = GetValidDouble("Enter rectangle height: ");

        double area = width * height;
        double perimeter = 2 * (width + height);

        Console.WriteLine($"\nWidth: {width}, Height: {height}");
        Console.WriteLine($"Area: {area}, Perimeter: {perimeter}");
        Console.WriteLine($"Is Square? {width == height}");
        Console.WriteLine($"Aspect Ratio: {width / height:F2}");

        // ==========================================
        // 🔧 MODIFICATION 2: INTEGER VERSION
        // ==========================================
        Console.WriteLine("\n🔧 MOD 2: INTEGER VERSION");
        Console.WriteLine("-".PadRight(30, '-'));

        int intWidth = GetValidInt("Enter integer width: ");
        int intHeight = GetValidInt("Enter integer height: ");

        int intArea = intWidth * intHeight;
        int intPerimeter = 2 * (intWidth + intHeight);

        Console.WriteLine($"\nWidth: {intWidth}, Height: {intHeight}");
        Console.WriteLine($"Area: {intArea}, Perimeter: {intPerimeter}");
        Console.WriteLine($"Division test: {intWidth / intHeight} (integer division)");
        Console.WriteLine($"Division as double: {(double)intWidth / intHeight:F2}");
        Console.WriteLine($"Modulus: {intWidth % intHeight}");

        // ==========================================
        // 🔧 MODIFICATION 3: COMPLEX CALCULATIONS
        // ==========================================
        Console.WriteLine("\n🔧 MOD 3: COMPLEX CALCULATIONS");
        Console.WriteLine("-".PadRight(30, '-'));

        // Reuse the first rectangle for paint calculations
        Console.WriteLine($"Using your first rectangle (Area: {area} sq units)");

        // Paint needed (1 liter per 10 sq units)
        double paintNeeded = area / PAINT_COVERAGE;

        double costPerLiter = GetValidDouble("Enter cost per liter of paint: $");
        double paintCost = paintNeeded * costPerLiter;

        // Border length (perimeter + 10% extra)
        double borderLength = perimeter * (1 + BORDER_EXTRA_PERCENTAGE);

        Console.WriteLine($"\nPaint needed: {paintNeeded:F1} liters");
        Console.WriteLine($"Paint cost: ${paintCost:F2}");
        Console.WriteLine($"Border length needed: {borderLength:F1} units");
        Console.WriteLine($"Cost per sq unit: ${paintCost / area:F2}");

        // ==========================================
        // 🎪 BONUS CHALLENGE: SHAPE COMPARISON
        // ==========================================
        Console.WriteLine("\n🎪 BONUS: SHAPE AREA COMPARISON");
        Console.WriteLine("-".PadRight(30, '-'));

        // Circle calculations
        double radius = GetValidDouble("Enter circle radius: ");
        double circleArea = Math.PI * Math.Pow(radius, 2);

        // Triangle calculations  
        double triangleBase = GetValidDouble("Enter triangle base: ");
        double triangleHeight = GetValidDouble("Enter triangle height: ");
        double triangleArea = 0.5 * triangleBase * triangleHeight;

        // Comparison operations
        bool circleLarger = circleArea > triangleArea;
        bool triangleLarger = triangleArea > circleArea;
        bool areasEqual = Math.Abs(circleArea - triangleArea) < 0.001;
        double areaDifference = Math.Abs(circleArea - triangleArea);
        double areaRatio = circleLarger ? circleArea / triangleArea : triangleArea / circleArea;

        Console.WriteLine($"\nCircle (radius {radius}): {circleArea:F2} sq units");
        Console.WriteLine($"Triangle (base {triangleBase}, height {triangleHeight}): {triangleArea:F2} sq units");
        Console.WriteLine($"Circle larger? {circleLarger}");
        Console.WriteLine($"Triangle larger? {triangleLarger}");
        Console.WriteLine($"Areas equal? {areasEqual}");
        Console.WriteLine($"Area difference: {areaDifference:F2} sq units");
        Console.WriteLine($"Area ratio: {areaRatio:F2}:1");

        // ==========================================
        // 🏆 EXTRA: OPERATOR DEMONSTRATION
        // ==========================================
        Console.WriteLine("\n🏆 EXTRA: OPERATOR TYPES DEMO");
        Console.WriteLine("-".PadRight(30, '-'));

        int x = GetValidInt("Enter first number for operator demo: ");
        int y = GetValidInt("Enter second number for operator demo: ");

        // Arithmetic operators
        Console.WriteLine($"\nArithmetic: {x} + {y} = {x + y}");
        Console.WriteLine($"Arithmetic: {x} - {y} = {x - y}");
        Console.WriteLine($"Arithmetic: {x} * {y} = {x * y}");
        Console.WriteLine($"Arithmetic: {x} / {y} = {x / y} (int) / {(double)x / y:F2} (double)");
        Console.WriteLine($"Arithmetic: {x} % {y} = {x % y} (remainder)");

        // Comparison operators
        Console.WriteLine($"\nComparison: {x} > {y} ? {x > y}");
        Console.WriteLine($"Comparison: {x} == {y} ? {x == y}");
        Console.WriteLine($"Comparison: {x} <= {y} ? {x <= y}");
        Console.WriteLine($"Comparison: {x} != {y} ? {x != y}");

        // Logical operators
        bool condition1 = x > 10;
        bool condition2 = y < 5;
        Console.WriteLine($"\nLogical: {condition1} AND {condition2} = {condition1 && condition2}");
        Console.WriteLine($"Logical: {condition1} OR {condition2} = {condition1 || condition2}");
        Console.WriteLine($"Logical: NOT {condition1} = {!condition1}");

        // Bitwise operators (bonus)
        Console.WriteLine($"\nBitwise: {x} & {y} = {x & y}");
        Console.WriteLine($"Bitwise: {x} | {y} = {x | y}");
        Console.WriteLine($"Bitwise: {x} ^ {y} = {x ^ y} (XOR)");

        Console.WriteLine("\n🎉 INTERACTIVE VERSION COMPLETE!");
        Console.WriteLine("=".PadRight(40, '='));
    }

    static void OperatorChallenges()
    {
        Console.Clear();
        Console.WriteLine("🏆 OPERATOR CHALLENGES");
        Console.WriteLine("=".PadRight(40, '='));

        // Challenge 1: Temperature Conversion
        Console.WriteLine("\n🌡️  CHALLENGE 1: TEMPERATURE CONVERSION");
        Console.WriteLine("-".PadRight(30, '-'));

        double celsius = GetValidDouble("Enter temperature in Celsius: ");
        double fahrenheit = (celsius * 9 / 5) + 32;
        double kelvin = celsius + 273.15;

        Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
        Console.WriteLine($"{celsius}°C = {kelvin}K");

        // Challenge 2: BMI Calculator
        Console.WriteLine("\n⚖️  CHALLENGE 2: BMI CALCULATOR");
        Console.WriteLine("-".PadRight(30, '-'));

        double weight = GetValidDouble("Enter weight (kg): ");
        double height = GetValidDouble("Enter height (m): ");
        double bmi = weight / (height * height);

        string bmiCategory = bmi switch
        {
            < 18.5 => "Underweight",
            < 25 => "Normal weight",
            < 30 => "Overweight",
            _ => "Obese"
        };

        Console.WriteLine($"BMI: {bmi:F1} ({bmiCategory})");

        // Challenge 3: Compound Interest
        Console.WriteLine("\n💰 CHALLENGE 3: COMPOUND INTEREST");
        Console.WriteLine("-".PadRight(30, '-'));

        double principal = GetValidDouble("Enter principal amount: $");
        double rate = GetValidDouble("Enter annual interest rate (%): ");
        int years = GetValidInt("Enter number of years: ");

        double amount = principal * Math.Pow(1 + rate / 100, years);
        double interestEarned = amount - principal;

        Console.WriteLine($"Future value: ${amount:F2}");
        Console.WriteLine($"Interest earned: ${interestEarned:F2}");

        // Challenge 4: Logical Puzzles
        Console.WriteLine("\n🎯 CHALLENGE 4: LOGICAL PUZZLES");
        Console.WriteLine("-".PadRight(30, '-'));

        int a = 15, b = 25, c = 15;
        bool puzzle1 = (a == c) && (a != b);
        bool puzzle2 = (a < b) || (b < c);
        bool puzzle3 = !(a == b) && (c == a);
        bool puzzle4 = (a + b > c) && (b - a < c);

        Console.WriteLine($"({a} == {c}) && ({a} != {b}) = {puzzle1}");
        Console.WriteLine($"({a} < {b}) || ({b} < {c}) = {puzzle2}");
        Console.WriteLine($"!({a} == {b}) && ({c} == {a}) = {puzzle3}");
        Console.WriteLine($"({a} + {b} > {c}) && ({b} - {a} < {c}) = {puzzle4}");
    }

    // ==================== HELPER METHODS ====================

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