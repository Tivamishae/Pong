public class AbilityInventory(Ball ball) : IIterable<AbstractAbility>
{
    public AbstractAbility Smash = new Smash(ball);
    public AbstractAbility Screw = new Screw(ball);

    public IIterator<AbstractAbility> CreateIterator()
    => new AbilityIterator(this);
}
public class AbilityIterator : IIterator<AbstractAbility>
{
    private AbilityInventory Player;
    private int CurrentIndex = 0;
    public AbilityIterator(AbilityInventory player)
    {
        this.Player = player;
    }

    public AbstractAbility Current
    {
        get => CurrentIndex switch
        {
            0 => Player.Smash,
            _ => Player.Screw,
        };
    }

    public bool MoveNext(int direction)
    {
        if (CurrentIndex < 1)
        {
            CurrentIndex += direction;
            return true;
        }
        else
        {
            Reset();
            return false;
        }
    }

    public void Reset()
    => CurrentIndex = 0;
}