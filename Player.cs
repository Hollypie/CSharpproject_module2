// Player.cs
using System;
using System.Collections.Generic;
using System.Text.Json;

public class Player
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int CurrentXP { get; private set; }
    public int XPToNextLevel { get; private set; }

    public Stats Stats { get; private set; }

    public List<string> Inventory { get; private set; }

    public Player(string name)
    {
        Name = name;
        Level = 1;
        CurrentXP = 0;
        XPToNextLevel = 100;
        Inventory = new List<string>();
        Stats = new Stats(); // default stats: Health=100, Strength=10, Defense=5
    }

    public void GainXP(int amount)
    {
        CurrentXP += amount;
        Console.WriteLine($"{Name} gained {amount} XP!");

        if (CurrentXP >= XPToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        CurrentXP = 0;
        XPToNextLevel += 50;

        Stats.Health += 10;
        Stats.Strength += 2;
        Stats.Defense += 1;

        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }

    public void TakeDamage(int amount)
    {
        Stats.Health -= amount;
        Console.WriteLine($"{Name} took {amount} damage! Remaining Health: {Stats.Health}");

        if (Stats.Health <= 0)
        {
            Console.WriteLine($"{Name} has fallen!");
        }
    }

    public void PrintStats()
    {
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine($"Strength: {Stats.Strength}");
        Console.WriteLine($"Defense: {Stats.Defense}");
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Stats.Health}");
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0)
        {
            Console.WriteLine(" - (empty)");
        }
        else
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($" - {item}");
            }
        }
    }

    // Load player from a SaveData object
    public void LoadFromSave(SaveData data)
    {
        Level = data.Level;
        CurrentXP = data.CurrentXP;
        XPToNextLevel = data.XPToNextLevel;

        Stats.CopyFrom(data.Stats);

        Inventory = new List<string>(data.Inventory);
    }
}
