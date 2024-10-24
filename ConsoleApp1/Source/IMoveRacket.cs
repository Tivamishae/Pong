public interface IMoveRacket
{
    int move(int xPosition, Ball ball);
}

public class ImpossibleMove : IMoveRacket
{
    public int move(int xPosition, Ball ball)
    {
        if (xPosition < ball.getBallXPosition())
        {
            return xPosition + 1;
        }
        else if (xPosition > ball.getBallXPosition())
        {
            return xPosition - 1;
        }
        else
        {
            return xPosition;
        }
    }
}

public class WackyMove : IMoveRacket
{
    public int move(int xPosition, Ball ball)
    {
        if (xPosition < ball.getBallXPosition())
        {
            return xPosition + 5;
        }
        else if (xPosition > ball.getBallXPosition())
        {
            return xPosition - 2;
        }
        else
        {
            return xPosition;
        }
    }
}

public class SlowMove : IMoveRacket
{
    public int move(int xPosition, Ball ball)
    {
        if (xPosition < ball.getBallXPosition() - 1)
        {
            return xPosition + 1;
        }
        else if (xPosition > ball.getBallXPosition() + 1)
        {
            return xPosition - 1;
        }
        else
        {
            return xPosition;
        }
    }
}