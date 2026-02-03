// Stats is a class that stores the player object and the enemy object statistics for the logic calculations for battle. 
public class Stats
{

    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }

    // Parameterless constructor for JSON deserialization
    public Stats() { }

    // Normal constructor for creating new Stats for player/hero and enemy
    public Stats(int health, int strength, int defense)
    {
        Health = health;
        Strength = strength;
        Defense = defense;
    }

    // method for hero/player and enemies to take damage.
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
    }
}
