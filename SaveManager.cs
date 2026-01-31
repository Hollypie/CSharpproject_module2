// SaveManager.cs
using System;
using System.IO;
using System.Text.Json;

public class SaveManager
{
    private const string SaveFileName = "savegame.json";

    // Save the player data to a JSON file
    public void SaveGame(Player player)
    {
        if (player == null)
        {
            Console.WriteLine("No player to save.");
            return;
        }

        // Create a SaveData object to serialize
        SaveData data = new SaveData
        {
            Name = player.Name,
            Level = player.Level,
            CurrentXP = player.CurrentXP,
            XPToNextLevel = player.XPToNextLevel,
            Stats = new Stats(player.Stats.Health, player.Stats.Strength, player.Stats.Defense),
            Inventory = new List<string>(player.Inventory)
        };

        // Serialize to JSON
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(SaveFileName, json);

        Console.WriteLine("Game saved successfully!");
    }

    // Load player data from JSON file
    public Player? LoadGame()
    {
        if (!File.Exists(SaveFileName))
        {
            Console.WriteLine("No save file found.");
            return null;
        }

        string json = File.ReadAllText(SaveFileName);

        try
        {
            SaveData data = JsonSerializer.Deserialize<SaveData>(json)!;

            // Rebuild player object from save data
            Player player = new Player(data.Name)
            {
                Inventory = new List<string>(data.Inventory)
            };
            player.LoadFromSave(data);

            Console.WriteLine("Game loaded successfully!");
            return player;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading save: {ex.Message}");
            return null;
        }
    }
}

// Class to hold data for saving/loading
public class SaveData
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public int CurrentXP { get; set; }
    public int XPToNextLevel { get; set; }
    public Stats Stats { get; set; } = new Stats();
    public List<string> Inventory { get; set; } = new List<string>();
}
