// SaveManager.cs
using System.IO;
using System.Text.Json;

public class SaveManager
{
    private const string SaveFileName = "savegame.json";

    public void SaveGame(Player player)
    {
        SaveData data = new SaveData
        {
            Name = player.Name,
            Level = player.Level,
            CurrentXP = player.CurrentXP,
            XPToNextLevel = player.XPToNextLevel,
            Stats = player.Stats
        };

        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(SaveFileName, json);

        Console.WriteLine("Game saved successfully.");
    }

    public Player? LoadGame()
    {
        if (!File.Exists(SaveFileName))
        {
            Console.WriteLine("No save file found.");
            return null;
        }

        string json = File.ReadAllText(SaveFileName);
        SaveData? data = JsonSerializer.Deserialize<SaveData>(json);

        if (data == null)
        {
            Console.WriteLine("Failed to load save data.");
            return null;
        }

        Player player = new Player(data.Name);
        player.LoadFromSave(data);

        Console.WriteLine("Game loaded successfully.");
        return player;
    }
}
