using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class Menu
{
    public IColor BallColor { get; set; }
    public IBallShape BallShape { get; set; }

    public Ball Ball { get; set; }

    public IColor BorderColor { get; set; }

    public IColor Player1RacketColor { get; set; }
    public IColor Player2RacketColor { get; set; }

    public string Player1Name { get; set; }
    public string Player2Name { get; set; }
    public IPlayer Player1 { get; set; }
    public IPlayer Player2 { get; set; }
    public IMovement Player2Movement { get; set; }

    public int AmountOfRounds { get; set; }

    public Menu()
    {
        Console.CursorVisible = false;
        Console.Clear();
        //ChatGPT har skrivit detta:
        Console.WriteLine("**************************************************************");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                      WELCOME TO PONG!                      *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*       Get ready for an exciting game of Pong!              *");
        Console.WriteLine("*       A classic battle of skill and reflexes awaits you!   *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                          Controls:                         *");
        Console.WriteLine("*       - Player 1: Move Up (W) / Down (S)                   *");
        Console.WriteLine("*       - Player 1: Use ability (L) / Switch Ability (<-)    *");
        Console.WriteLine("*       - Player 2: Move Up (↑) / Down (↓)                   *");
        Console.WriteLine("*       - Player 2: Use ability (F) / Switch Ability (D)     *");
        Console.WriteLine("*       - Only the recieving player can move his/her racket  *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*      Score Points by Getting the Ball Past Your Opponent!  *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                   May the best player win!                 *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                 Press any button to continue               *");
        Console.WriteLine("**************************************************************");
        Console.ReadKey();

        BallColor = SelectColorMenu("Choose the color of the ball that you want to play with. Switch with (↓↑), enter with (Enter)");
        BallShape = SelectBallShapeMenu(BallColor);
        Ball = new Ball(BallShape);

        BorderColor = SelectColorMenu("Choose the color of the arena borders. Switch with (↓↑), enter with (Enter)");

        Player1RacketColor = SelectColorMenu("Choose player 1 racket color. Switch with (↓↑), enter with (Enter)");
        Player2RacketColor = SelectColorMenu("Choose player 2 racket color. Switch with (↓↑), enter with (Enter)");

        Console.Clear();
        Player1Name = ChoosePlayerName("Choose the name of player 1.");
        Console.Clear();
        Player2Name = ChoosePlayerName("Choose the name of player 2.");
        Console.CursorVisible = false;

        Player1 = new HumanPlayer(5, 10, Player1Name, new AbilityInventory(Ball), Player1RacketColor);
        Player2 = ChooseEnemyType(Player2RacketColor, Player2Name, new AbilityInventory(Ball), Ball);
        if (Player2 is HumanPlayer)
        {
            Player2Movement = new PlayerMovement(Player2.RacketAction, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.L, ConsoleKey.LeftArrow, Ball);
        }
        else if (Player2 is ComputerPlayer)
        {
            Player2Movement = new ComputerMovement(Ball, Player2);
        }

        AmountOfRounds = SelectAmountOfRoundsMenu();
    }

    public IColor SelectColorMenu(string question)
    {
        SelectionsColor ColorSelections = new SelectionsColor();
        IIterator<(IColor, string)> ColorIterator = ColorSelections.CreateIterator();
        bool colorHasBeenChosen = false;

        while (!colorHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine(question);
            Console.WriteLine("");
            foreach ((IColor, string) colorAndColorName in ColorSelections.Selections)
            {
                if (ColorIterator.Current.Item2 == colorAndColorName.Item2)
                {
                    Console.WriteLine(">" + colorAndColorName.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(colorAndColorName.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                ColorIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                ColorIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return ColorIterator.Current.Item1;
            }
        }
        return ColorIterator.Current.Item1;
    }

    public IBallShape SelectBallShapeMenu(IColor ballColor)
    {
        SelectionsBallShape BallShapeSelections = new SelectionsBallShape(ballColor);
        IIterator<(IBallShape, string)> ShapeIterator = BallShapeSelections.CreateIterator();
        bool ballShapeHasBeenChosen = false;

        while (!ballShapeHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose the shape of the ball that you want to play with. Switch with (↓↑), enter with (Enter)");
            Console.WriteLine("");
            foreach ((IBallShape, string) shapeAndShapeName in BallShapeSelections.Selections)
            {
                if (ShapeIterator.Current.Item2 == shapeAndShapeName.Item2)
                {
                    Console.WriteLine(">" + shapeAndShapeName.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(shapeAndShapeName.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                ShapeIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                ShapeIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return ShapeIterator.Current.Item1;
            }
        }
        return ShapeIterator.Current.Item1;
    }

    public string ChoosePlayerName(string question)
    {
        Console.CursorVisible = true;
        Console.WriteLine(question);
        Console.WriteLine("");
        string name = Console.ReadLine();

        if (name == null || name == "")
        {
            Console.Clear();
            Console.WriteLine("Name needs to be atleast 1 symbol");
            ChoosePlayerName(question);
        }
        else
        {
            return name;
        }
        return name;
    }

    public IPlayer ChooseEnemyType(IColor racketColor, string playerName, AbilityInventory abilityInventory, Ball ball)
    {
        SelectionsEnemyType EnemyTypeSelections = new SelectionsEnemyType(racketColor, playerName, abilityInventory, ball);
        IIterator<(IPlayer, string)> EnemyTypeIterator = EnemyTypeSelections.CreateIterator();
        bool enemyTypeHasBeenChosen = false;

        while (!enemyTypeHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose type of player for player 2");
            Console.WriteLine("");
            foreach ((IPlayer, string) enemyType in EnemyTypeSelections.Selections)
            {
                if (EnemyTypeIterator.Current.Item2 == enemyType.Item2)
                {
                    Console.WriteLine(">" + enemyType.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(enemyType.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                EnemyTypeIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                EnemyTypeIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return EnemyTypeIterator.Current.Item1;
            }
        }
        return EnemyTypeIterator.Current.Item1;
    }

    public int SelectAmountOfRoundsMenu()
    {
        SelectionsAmountOfRounds AmountOfRoundsSelections = new SelectionsAmountOfRounds();
        IIterator<(int, string)> AmountOfRoundsIterator = AmountOfRoundsSelections.CreateIterator();
        bool amountOfRoundsHasBeenChosen = false;

        while (!amountOfRoundsHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("How many wins do you want to play for?");
            Console.WriteLine("");
            foreach ((int, string) choice in AmountOfRoundsSelections.Selections)
            {
                if (AmountOfRoundsIterator.Current.Item2 == choice.Item2)
                {
                    Console.WriteLine(">" + choice.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(choice.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                AmountOfRoundsIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                AmountOfRoundsIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return AmountOfRoundsIterator.Current.Item1;
            }
        }
        return AmountOfRoundsIterator.Current.Item1;
    }

    public bool FinishedGameMenu(IPlayer winner)
    {
        SelectionsPlayAgain PlayAgainSelections = new SelectionsPlayAgain();
        IIterator<(bool, string)> PlayAgainIterator = PlayAgainSelections.CreateIterator();
        bool answerHasBeenChosen = false;

        while (!answerHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Congratulations " + winner.Name + " you won!");
            Console.WriteLine("");
            Console.WriteLine("Do you wish to play again?");
            Console.WriteLine("");
            foreach ((bool, string) choice in PlayAgainSelections.Selections)
            {
                if (PlayAgainIterator.Current.Item2 == choice.Item2)
                {
                    Console.WriteLine(">" + choice.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(choice.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                PlayAgainIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                PlayAgainIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return PlayAgainIterator.Current.Item1;
            }
        }
        return PlayAgainIterator.Current.Item1;
    }
}