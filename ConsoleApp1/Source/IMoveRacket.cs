public interface IMoveRacket
{
    int move(int yPostion, Ball ball);
}

public class ImpossibleMove : IMoveRacket
{
    public int move(int yPosition, Ball ball)
    {
        if (yPosition < ball.getBallYPosition())
        {
            return yPosition + 1;
        }
        else if (yPosition > ball.getBallYPosition())
        {
            return yPosition - 1;
        }
        else
        {
            return yPosition;
        }
    }
}

public class WackyMove : IMoveRacket
{
    public int move(int yPosition, Ball ball)
    {
        if (yPosition < ball.getBallYPosition())
        {
            return yPosition + 5;
        }
        else if (yPosition > ball.getBallYPosition())
        {
            return yPosition - 2;
        }
        else
        {
            return yPosition;
        }
    }
}

public class SlowMove : IMoveRacket
{

    public int move(int yPosition, Ball ball)
    {
        if (yPosition < ball.getBallYPosition() - 1)
        {
            return yPosition + 1;
        }
        else if (yPosition > ball.getBallYPosition() + 1)
        {
            return yPosition - 1;
        }
        else
        {
            return yPosition;
        }
    }
}