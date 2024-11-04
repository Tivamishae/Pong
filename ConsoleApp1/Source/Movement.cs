public delegate void MovementCommand(string action);


public interface IMovement
{
    void Movement();
}

public class ComputerMovement : IMovement
{
    private Ball _ball;
    private IPlayer _computer;
    private Random _random = new Random();

    private int ServeRandomChance = 1;
    private int ServeAlternativeChance = 25;
    private int RacketMoveChance = 2;
    private int AbilityActivateChance = 1;
    private int AbilityRandomRange = 150;

    public ComputerMovement(Ball ball, IPlayer computer)
    {
        _ball = ball;
        _computer = computer;
    }

    public void Movement()
    {
        if (_ball.Serve)
        {
            HandleServe();
        }
        else
        {
            HandleRacketMovement();
        }

        TryActivateAbility();
    }

    private void HandleServe()
    {
        int serveChance = _random.Next(1, 46);

        if (serveChance == ServeRandomChance)
        {
            _ball.ServeBall(1);
        }
        else if (serveChance == ServeAlternativeChance)
        {
            _ball.ServeBall(-1);
        }
    }

    private void HandleRacketMovement()
    {
        int moveChance = _random.Next(1, 46);
        var ballPositionY = _ball.ReturnCoordinates()[0].Item2;
        var computerPositionY = _computer.ReturnCoordinates()[1].Item2;

        if (ballPositionY > computerPositionY)
        {
            _computer.RacketAction(moveChance < RacketMoveChance ? "Up" : "Down");
        }
        else if (ballPositionY < computerPositionY)
        {
            _computer.RacketAction(moveChance < RacketMoveChance ? "Down" : "Up");
        }
    }

    private void TryActivateAbility()
    {
        int abilityChance = _random.Next(1, AbilityRandomRange + 1);

        if (abilityChance == AbilityActivateChance && !_computer.AbilityIsActive)
        {
            _computer.RacketAction("Ability");
        }
    }
}


public class PlayerMovement : IMovement
{
    private MovementCommand Move;
    private Ball Ball;
    private ConsoleKey UpKey;
    private ConsoleKey DownKey;
    private ConsoleKey AbilityKey;
    private ConsoleKey SwitchAbilityKey;

    public PlayerMovement(MovementCommand move, ConsoleKey upKey, ConsoleKey downKey, ConsoleKey abilityKey, ConsoleKey switchAbilityKey, Ball ball)
    {
        Move = move;
        this.Ball = ball;
        this.UpKey = upKey;
        this.DownKey = downKey;
        this.AbilityKey = abilityKey;
        this.SwitchAbilityKey = switchAbilityKey;
    }

    private void ServeOrMove(string action, int direction)
    {
        if (Ball.Serve)
        {
            Ball.ServeBall(direction);
        }
        else
        {
            Move(action);
        }
    }

    public void Movement()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == UpKey)
            {
                ServeOrMove("Up", -1);
            }
            else if (key == DownKey)
            {
                ServeOrMove("Down", 1);
            }
            else if (key == AbilityKey)
            {
                Move("Ability");
            }
            else if (key == SwitchAbilityKey)
            {
                Move("SwitchAbility");
            }
        }
    }
}