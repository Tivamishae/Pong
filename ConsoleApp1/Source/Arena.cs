

class Arena(Game game, ArenaBorder arenaBorders, Menu menu)
{

    IPlayer Player1 { get; set; } = game.ReturnPlayers().Item1;
    IPlayer Player2 { get; set; } = game.ReturnPlayers().Item2;
    Ball Ball { get; set; } = game.ReturnBall();
    Menu Menu { get; set; } = menu;
    Game Game { get; set; } = game;

    Cooldown racketCollisionCooldown = new Cooldown(TimeSpan.FromSeconds(1));
    ArenaBorder ArenaBorders { get; set; } = arenaBorders;

    UI UI = new UI(game.ReturnPlayers().Item1, game.ReturnPlayers().Item2);
    bool Player1Turn = true;

    bool GameIsPlaying = true;

    public void GameLoop()
    {
        Console.CursorVisible = false;
        while (GameIsPlaying)
        {
            Console.Clear();
            UI.CreateUI();

            CreateArena();

            PlayerTurn();

            RacketBorderCollision(Player1, ArenaBorders);
            RacketBorderCollision(Player2, ArenaBorders);

            RacketBallCollision(Ball, Player1);
            RacketBallCollision(Ball, Player2);

            BallBorderCollision(Ball, ArenaBorders);

            Ball.MoveBall();
            Thread.Sleep(20);
        }
    }

    public void CreateArena()
    {
        (int, int) arenaSize = Game.ReturnArenaSize();
        int height = arenaSize.Item2;
        int width = arenaSize.Item1;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                List<(int, int)> coordinate = [(x, y)];
                switch (true)
                {
                    case var _ when CheckIfSides(coordinate[0]):
                        ArenaBorders.AddToBorder(coordinate[0]);
                        Console.ForegroundColor = ArenaBorders.BorderColor.SetColor();
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case var _ when CheckIfTopOrBot(coordinate[0]):
                        ArenaBorders.AddToBorder(coordinate[0]);
                        Console.ForegroundColor = ArenaBorders.BorderColor.SetColor();
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case var _ when CheckIfRacket(coordinate[0], Player1):
                        Console.ForegroundColor = Player1.RacketColor.SetColor();
                        Console.Write("I");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case var _ when CheckIfRacket(coordinate[0], Player2):
                        Console.ForegroundColor = Player2.RacketColor.SetColor();
                        Console.Write("I");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case var _ when CheckIfBall(coordinate):
                        Console.ForegroundColor = Ball.ReturnBallColor();
                        Console.Write(Ball.ReturnBallSymbol());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    default:
                        Console.Write(" ");
                        break;
                }
            }
            Console.WriteLine("");
        }
    }

    private bool CheckIfRacket((int, int) coordinate, IPlayer player)
    {
        List<(int, int)> racketCoordinates = player.ReturnCoordinates();

        for (int i = 0; i < racketCoordinates.Count; i++)
        {
            if (racketCoordinates[i] == coordinate)
            {
                return true;
            }
        }
        return false;
    }

    private void RacketBorderCollision(IPlayer player, ArenaBorder arenaBorders)
    {
        CollisionChecker<ICoordinates> collisionChecker = new CollisionChecker<ICoordinates>(player, arenaBorders);

        if (collisionChecker.CheckCollision())
        {
            var playerCoordinates = player.ReturnCoordinates();
            //LINQs Syntax Any
            if (playerCoordinates.Any(coord => coord.Item2 == 1))
            {
                player.RacketAction("Down");
            }
            else if (playerCoordinates.Any(coord => coord.Item2 == Game.Height - 2))
            {
                player.RacketAction("Up");
            }
        }
    }

    private void BallBorderCollision(Ball ball, ArenaBorder arenaBorders)
    {
        List<(int, int)> ballCoordinate = ball.ReturnCoordinates();
        if (ballCoordinate[0].Item2 <= 1 || ballCoordinate[0].Item2 >= Game.Height - 2)
        {
            ball.YDirection = ball.YDirection * -1;
        }
        if (ballCoordinate[0].Item1 <= 0)
        {
            WinPoint(Player2, Player1, 1);
        }
        else if (ballCoordinate[0].Item1 >= Game.Width - 1)
        {
            WinPoint(Player1, Player2, -2);
        }
    }

    private void RacketBallCollision(Ball ball, IPlayer player)
    {
        if (!racketCollisionCooldown.CanUse())
        {
            return;
        }

        CollisionChecker<ICoordinates> collisionChecker = new CollisionChecker<ICoordinates>(ball, player);

        if (collisionChecker.CheckCollision())
        {
            ball.YDirection = Math.Sign(ball.YDirection);
            ball.XDirection = Math.Sign(ball.XDirection) * -1;

            if (player.AbilityIsActive)
            {
                player.UseAbility();
                player.ReduceCooldown();
            }

            racketCollisionCooldown.Use();

            Player1Turn = !Player1Turn;
        }
    }

    private void PlayerTurn()
    {
        if (Player1Turn)
        {
            Game.ReturnMovement().Player1Movement.Movement();
        }
        else
        {
            Game.ReturnMovement().Player2Movement.Movement();
        }
    }

    private bool CheckIfBall(List<(int, int)> coordinates)
    {
        List<(int, int)> ballCoordinates = Ball.ReturnCoordinates();

        if (ballCoordinates[0] == coordinates[0])
        {
            return true;
        }
        return false;
    }

    private bool CheckIfSides((int, int) coordinates)
    {
        (int, int) arenaSize = Game.ReturnArenaSize();

        if (0 == coordinates.Item1 || arenaSize.Item1 - 1 == coordinates.Item1)
        {
            return true;
        }
        return false;
    }

    private bool CheckIfTopOrBot((int, int) coordinates)
    {
        (int, int) arenaSize = Game.ReturnArenaSize();

        if (0 == coordinates.Item2 || arenaSize.Item2 - 1 == coordinates.Item2)
        {
            return true;
        }

        return false;
    }

    private void WinPoint(IPlayer player1, IPlayer player2, int directionInt)
    {
        player1.Score += 1;
        if (player1.Score == Game.AmountOfRounds)
        {
            ResetGame(player1, player2);
            GameIsPlaying = Menu.FinishedGameMenu(player1);
        }

        player1.CoordinateReset();
        player2.CoordinateReset();

        Ball.StopBallMovement();

        Ball.Coordinates = [(player2.Coordinates[2].Item1 + directionInt, 10)];
    }

    public void ResetGame(IPlayer player1, IPlayer player2)
    {
        player1.Cooldown = 0;
        player2.Cooldown = 0;
        player1.Score = 0;
        player2.Score = 0;
    }
}