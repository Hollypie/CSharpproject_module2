using System;

public class Game
{
    private Player? player;
    private SaveManager saveManager;

    public Game()
    {
        player = null;
        saveManager = new SaveManager();
    }

    public void ShowMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Save Game");
        Console.WriteLine("4. Exit");
    }

    public string GetMenuChoice()
    {
        Console.Write("Enter your choice: ");
        return Console.ReadLine() ?? "";
    }

public bool HandleMenuChoice(string choice)
    {
        switch (choice)
        {
            case "1":

                StartNewGame();

                // Create an enemy for the first encounter
                Enemy skeleton = new Skeleton();
                StartBattle(skeleton);

                return true;

            case "2":
                LoadSavedGame();
                return true;

            case "3":
                SaveCurrentGame();
                return true;

            case "4":
                Console.WriteLine("You have chosen to exit the program.");
                return false;

            default:
                Console.WriteLine("That is an incorrect input. Try again.");
                return true;
        }
    }

    private void StartNewGame()
    {
        Console.WriteLine();
        Console.WriteLine("Starting new game...");

        player = new Player("Hero");

        Console.WriteLine($"Name: {player.Name}");
        Console.WriteLine($"Level: {player.Level}");
        player.PrintStats();
    }

    private void SaveCurrentGame()
    {
        if (player == null)
        {
            Console.WriteLine("No game in progress to save.");
            return;
        }

        saveManager.SaveGame(player);
    }

    private void LoadSavedGame()
    {
        Player? loaded = saveManager.LoadGame();
        if (loaded != null)
        {
            player = loaded;
            Console.WriteLine();
            Console.WriteLine("Player stats after loading:");
            player.PrintStats();
        }
    }

    public void StartBattle(Enemy enemy)
    {
        if (player == null) return;

        Console.WriteLine();
        Console.WriteLine($"A wild {enemy.Name} appears!");

        while (player.Stats.Health > 0 && enemy.Stats.Health > 0)
        {
            // Player attacks first
            Console.WriteLine("You attack!");
            enemy.TakeDamage(player.Stats.Strength);

            if (enemy.Stats.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} is defeated!");
                break;
            }

            // Enemy attacks back
            Console.WriteLine($"{enemy.Name} attacks!");
            player.TakeDamage(enemy.Stats.Strength);

            if (player.Stats.Health <= 0)
            {
                Console.WriteLine("You have been defeated!");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue to next round...");
            Console.ReadLine();
        }
    }

}
