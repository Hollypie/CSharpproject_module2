public class Stats
{

    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }

    // Parameterless constructor for JSON deserialization
    public Stats() { }

    // Normal constructor for creating new Stats
    public Stats(int health, int strength, int defense)
    {
        Health = health;
        Strength = strength;
        Defense = defense;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
    }
}
