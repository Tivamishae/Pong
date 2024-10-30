using System.Drawing;

public interface IBallColour
{
    public ConsoleColor setColour();
}

public class RedColour : IBallColour
{
    public ConsoleColor setColour()
    {
        return ConsoleColor.Red;
    }
}

public class GreenColour : IBallColour
{
    public ConsoleColor setColour()
    {
        return ConsoleColor.Green;
    }
}

public class BlueColour : IBallColour
{
    public ConsoleColor setColour()
    {
        return ConsoleColor.Blue;
    }
}

public interface IBallShape
{
    public (ConsoleColor, string) returnShape();
}

public class Star : IBallShape
{

    private IBallColour ballColour;

    public Star(IBallColour colour)
    {
        this.ballColour = colour;
    }
    public (ConsoleColor, string) returnShape()
    {
        return (ballColour.setColour(), "*");
    }
}

public class Circle : IBallShape
{
    private IBallColour ballColour;

    public Circle(IBallColour colour)
    {
        this.ballColour = colour;
    }
    public (ConsoleColor, string) returnShape()
    {
        return (ballColour.setColour(), "O");

    }
}

public class Plus : IBallShape
{
    private IBallColour ballColour;

    public Plus(IBallColour colour)
    {
        this.ballColour = colour;
    }
    public (ConsoleColor, string) returnShape()
    {
        return (ballColour.setColour(), "+");

    }
}