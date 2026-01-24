public class Game
{
    private Player? player;

    public Game()
    {
        player = null; 
    }

    public void ShowMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Exit");
    }

    public string GetMenuChoice()
    {
        Console.Write("Enter your choice: ");
        return Console.ReadLine() ?? "";
    }

    public bool HandleMenuChoice(string choice)
    {
        if (choice == "1")
        {
            StartNewGame();
            return true;
        }
        else if (choice == "2")
        {
            Console.WriteLine("You chose to load a game");
            return true;
        }
        else if (choice == "3")
        {
            Console.WriteLine("You have chosen to exit the program.");
            return false;
        }
        else
        {
            Console.WriteLine("That is an incorrect input. Try again.");
            return true;
        }
    }

    public void StartNewGame()
    {
        Console.WriteLine();
        Console.WriteLine("Starting new game...");

        player = new Player("Hero");

        Console.WriteLine($"Name: {player.Name}");
        Console.WriteLine($"Level: {player.Level}");
        Console.WriteLine($"Health: {player.Health}");
    }
}
