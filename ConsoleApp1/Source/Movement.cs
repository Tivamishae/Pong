public delegate void MovementCommand(string action);


public interface IMovement
{
    void Movement();
}

/// <summary>
/// Strategy pattern
/// Vi använder oss av olika svårighetsgrader som injekteras i vår ComputerPlayer. Detta tillåts eftersom vi injekterar IMovement.
/// Vi använder det eftersom det låter oss dynamiskt ändra svårighetsgraden efter compiletime.
/// </summary>

public interface IDifficulty
{
    int GetServeChance();
    int GetMoveChance();
    int GetAbilityChance();

    int GetUltimateAbilityChance();
}

public class EasyDifficulty : IDifficulty
{
    public int GetServeChance() => 30;
    public int GetMoveChance() => 10;
    public int GetAbilityChance() => 50;

    public int GetUltimateAbilityChance() => 15;
}

public class MediumDifficulty : IDifficulty
{
    public int GetServeChance() => 15;
    public int GetMoveChance() => 25;
    public int GetAbilityChance() => 25;

    public int GetUltimateAbilityChance() => 30;
}

public class HardDifficulty : IDifficulty
{
    public int GetServeChance() => 1;
    public int GetMoveChance() => 45;
    public int GetAbilityChance() => 10;
    public int GetUltimateAbilityChance() => 50;
}

public class ComputerMovement : IMovement
{
    private Ball _ball;
    private IPlayer _computer;
    private Random _random = new Random();
    private IDifficulty _difficulty;
    private DateTime _lastUltimateAbilityCheck;

    private int abilityCooldownTracker = 0;
    private const int abilityActivationThreshold = 100;

    private int UltimateAbilityInternalCooldown = 1;

    public ComputerMovement(Ball ball, IPlayer computer, IDifficulty difficulty)
    {
        _ball = ball;
        _computer = computer;
        _difficulty = difficulty;
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

        if ((DateTime.Now - _lastUltimateAbilityCheck).TotalSeconds >= UltimateAbilityInternalCooldown)
        {
            TryActivateUltimateAbility();
            _lastUltimateAbilityCheck = DateTime.Now;
            UltimateAbilityInternalCooldown = 1;
        }
    }

    private void HandleServe()
    {
        int serveChance = _random.Next(1, 46);

        if (serveChance <= _difficulty.GetServeChance())
        {
            _ball.ServeBall(1);
        }
        else
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
            _computer.RacketAction(moveChance <= _difficulty.GetMoveChance() ? "Down" : "Up");
        }
        else if (ballPositionY < computerPositionY)
        {
            _computer.RacketAction(moveChance <= _difficulty.GetMoveChance() ? "Up" : "Down");
        }
    }

    private void TryActivateAbility()
    {
        abilityCooldownTracker++;

        int abilityChance = _random.Next(1, 101);
        int adjustedThreshold = abilityActivationThreshold - abilityCooldownTracker;

        if (adjustedThreshold <= 0) adjustedThreshold = 1;

        if (abilityChance <= _difficulty.GetAbilityChance() && !_computer.AbilityIsActive)
        {
            if (abilityChance <= adjustedThreshold)
            {
                _computer.RacketAction("Ability");
                abilityCooldownTracker = 0;
            }
        }
    }
    private void TryActivateUltimateAbility()
    {
        int abilityChance = _random.Next(1, 101);

        if (abilityChance <= _difficulty.GetUltimateAbilityChance() && _computer.Ability.UltimateAbility.UltimateAbilityCooldown == 0)
        {
            _computer.RacketAction("SwitchAbility");
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