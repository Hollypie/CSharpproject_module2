// Skeleton enemy is a subclass of the Abstract Enemy class. Skeleton inherits from Enemy and the has it's own custom changes.
public class Skeleton : Enemy
{
    public Skeleton()
        : base("Skeleton", new Stats(20, 3, 1), "Bone")
    {
    }

    public override void DecideAction()
    {
        Console.WriteLine("Skeleton rattles and swings its sword!");
    }
}
