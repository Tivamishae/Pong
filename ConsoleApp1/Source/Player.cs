public interface IPlayer : ICoordinates
{
    public void RacketAction(string action);
    public string Name { get; set; }
    public List<(int, int)> ReturnCoordinates();

    public void ChangeCoordinates(List<(int, int)> newCoordinates);
    public void UseAbility();

    public void CoordinateReset();

    public void ResetPlayer();

    public bool AbilityIsActive { get; set; }

    public IColor RacketColor { get; set; }

    public IIterator<AbstractAbility> AbilityIterator { get; set; }

    public int Cooldown { get; set; }

    public Task ReduceCooldown();

    public int Score { get; set; }
}

public interface IComputerPlayer : IPlayer
{
    Ball BallInPlay { get; set; }
}

public class HumanPlayer(int xPos, int yPos, string name, AbilityInventory abilityInventory, IColor color) : IPlayer
{
    public List<(int, int)> Coordinates { get; set; } =
    [
        (xPos, yPos - 1),
        (xPos, yPos),
        (xPos, yPos + 1),
        (xPos -1 , yPos - 1),
        (xPos -1 , yPos),
        (xPos -1 , yPos + 1),
    ];
    public string Name { get; set; } = name;

    public IColor RacketColor { get; set; } = color;

    public IIterator<AbstractAbility> AbilityIterator { get; set; } = abilityInventory.CreateIterator();

    public bool AbilityIsActive { get; set; } = false;

    public int Cooldown { get; set; } = 0;

    public int Score { get; set; } = 0;

    public void RacketAction(string action)
    {
        if (action == "Up")
        {
            ChangeCoordinates(Coordinates.Select(c => (c.Item1, c.Item2 - 1)).ToList());
        }
        if (action == "Down")
        {
            ChangeCoordinates(Coordinates.Select(c => (c.Item1, c.Item2 + 1)).ToList());
        }
        if (action == "Ability" && Cooldown == 0)
        {
            AbilityIsActive = !AbilityIsActive;
        }
        if (action == "SwitchAbility" && !AbilityIsActive)
        {
            AbilityIterator.MoveNext(1);
        }
    }

    public void ChangeCoordinates(List<(int, int)> newCoordinates)
    {
        Coordinates = newCoordinates;
    }

    public async Task ReduceCooldown()
    {
        while (Cooldown > 0)
        {
            Cooldown -= 1;

            await Task.Delay(1000);
        }
    }

    public void CoordinateReset()
    {
        Coordinates = [
        (xPos, yPos - 1),
        (xPos, yPos),
        (xPos, yPos + 1),
        (xPos -1 , yPos - 1),
        (xPos -1 , yPos),
        (xPos -1 , yPos + 1),
    ];
    }

    public void ResetPlayer()
    {
        Cooldown = 0;
    }

    public List<(int, int)> ReturnCoordinates()
    {
        return Coordinates;
    }
    public void UseAbility()
    {
        AbilityIterator.Current.UseAbility();
        AbilityIsActive = false;
        Cooldown = 12;
    }
}

public class ComputerPlayer(int xPos, int yPos, string name, AbilityInventory abilityInventory, IColor color, Ball ball) : IComputerPlayer
{
    public List<(int, int)> Coordinates { get; set; } =
    [
        (xPos, yPos - 1),
        (xPos, yPos),
        (xPos, yPos + 1),
        (xPos -1 , yPos - 1),
        (xPos -1 , yPos),
        (xPos -1 , yPos + 1),
    ];
    public string Name { get; set; } = name;

    public Ball BallInPlay { get; set; } = ball;

    public IColor RacketColor { get; set; } = color;

    public IIterator<AbstractAbility> AbilityIterator { get; set; } = abilityInventory.CreateIterator();

    public bool AbilityIsActive { get; set; } = false;

    public int Cooldown { get; set; } = 0;

    public int Score { get; set; } = 0;

    public void RacketAction(string action)
    {
        if (action == "Up")
        {
            ChangeCoordinates(Coordinates.Select(c => (c.Item1, c.Item2 - 1)).ToList());
        }
        if (action == "Down")
        {
            ChangeCoordinates(Coordinates.Select(c => (c.Item1, c.Item2 + 1)).ToList());
        }
        if (action == "Ability" && Cooldown == 0)
        {
            AbilityIsActive = !AbilityIsActive;
        }
        if (action == "SwitchAbility" && !AbilityIsActive)
        {
            AbilityIterator.MoveNext(1);
        }
    }

    public async Task ReduceCooldown()
    {
        while (Cooldown > 0)
        {
            Cooldown -= 1;

            await Task.Delay(1000);
        }
    }

    public void ChangeCoordinates(List<(int, int)> newCoordinates)
    {
        Coordinates = newCoordinates;
    }

    public void CoordinateReset()
    {
        Coordinates = [
        (xPos, yPos - 1),
        (xPos, yPos),
        (xPos, yPos + 1),
        (xPos -1 , yPos - 1),
        (xPos -1 , yPos),
        (xPos -1 , yPos + 1),
    ];
    }

    public void ResetPlayer()
    {
        Cooldown = 0;
        Score = 0;
        CoordinateReset();
    }

    public List<(int, int)> ReturnCoordinates()
    {
        return Coordinates;
    }

    public void UseAbility()
    {
        AbilityIterator.Current.UseAbility();
        AbilityIsActive = false;
        Cooldown = 12;
    }
}