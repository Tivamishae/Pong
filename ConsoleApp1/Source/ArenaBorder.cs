public class ArenaBorder(List<(int, int)> coordinates, IColor borderColor) : ICoordinates
{
    public List<(int, int)> Coordinates { get; set; } = coordinates;

    public IColor BorderColor { get; set; } = borderColor;

    public List<(int, int)> ReturnArenaBorder()
    {
        return Coordinates;
    }

    public void AddToBorder((int, int) newValue)
    {
        Coordinates.Add(newValue);
    }
}