public interface IRacketBuilder 
{
    void MoveRacket(Ball ball);

    int getXPosition();

    int getYPosition();

    void addPoint();

    int currentPoint();
}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;
    private bool isFirstPlayer;

    private IAbility ability;

    public humanRacketBuilder(int xPos, int yPos, bool isFirstPlayer, IAbility ability) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.isFirstPlayer = isFirstPlayer;
        this.ability = ability;
    }

    public void UseAbility() {
        if (Console.KeyAvailable) {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (isFirstPlayer && keyInfo.Key == ConsoleKey.F) {
                ability.Use();
            }
            else if (!isFirstPlayer && keyInfo.Key == ConsoleKey.L) {
                ability.Use();
            }
        }
    }

    public void addPoint(){
        this.Points++;
    }

    public int currentPoint()
    {
        return Points;
    }

    public int getXPosition()
    {
        return xPosition;
    }

    public int getYPosition()
    {
        return yPosition;
    }

    public void MoveRacket(Ball ball = null)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (isFirstPlayer) {
                    switch (keyInfo.Key) {
                    case ConsoleKey.W:
                        this.xPosition = xPosition - 1;
                        break;
                    case ConsoleKey.S:
                        this.xPosition = xPosition + 1;
                        break;
                    }
                }
                else {
                    switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        this.xPosition = xPosition - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.xPosition = xPosition + 1;
                        break;
                    }
                }
            }
        }

}

public class computerRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;

    private int currentBallY;

    public computerRacketBuilder(int xPos, int yPos, Ball ball) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.currentBallY = ball.getballYPosition();
    }


    public void addPoint(){
        this.Points++;
    }

    public int currentPoint()
    {
        return Points;
    }

    public int getXPosition()
    {
        return xPosition;
    }

    public int getYPosition()
    {
        return yPosition;
    }

    public void MoveRacket(Ball ball)
        {
            if (xPosition < ball.getballXPosition()) {
                this.xPosition = xPosition + 1;
            }
            else if (xPosition > ball.getballXPosition()) {
                this.xPosition = xPosition - 1;
            }
        }

}