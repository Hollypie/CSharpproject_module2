// Stats.cs
public class Stats
{
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }

    public Stats(int health = 100, int strength = 10, int defense = 5)
    {
        Health = health;
        Strength = strength;
        Defense = defense;
    }

    // Copies values from another Stats object
    public void CopyFrom(Stats other)
    {
        Health = other.Health;
        Strength = other.Strength;
        Defense = other.Defense;
    }
}
