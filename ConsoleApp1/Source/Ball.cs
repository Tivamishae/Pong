public class Ball(IBallShape ballShape) : ICoordinates
{
    public List<(int, int)> Coordinates { get; set; } = [(6, 10)];

    public int XDirection { get; set; } = 0;
    public int YDirection { get; set; } = 0;

    public bool Serve { get; set; } = true;
    public IBallShape BallShapeAndColor { get; set; } = ballShape;

    public List<(int, int)> ReturnCoordinates()
    {
        return Coordinates;
    }

    public string ReturnBallSymbol()
    {
        return BallShapeAndColor.ReturnShape().Item2;
    }

    public ConsoleColor ReturnBallColor()
    {
        return BallShapeAndColor.ReturnShape().Item1;
    }

    public void StopBallMovement()
    {
        XDirection = 0;
        YDirection = 0;
        Serve = true;
    }

    public void ServeBall(int directionY)
    {
        YDirection = directionY;
        if (Coordinates[0].Item1 < 10)
        {
            XDirection = -1;
        }
        else
        {
            XDirection = 1;
        }
        Serve = false;
    }


    public void MoveBall()
    {
        int newCoordinateX = Coordinates[0].Item1 + XDirection;
        int newCoordinateY = Coordinates[0].Item2 + YDirection;
        Coordinates = [(newCoordinateX, newCoordinateY)];
    }

    public void ResetMovement()
    {
        XDirection = Math.Sign(XDirection);
        YDirection = Math.Sign(YDirection);
    }
}