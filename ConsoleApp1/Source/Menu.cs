
using System.Security.Cryptography.X509Certificates;

public class IMenu
{

    protected static void DrawMenu(string text, string[] menu, int index)
    {
        Console.Clear();
        Console.WriteLine(text);
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
    protected void Scroll(string text, string[] menu, ref int index)
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

            DrawMenu(text, menu, index);

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
    public StartingMenu(Ball ball1)
    {
        Arena arenan = new Arena(20, 80);
        IAbility playerAbi = new Screw(ball1);
        IAbility playerAbi2 = new Smash(ball1);

        string startingText = "What kind of game do you want to play?";

        string[] startingMenu = {"Player vs. Player", "Player vs. Computer", "Computer vs. Computer"};   
        int index = 0;

        
        DrawMenu(startingText, startingMenu, index);
        Scroll(startingText, startingMenu, ref index);

        Console.Clear(); 

        if (index == 0) 
        {
            humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
            humanRacketBuilder racket2 = new humanRacketBuilder(78, 10, false, playerAbi2);
            Game game = new Game(ball1, racket1, racket2, arenan);
        }
        else if (index == 1)
        {
            ComputerMenu menu = new ComputerMenu(ball1, arenan);
        }
        else if (index == 2)
        {
            IMoveRacket impossibleMove = new ImpossibleMove();
            computerRacketBuilder racket1 = new computerRacketBuilder(1, 10, true, ball1, playerAbi2, impossibleMove);
            computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2, impossibleMove);
            Game game = new Game(ball1, racket1, racket2, arenan);
        }
        

    }


}

public class EndMenu : IMenu
{
    public EndMenu(IRacketBuilder racket, Arena arena)
    {
        string endText = $"{racket.ReturnName()} has won the game!";

        string[] endMenu = {"Play Again", "Exit"};
        int index = 0;
        
        DrawMenu(endText, endMenu, index);
        Scroll(endText, endMenu, ref index);

        Console.Clear();

        if (index == 0)
            {
                ColourMenu menu = new ColourMenu(arena);
            }
        else 
        {
            Environment.Exit(0);
        }
    }
    
}

public class ComputerMenu : IMenu
{
    public Ball ball1;
    public Arena arenan;



    
    public ComputerMenu(Ball ball, Arena arena)
    {
        IAbility playerAbi = new Screw(ball);
        IAbility playerAbi2 = new Smash(ball);

        IMoveRacket impossibleMove = new ImpossibleMove();
        IMoveRacket wackyMove = new WackyMove();
        IMoveRacket slowMove = new SlowMove();


        this.ball1 = ball;
        this.arenan = arena;

        string optionsText = "What kind of movement should the computer racket have?";

        string[] endMenu = {"Impossible", "Wacky", "Slow"};
        int index = 0;
        
        DrawMenu(optionsText, endMenu, index);
        Scroll(optionsText, endMenu, ref index);

        Console.Clear();

        if (index == 0)
            {
                humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
                computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2, impossibleMove);
                Game game = new Game(ball1, racket1, racket2, arenan);
            }
        else if (index == 1)
            {
                humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
                computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2, wackyMove);
                Game game = new Game(ball1, racket1, racket2, arenan);
            }
        else if (index == 2)
            {
                humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
                computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, false, ball1, playerAbi2, slowMove);
                Game game = new Game(ball1, racket1, racket2, arenan);
            }
    }
}

public class ShapeMenu : IMenu
{
   
    public Arena arenan;
    public IBallColour colour;

    public ShapeMenu(Arena arena, IBallColour colour)
    {
        this.colour = colour;
        this.arenan = arena;
        string shapeText = "What kind of shape should the ball have?";

        string[] shapeMenu = {"*", "O", "+"};
        int index = 0;
        
        DrawMenu(shapeText, shapeMenu, index);
        Scroll(shapeText, shapeMenu, ref index);

        if (index == 0)
        {
            Star starColour = new Star(colour);
            Ball ball1 = new Ball(40, 10, starColour);
            StartingMenu menu = new StartingMenu(ball1);
        }
        else if (index == 1)
        {
            Circle circleColour = new Circle(colour);
            Ball ball1 = new Ball(40, 10, circleColour);
            StartingMenu menu = new StartingMenu(ball1);
        }
        else if (index == 2)
        {
            Plus plusColour = new Plus(colour);
            Ball ball1 = new Ball(40, 10, plusColour);
            StartingMenu menu = new StartingMenu(ball1);
        }

        Console.Clear();
    }
}
public class ColourMenu : IMenu
{
 
    public Arena arena;

    public GreenColour GreenColour = new GreenColour();
    public RedColour RedColour = new RedColour();
    public BlueColour BlueColour = new BlueColour();



    public ColourMenu( Arena arena)
    {

        this.arena = arena;


        string colourText = "What colour should the ball have?";

        string[] colourMenu = {"Red", "Green", "Blue"};
        int index = 0;
        
        DrawMenu(colourText, colourMenu, index);
        Scroll(colourText, colourMenu, ref index);
        

        if (index == 0)
        {
              ShapeMenu ShapeMenu = new ShapeMenu(arena, RedColour);
        }
        else if (index == 1) 
        {
              ShapeMenu ShapeMenu = new ShapeMenu(arena, GreenColour);

        }
        else if (index == 2) {
              ShapeMenu ShapeMenu = new ShapeMenu(arena, BlueColour);

        }
        
        Console.Clear();


        
    }
}