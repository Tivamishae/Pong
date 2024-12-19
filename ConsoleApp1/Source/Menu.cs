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
        //Startmenyn producerades med hjälp av ett LLM
        Console.WriteLine("**************************************************************");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                      WELCOME TO PONG!                      *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*       Get ready for an exciting game of Pong!              *");
        Console.WriteLine("*       A classic battle of skill and reflexes awaits you!   *");
        Console.WriteLine("*                                                            *");
        Console.WriteLine("*                          Controls:                         *");
        Console.WriteLine("*       - Player 1: Move Up (W) / Down (S)                   *");
        Console.WriteLine("*       - Player 1: Use ability (F) / Ultimate Ability (D)   *");
        Console.WriteLine("*       - Player 2: Move Up (↑) / Down (↓)                   *");
        Console.WriteLine("*       - Player 2: Use ability (L) / Ultimate Ability (<-)  *");
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

        UltimateAbility player1UltimateAbility = ChooseUltimateAbility(Ball, "player 1");
        UltimateAbility player2UltimateAbility = ChooseUltimateAbility(Ball, "player 2");

        AbstractAbility player1Ability = ChooseAbility(Ball, player1UltimateAbility, "player 1");
        AbstractAbility player2Ability = ChooseAbility(Ball, player2UltimateAbility, "player 2");

        Player1 = new HumanPlayer(5, 10, Player1Name, player1Ability, Player1RacketColor);
        Player2 = ChooseEnemyType(Player2RacketColor, Player2Name, player2Ability, Ball);
        if (Player2 is HumanPlayer)
        {
            Player2Movement = new PlayerMovement(Player2.RacketAction, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.L, ConsoleKey.LeftArrow, Ball);
        }
        else if (Player2 is ComputerPlayer)
        {
            IDifficulty AIDifficulty = ChooseAIDifficulty();
            Player2Movement = new ComputerMovement(Ball, Player2, AIDifficulty);
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

    public UltimateAbility ChooseUltimateAbility(Ball ball, string player)
    {
        SelectionsUltimateAbility UltimateAbilitySelections = new SelectionsUltimateAbility(ball);
        IIterator<(UltimateAbility, string)> UltimateAbilityIterator = UltimateAbilitySelections.CreateIterator();
        bool ultimateAbilityHasBeenChosen = false;

        while (!ultimateAbilityHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose ultimate ability for " + player + " Switch with (↓↑), enter with (Enter)");
            Console.WriteLine("");
            foreach ((UltimateAbility, string) UAbility in UltimateAbilitySelections.Selections)
            {
                if (UltimateAbilityIterator.Current.Item2 == UAbility.Item2)
                {
                    Console.WriteLine(">" + UAbility.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(UAbility.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                UltimateAbilityIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                UltimateAbilityIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return UltimateAbilityIterator.Current.Item1;
            }
        }
        return UltimateAbilityIterator.Current.Item1;
    }

    public AbstractAbility ChooseAbility(Ball ball, UltimateAbility ultimateAbility, string player)
    {
        SelectionsAbility AbilitySelections = new SelectionsAbility(ball, ultimateAbility);
        IIterator<(AbstractAbility, string)> AbilityIterator = AbilitySelections.CreateIterator();
        bool abilityHasBeenChosen = false;

        while (!abilityHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose ability for " + player + " Switch with (↓↑), enter with (Enter)");
            Console.WriteLine("");
            foreach ((AbstractAbility, string) ability in AbilitySelections.Selections)
            {
                if (AbilityIterator.Current.Item2 == ability.Item2)
                {
                    Console.WriteLine(">" + ability.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(ability.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                AbilityIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                AbilityIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return AbilityIterator.Current.Item1;
            }
        }
        return AbilityIterator.Current.Item1;
    }

    public IPlayer ChooseEnemyType(IColor racketColor, string playerName, AbstractAbility ability, Ball ball)
    {
        SelectionsEnemyType EnemyTypeSelections = new SelectionsEnemyType(racketColor, playerName, ability, ball);
        IIterator<(IPlayer, string)> EnemyTypeIterator = EnemyTypeSelections.CreateIterator();
        bool enemyTypeHasBeenChosen = false;

        while (!enemyTypeHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose type of player for player 2 Switch with (↓↑), enter with (Enter)");
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

    public IDifficulty ChooseAIDifficulty()
    {
        SelectionsAIDifficulty AIDifficultySelections = new SelectionsAIDifficulty();
        IIterator<(IDifficulty, string)> AIDifficultyIterator = AIDifficultySelections.CreateIterator();
        bool AIDifficultyHasBeenChosen = false;

        while (!AIDifficultyHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("Choose computer difficulty Switch with (↓↑), enter with (Enter)");
            Console.WriteLine("");
            foreach ((IDifficulty, string) AIDifficulty in AIDifficultySelections.Selections)
            {
                if (AIDifficultyIterator.Current.Item2 == AIDifficulty.Item2)
                {
                    Console.WriteLine(">" + AIDifficulty.Item2 + "<");
                }
                else
                {
                    Console.WriteLine(AIDifficulty.Item2);
                }
            }
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
            {
                AIDifficultyIterator.MoveNext(1);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                AIDifficultyIterator.MoveNext(-1);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return AIDifficultyIterator.Current.Item1;
            }
        }
        return AIDifficultyIterator.Current.Item1;
    }

    public int SelectAmountOfRoundsMenu()
    {
        SelectionsAmountOfRounds AmountOfRoundsSelections = new SelectionsAmountOfRounds();
        IIterator<(int, string)> AmountOfRoundsIterator = AmountOfRoundsSelections.CreateIterator();
        bool amountOfRoundsHasBeenChosen = false;

        while (!amountOfRoundsHasBeenChosen)
        {
            Console.Clear();
            Console.WriteLine("How many wins do you want to play for? Switch with (↓↑), enter with (Enter)");
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