
public class IMenu
{

    protected static void DrawMenu(string[] menu, int index)
    {
        Console.Clear();
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == index) 
            {
                Console.WriteLine($"[{menu[i]}]");
            }
            else 
            {   
                Console.WriteLine($"{menu[i]}");
            }
        }
    }
    protected void Scroll(string[] menu, ref int index)
    {
        bool selecting = true;
    
        while(selecting)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    index = PreviousIndex(menu, index);
                    break;
                case ConsoleKey.UpArrow:
                    index = PreviousIndex(menu, index);
                    break;
                case ConsoleKey.S:
                    index = NextIndex(menu, index);
                    break;
                case ConsoleKey.DownArrow:
                    index = NextIndex(menu, index);
                    break;
                case ConsoleKey.Enter:
                    selecting = false;
                    break;
 
            }

            DrawMenu(menu, index);

        }
    }
    protected int NextIndex(string[] menu, int index)
    {
        index++;

        if (index >= menu.Length)
        {
            index = 0;
        }
        return index;
    }

    protected int PreviousIndex(string[] menu, int index)
    {
        index--;
        if (index < 0)
        {
            index = menu.Length - 1; 
        }
        return index;
    }
}

public class StartingMenu : IMenu
{
    public StartingMenu()
    {
        Arena arenan = new Arena(20, 80);
        Ball ball1 = new Ball(40, 10);
        IAbility playerAbi = new Screw(ball1);
        IAbility playerAbi2 = new Smash(ball1);

        Console.WriteLine("Welcome to Pong!");

        string[] startingMenu = {"Player vs. Player", "Player vs. Computer", "Computer vs. Computer"};   
        int index = 0;

        Console.WriteLine("What kind of game do you want to play?");
        DrawMenu(startingMenu, index);
        Scroll(startingMenu, ref index);

        Console.Clear(); 
        if (index == 0) 
        {
            humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
            humanRacketBuilder racket2 = new humanRacketBuilder(78, 10, false, playerAbi2);
            Game game = new Game(ball1, racket1, racket2, arenan);
        }
        else if (index == 1)
        {
            humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
            computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2);
            Game game = new Game(ball1, racket1, racket2, arenan);
        }
        else if (index == 2)
        {
            computerRacketBuilder racket1 = new computerRacketBuilder(1, 10, true, ball1, playerAbi);
            computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2);
            Game game = new Game(ball1, racket1, racket2, arenan);
        }

    }


}

public class EndMenu : IMenu
{
    public EndMenu(IRacketBuilder racket)
    {
        Console.WriteLine($"{racket.ReturnName()} has won the game!");

        string[] endMenu = {"Play Again", "Exit"};
        int index = 0;
        
        DrawMenu(endMenu, index);
        Scroll(endMenu, ref index);

        Console.Clear();

        if (index == 0)
            {
                StartingMenu menu = new StartingMenu();
            }
        else 
        {
            Environment.Exit(0);
        }
    }
    
}