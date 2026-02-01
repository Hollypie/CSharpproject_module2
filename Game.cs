using System.Text.Json;

public class Game
{
    private Player? player;
    private Random random = new Random();

    public void ShowMainMenu()
    {
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Random Encounter");
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
                break;
            case "2":
                LoadGame();
                break;
            case "3":
                RandomEncounter();
                break;
            case "4":
                Console.WriteLine("Exiting program...");
                return false;
            default:
                Console.WriteLine("Invalid input. Try again.");
                break;
        }
        return true;
    }

    public void StartNewGame()
    {
        player = new Player("Hero");
        Console.WriteLine("\nNew game started!");
        player.PrintStats();
    }

    public void SaveGame()
    {
        if (player == null)
        {
            Console.WriteLine("No game to save.");
            return;
        }

        string json = JsonSerializer.Serialize(player);
        File.WriteAllText("savegame.json", json);
        Console.WriteLine("Game saved!");
    }

    public void LoadGame()
    {
        if (!File.Exists("savegame.json"))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string json = File.ReadAllText("savegame.json");
        player = JsonSerializer.Deserialize<Player>(json);
        Console.WriteLine("Game loaded!");
        player?.PrintStats();
    }

    public void RandomEncounter()
    {
        if (player == null)
        {
            Console.WriteLine("Start a game first!");
            return;
        }

        Enemy enemy = random.Next(2) == 0 ? new Skeleton() : new Goblin();

        Console.WriteLine($"\nA wild {enemy.Name} appears!");
        Console.WriteLine($"Enemy HP: {enemy.Stats.Health}");

        // Player attacks
        player.Attack(enemy);

        if (!enemy.IsAlive())
        {
            Console.WriteLine($"{enemy.Name} is defeated!");
            player.GainXP(25);
            return;
        }

        // Enemy attacks back
        enemy.Attack(player);

        if (!player.IsAlive())
        {
            Console.WriteLine("You were defeated... Game Over");
        }
        else
        {
            Console.WriteLine($"You survived! HP remaining: {player.Stats.Health}");
        }
    }

}

