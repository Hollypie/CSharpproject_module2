// Player.cs
public class Player
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int CurrentXP { get; private set; }
    public int XPToNextLevel { get; private set; }

    public Stats Stats;
    // Inventory will come later

    public Player(string name)
    {
        Name = name;
        Level = 1;
        CurrentXP = 0;
        XPToNextLevel = 100;

        Stats = new Stats
        {
            Health = 100,
            Strength = 10,
            Defense = 5
        };
    }

    public void GainXP(int amount)
    {
        CurrentXP += amount;

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

    public void LoadFromSave(SaveData data)
    {
        Level = data.Level;
        CurrentXP = data.CurrentXP;
        XPToNextLevel = data.XPToNextLevel;
        Stats = data.Stats;
    }

}
