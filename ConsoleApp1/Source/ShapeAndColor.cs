public interface IColor
{
    public ConsoleColor SetColor();
}

//Bridge pattern
/* Vi har valt att skapa en interface IColor som implementeras av flera färgklasser och som har metoden SetColor som returnerar en konsolfärg.
Vi har därefter valt att skapa en interace IBallShape som har metoden ReturnShape som returnerar en string som ska representera bollen som implementeras av flera formklasser
Varje konkret klass av IBallShape injekterar en IColor via sin konstruktor och har därmed både en färg och en form.
*/
/* Vi har valt att göra så eftersom vi vid run-time dynamiskt kan välja färg via subtypspolymorfism istället för att behöva skapa
massa cases av hårdkodade kombinationer av färg och former.
*/

public class RedColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Red;
    }
}

public class BlueColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Blue;
    }
}

public class GreenColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Green;
    }
}

public class WhiteColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.White;
    }
}

public class MagentaColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Magenta;
    }
}

public class YellowColor : IColor
{
    public ConsoleColor SetColor()
    {
        return ConsoleColor.Yellow;
    }
}

public interface IBallShape
{
    public (ConsoleColor, string) ReturnShape();
}

public class Star(IColor ballcolor) : IBallShape
{
    private IColor BallColor { get; set; } = ballcolor;

    public (ConsoleColor, string) ReturnShape()
    {
        return (BallColor.SetColor(), "*");
    }
}

public class Circle(IColor ballcolor) : IBallShape
{
    private IColor BallColor { get; set; } = ballcolor;

    public (ConsoleColor, string) ReturnShape()
    {
        return (BallColor.SetColor(), "O");
    }
}

public class Plus(IColor ballcolor) : IBallShape
{
    private IColor BallColor { get; set; } = ballcolor;

    public (ConsoleColor, string) ReturnShape()
    {
        return (BallColor.SetColor(), "+");
    }
}

public class Square(IColor ballcolor) : IBallShape
{
    private IColor BallColor { get; set; } = ballcolor;

    public (ConsoleColor, string) ReturnShape()
    {
        return (BallColor.SetColor(), "▢");
    }
}