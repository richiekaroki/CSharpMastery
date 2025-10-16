// Day 7: Review & Challenge - Guess the Number Game
// A comprehensive game that reviews all concepts from Days 1-6
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static int totalGamesPlayed = 0;
    private static int totalWins = 0;
    private static int bestScore = int.MaxValue;
    private static List<GameResult> gameHistory = new List<GameResult>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎮 DAY 7: GUESS THE NUMBER - ULTIMATE EDITION");
            Console.WriteLine("=".PadRight(40, '='));
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Game Statistics");
            Console.WriteLine("3. Difficulty Settings");
            Console.WriteLine("4. Game History");
            Console.WriteLine("5. How to Play");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option (1-6): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    PlayGame();
                    break;
                case "2":
                    ShowStatistics();
                    break;
                case "3":
                    DifficultySettings();
                    break;
                case "4":
                    ShowGameHistory();
                    break;
                case "5":
                    HowToPlay();
                    break;
                case "6":
                    Console.WriteLine("👋 Thanks for playing!");
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

    static void PlayGame()
    {
        Console.Clear();
        Console.WriteLine("🎯 GUESS THE NUMBER");
        Console.WriteLine("=".PadRight(30, '='));

        // Game configuration
        Difficulty difficulty = GetCurrentDifficulty();
        int maxNumber = difficulty.MaxNumber;
        int maxAttempts = difficulty.MaxAttempts;
        int minNumber = difficulty.MinNumber;

        Random random = new Random();
        int secretNumber = random.Next(minNumber, maxNumber + 1);
        int attempts = 0;
        bool won = false;
        int previousGuess = -1;
        List<int> guessHistory = new List<int>();
        DateTime startTime = DateTime.Now;

        Console.WriteLine($"I'm thinking of a number between {minNumber} and {maxNumber}.");
        Console.WriteLine($"You have {maxAttempts} attempts. Good luck!");
        Console.WriteLine($"Difficulty: {difficulty.Name}");
        Console.WriteLine();

        // Main game loop
        while (attempts < maxAttempts && !won)
        {
            attempts++;
            int remainingAttempts = maxAttempts - attempts;

            // Get valid guess from user
            int guess = GetValidGuess($"Attempt {attempts}/{maxAttempts}: ", minNumber, maxNumber);
            guessHistory.Add(guess);

            // Check guess
            if (guess == secretNumber)
            {
                won = true;
                TimeSpan gameTime = DateTime.Now - startTime;
                
                Console.WriteLine($"\n🎉 CONGRATULATIONS! You guessed it!");
                Console.WriteLine($"📍 The number was indeed {secretNumber}");
                Console.WriteLine($"⏱️  Time: {gameTime.TotalSeconds:F1} seconds");
                Console.WriteLine($"🎯 Attempts: {attempts}/{maxAttempts}");

                // Calculate score
                int score = CalculateScore(attempts, maxAttempts, gameTime, difficulty);
                Console.WriteLine($"🏆 Score: {score} points");

                UpdateStatistics(true, attempts, score);
                SaveGameResult(true, attempts, score, gameTime, difficulty.Name, guessHistory);
            }
            else
            {
                // Provide feedback
                string feedback = GetFeedback(guess, secretNumber, previousGuess);
                Console.WriteLine($"   {feedback}");

                // Show attempts remaining with color coding
                if (remainingAttempts > 0)
                {
                    string attemptsColor = remainingAttempts <= 2 ? "🔴" : remainingAttempts <= maxAttempts / 2 ? "🟡" : "🟢";
                    Console.WriteLine($"   {attemptsColor} {remainingAttempts} attempts remaining");
                }

                previousGuess = guess;
            }
        }

        if (!won)
        {
            TimeSpan gameTime = DateTime.Now - startTime;
            Console.WriteLine($"\n💔 GAME OVER! The number was {secretNumber}");
            Console.WriteLine($"⏱️  Time: {gameTime.TotalSeconds:F1} seconds");
            
            UpdateStatistics(false, attempts, 0);
            SaveGameResult(false, attempts, 0, gameTime, difficulty.Name, guessHistory);
        }

        // Play again option
        Console.Write("\nPlay again? (yes/no): ");
        if (Console.ReadLine()!.ToLower() == "yes")
        {
            PlayGame();
        }
    }

    static void ShowStatistics()
    {
        Console.Clear();
        Console.WriteLine("📊 GAME STATISTICS");
        Console.WriteLine("=".PadRight(30, '='));

        if (totalGamesPlayed == 0)
        {
            Console.WriteLine("No games played yet!");
            return;
        }

        double winRate = (double)totalWins / totalGamesPlayed * 100;
        int averageAttempts = gameHistory.Where(g => g.Won).Select(g => g.Attempts).DefaultIfEmpty(0).Average() > 0 ? 
                            (int)gameHistory.Where(g => g.Won).Average(g => g.Attempts) : 0;

        Console.WriteLine($"Total Games Played: {totalGamesPlayed}");
        Console.WriteLine($"Games Won: {totalWins}");
        Console.WriteLine($"Win Rate: {winRate:F1}%");
        Console.WriteLine($"Best Score: {(bestScore == int.MaxValue ? "N/A" : bestScore.ToString())}");
        Console.WriteLine($"Average Winning Attempts: {averageAttempts}");

        // Recent performance
        var recentGames = gameHistory.TakeLast(5).ToList();
        if (recentGames.Count > 0)
        {
            Console.WriteLine($"\n📈 Last {recentGames.Count} Games:");
            foreach (var game in recentGames)
            {
                string result = game.Won ? "✅ Won" : "❌ Lost";
                Console.WriteLine($"   {game.Timestamp:HH:mm} - {result} - {game.Attempts} attempts - {game.Score} points");
            }
        }
    }

    static void DifficultySettings()
    {
        Console.Clear();
        Console.WriteLine("⚙️ DIFFICULTY SETTINGS");
        Console.WriteLine("=".PadRight(30, '='));

        Difficulty current = GetCurrentDifficulty();
        Console.WriteLine($"Current: {current.Name}");
        Console.WriteLine($"Range: {current.MinNumber}-{current.MaxNumber}");
        Console.WriteLine($"Attempts: {current.MaxAttempts}");

        Console.WriteLine("\nAvailable Difficulties:");
        Console.WriteLine("1. Easy (1-50, 10 attempts)");
        Console.WriteLine("2. Medium (1-100, 7 attempts)");
        Console.WriteLine("3. Hard (1-200, 5 attempts)");
        Console.WriteLine("4. Expert (1-500, 5 attempts)");
        Console.WriteLine("5. Custom (Set your own)");

        Console.Write("\nChoose difficulty (1-5): ");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                SetDifficulty(new Difficulty("Easy", 1, 50, 10));
                break;
            case "2":
                SetDifficulty(new Difficulty("Medium", 1, 100, 7));
                break;
            case "3":
                SetDifficulty(new Difficulty("Hard", 1, 200, 5));
                break;
            case "4":
                SetDifficulty(new Difficulty("Expert", 1, 500, 5));
                break;
            case "5":
                SetCustomDifficulty();
                break;
            default:
                Console.WriteLine("❌ Invalid choice! Keeping current settings.");
                break;
        }
    }

    static void SetCustomDifficulty()
    {
        Console.WriteLine("\n🎛️ CUSTOM DIFFICULTY");
        
        int min = GetValidInt("Minimum number: ", 1, 1000);
        int max = GetValidInt("Maximum number: ", min + 1, 10000);
        int attempts = GetValidInt("Max attempts: ", 1, 50);

        string name = $"{min}-{max} ({attempts} tries)";
        SetDifficulty(new Difficulty(name, min, max, attempts));
        Console.WriteLine($"✅ Custom difficulty set: {name}");
    }

    static void ShowGameHistory()
    {
        Console.Clear();
        Console.WriteLine("📋 GAME HISTORY");
        Console.WriteLine("=".PadRight(30, '='));

        if (gameHistory.Count == 0)
        {
            Console.WriteLine("No games played yet!");
            return;
        }

        Console.WriteLine($"Total games recorded: {gameHistory.Count}\n");

        foreach (var result in gameHistory.OrderByDescending(g => g.Timestamp).Take(10))
        {
            string status = result.Won ? "✅ WON " : "❌ LOST";
            string time = result.Timestamp.ToString("MM/dd HH:mm");
            Console.WriteLine($"{time} - {status} - {result.Difficulty} - {result.Attempts} attempts - {result.Score} points");
            
            if (result.GuessHistory.Count > 0)
            {
                Console.WriteLine($"   Guesses: {string.Join(" → ", result.GuessHistory.TakeLast(5))}");
            }
        }

        Console.WriteLine("\nOptions: 1. Clear History  2. Back");
        Console.Write("Choose: ");
        if (Console.ReadLine() == "1")
        {
            gameHistory.Clear();
            Console.WriteLine("✅ History cleared!");
        }
    }

    static void HowToPlay()
    {
        Console.Clear();
        Console.WriteLine("📖 HOW TO PLAY");
        Console.WriteLine("=".PadRight(30, '='));

        Console.WriteLine(@"
🎯 OBJECTIVE:
Guess the secret number within the allowed attempts!

🎮 GAMEPLAY:
- I'll think of a number within a specific range
- You enter your guesses
- I'll tell you if you're too high or too low
- Use the feedback to narrow down your guesses

🏆 SCORING:
- Fewer attempts = Higher score
- Faster completion = Bonus points
- Higher difficulty = Multiplier

💡 STRATEGY:
- Start with the middle number in the range
- Use binary search strategy
- Pay attention to the 'warmer/colder' hints
- Keep track of your previous guesses

🎛️ DIFFICULTIES:
- Easy: 1-50, 10 attempts
- Medium: 1-100, 7 attempts  
- Hard: 1-200, 5 attempts
- Expert: 1-500, 5 attempts

Good luck and have fun! 🎉
");

        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    // ==================== GAME LOGIC METHODS ====================

    static int GetValidGuess(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (input.ToLower() == "quit")
            {
                throw new OperationCanceledException("Game quit by user");
            }

            if (input.ToLower() == "hint")
            {
                GiveHint(min, max);
                continue;
            }

            if (int.TryParse(input, out int guess) && guess >= min && guess <= max)
            {
                return guess;
            }

            Console.WriteLine($"❌ Please enter a number between {min} and {max}!");
        }
    }

    static void GiveHint(int min, int max)
    {
        int range = max - min + 1;
        string hint = range switch
        {
            <= 50 => "Try thinking about the middle of the range...",
            <= 100 => "Consider dividing the range in half each time...",
            <= 200 => "The number could be anywhere, but look for patterns...",
            _ => "This is a large range - good luck!"
        };

        Console.WriteLine($"💡 Hint: {hint}");
        Console.WriteLine($"   The number is between {min} and {max}");
    }

    static string GetFeedback(int currentGuess, int secretNumber, int previousGuess)
    {
        int currentDiff = Math.Abs(currentGuess - secretNumber);
        
        if (previousGuess == -1)
        {
            // First guess
            return currentGuess < secretNumber ? "📈 Too low!" : "📉 Too high!";
        }

        int previousDiff = Math.Abs(previousGuess - secretNumber);
        string temperature = currentDiff < previousDiff ? "🔥 Getting warmer!" :
                           currentDiff > previousDiff ? "❄️  Getting colder!" : "➡️  Same distance";

        string direction = currentGuess < secretNumber ? "📈 Go higher!" : "📉 Go lower!";

        // Special hints for close guesses
        if (currentDiff <= 5)
        {
            string veryClose = currentDiff switch
            {
                1 => "🔥🔥🔥 BURNING HOT!",
                2 => "🔥🔥 Very hot!",
                <= 5 => "🔥 Hot!",
                _ => ""
            };
            return $"{temperature} {direction} {veryClose}";
        }

        return $"{temperature} {direction}";
    }

    static int CalculateScore(int attempts, int maxAttempts, TimeSpan time, Difficulty difficulty)
    {
        // Base score based on attempts used
        int baseScore = (maxAttempts - attempts + 1) * 100;

        // Time bonus (faster = better)
        double timeBonus = Math.Max(0, 100 - time.TotalSeconds);

        // Difficulty multiplier
        double multiplier = difficulty.Name switch
        {
            "Easy" => 1.0,
            "Medium" => 1.5,
            "Hard" => 2.0,
            "Expert" => 3.0,
            _ => 1.2 // Custom difficulties
        };

        int totalScore = (int)((baseScore + timeBonus) * multiplier);
        return Math.Max(0, totalScore);
    }

    static void UpdateStatistics(bool won, int attempts, int score)
    {
        totalGamesPlayed++;
        if (won)
        {
            totalWins++;
            if (score > 0 && score < bestScore)
            {
                bestScore = score;
            }
        }
    }

    static void SaveGameResult(bool won, int attempts, int score, TimeSpan time, string difficulty, List<int> guessHistory)
    {
        gameHistory.Add(new GameResult
        {
            Won = won,
            Attempts = attempts,
            Score = score,
            Time = time,
            Difficulty = difficulty,
            GuessHistory = new List<int>(guessHistory),
            Timestamp = DateTime.Now
        });

        // Keep only last 50 games
        if (gameHistory.Count > 50)
        {
            gameHistory.RemoveAt(0);
        }
    }

    // ==================== HELPER METHODS ====================

    static Difficulty GetCurrentDifficulty()
    {
        // In a real app, you might load this from a file
        return currentDifficulty ?? new Difficulty("Medium", 1, 100, 7);
    }

    static void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;
        Console.WriteLine($"✅ Difficulty set to: {difficulty.Name}");
    }

    static int GetValidInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                return result;
            Console.WriteLine($"❌ Please enter a number between {min} and {max}!");
        }
    }

    // ==================== SUPPORTING CLASSES ====================

    private static Difficulty? currentDifficulty;

    class Difficulty
    {
        public string Name { get; }
        public int MinNumber { get; }
        public int MaxNumber { get; }
        public int MaxAttempts { get; }

        public Difficulty(string name, int min, int max, int attempts)
        {
            Name = name;
            MinNumber = min;
            MaxNumber = max;
            MaxAttempts = attempts;
        }
    }

    class GameResult
    {
        public bool Won { get; set; }
        public int Attempts { get; set; }
        public int Score { get; set; }
        public TimeSpan Time { get; set; }
        public string Difficulty { get; set; } = "";
        public List<int> GuessHistory { get; set; } = new List<int>();
        public DateTime Timestamp { get; set; }
    }
}