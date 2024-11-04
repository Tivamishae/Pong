public interface MenuSelection<T>
{
    public List<(T, string)> Selections { get; set; }
}

public class SelectionsAmountOfRounds : IIterable<(int, string)>, MenuSelection<int>
{
    public List<(int, string)> Selections { get; set; } = new List<(int, string)>
    {
        (1, "One      (1)"),
        (3, "Three    (3)"),
        (5, "Five     (5)"),
        (10, "Ten      (10)"),
        (15, "Fifteen  (15)"),
        (20, "Twenty   (20)"),
    };

    public IIterator<(int, string)> CreateIterator()
    {
        return new MenuIterator<int>(this);
    }
}

public class SelectionsPlayAgain : IIterable<(bool, string)>, MenuSelection<bool>
{
    public List<(bool, string)> Selections { get; set; } = new List<(bool, string)>
    {
        (true, "Yes"),
        (false, "No"),
    };

    public IIterator<(bool, string)> CreateIterator()
    {
        return new MenuIterator<bool>(this);
    }
}

public class SelectionsColor : IIterable<(IColor, string)>, MenuSelection<IColor>
{
    public List<(IColor, string)> Selections { get; set; } = new List<(IColor, string)>
    {
        (new RedColor(), "Red"),
        (new BlueColor(), "Blue"),
        (new GreenColor(), "Green"),
        (new WhiteColor(), "White"),
        (new MagentaColor(), "Magenta"),
        (new YellowColor(), "Yellow")
    };

    public IIterator<(IColor, string)> CreateIterator()
    {
        return new MenuIterator<IColor>(this);
    }
}

public class SelectionsBallShape(IColor ballColor) : IIterable<(IBallShape, string)>, MenuSelection<IBallShape>
{
    public List<(IBallShape, string)> Selections { get; set; } = new List<(IBallShape, string)>
    {
        (new Circle(ballColor), "Circle"),
        (new Star(ballColor), "Star"),
        (new Square(ballColor), "Square"),
        (new Plus(ballColor), "Plus"),
    };

    public IIterator<(IBallShape, string)> CreateIterator()
    {
        return new MenuIterator<IBallShape>(this);
    }
}

public class SelectionsEnemyType(IColor racketColor, string name, AbilityInventory abilityInventory, Ball ball) : IIterable<(IPlayer, string)>, MenuSelection<IPlayer>
{
    public List<(IPlayer, string)> Selections { get; set; } = new List<(IPlayer, string)>
    {

        (new HumanPlayer(75, 10, name, abilityInventory, racketColor), "Human"),
        (new ComputerPlayer(75, 10, name, abilityInventory, racketColor, ball), "Computer")
    };

    public IIterator<(IPlayer, string)> CreateIterator()
    {
        return new MenuIterator<IPlayer>(this);
    }
}
public class MenuIterator<T> : IIterator<(T, string)>
{
    private MenuSelection<T> MenuSelection;
    private int CurrentIndex = 0;

    public MenuIterator(MenuSelection<T> selections)
    {
        this.MenuSelection = selections;
    }

    public (T, string) Current
    {
        get => MenuSelection.Selections[CurrentIndex];
    }

    public bool MoveNext(int direction)
    {
        if (CurrentIndex == 0 && direction == -1)
        {
            Reset();
            return false;
        }
        else if (CurrentIndex == MenuSelection.Selections.Count - 1 && direction == 1)
        {
            Reset();
            return false;
        }
        else
        {
            CurrentIndex += direction;
            return true;
        }
    }

    public void Reset()
    {
        if (CurrentIndex == 0)
        {
            CurrentIndex = MenuSelection.Selections.Count - 1;
        }
        else
        {
            CurrentIndex = 0;
        }
    }
}