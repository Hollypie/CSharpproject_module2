// Goblin enemy is a subclass of the Abstract Enemy class. Goblin inherits from Enemy and the has it's own custom changes.
public class Goblin : Enemy
{
    public Goblin()
        : base("Goblin", new Stats(15, 4, 0), "Goblin Ear")
    {
    }

    public override void DecideAction()
    {
        Console.WriteLine("Goblin screeches and lunges!");
    }
}
