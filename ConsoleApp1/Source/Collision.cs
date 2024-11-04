public interface ICoordinates
{
    List<(int, int)> Coordinates { get; set; }
}

public class CollisionChecker<T> where T : ICoordinates
{
    private readonly T _object1;
    private readonly T _object2;

    public CollisionChecker(T obj1, T obj2)
    {
        _object1 = obj1;
        _object2 = obj2;
    }

    public bool CheckCollision()
    {
        var coordinates1 = _object1.Coordinates;
        var coordinates2 = _object2.Coordinates;

        //LINQS syntax Any
        return coordinates1.Any(coordinates2.Contains);
    }
}