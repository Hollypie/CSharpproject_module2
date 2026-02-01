using System;
using System.IO;
using System.Text.Json;

public class Game
{
    private Player? player;
    private Random random = new Random();
    private string savePath = "savegame.json"; // always in project folder

    public void ShowMainMenu()
    {
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Random Encounter");
        Console.WriteLine("4. Save Game");
        Console.WriteLine("5. Exit");
        Console.WriteLine();
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
                return true;
            case "2":
                LoadGame();
                return true;
            case "3":
                RandomEncounter();
                return true;
            case "4":
                SaveGame();
                return true;
            case "5":
                Console.WriteLine("Exiting program...");
                return false;
            default:
                Console.WriteLine("Invalid input. Try again.");
                return true;
        }
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

        string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(savePath, json);
        Console.WriteLine($"Game saved at: {Path.GetFullPath(savePath)}");
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string json = File.ReadAllText(savePath);
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

        Enemy encounter = random.Next(2) == 0 ? new Skeleton() : new Goblin();
        Console.WriteLine($"\nA wild {encounter.Name} appears!");
        Console.WriteLine($"Enemy HP: {encounter.Stats.Health}, Strength: {encounter.Stats.Strength}, Defense: {encounter.Stats.Defense}");

        // Simple combat
        int damageToEnemy = Math.Max(player.Stats.Strength - encounter.Stats.Defense, 0);
        encounter.Stats.TakeDamage(damageToEnemy);
        Console.WriteLine($"Hero attacks {encounter.Name} for {damageToEnemy} damage!");

        int damageToHero = Math.Max(encounter.Stats.Strength - player.Stats.Defense, 0);
        player.Stats.TakeDamage(damageToHero);
        Console.WriteLine($"{encounter.Name} attacks Hero for {damageToHero} damage!");

        if (player.Stats.Health <= 0)
        {
            Console.WriteLine("Hero has been defeated!");
            player.Stats.Health = 1; // Prevent death for simplicity
        }
        else
        {
            Console.WriteLine($"You survived! HP remaining: {player.Stats.Health}");
        }

        // Save automatically after encounter
        SaveGame();
    }
}
