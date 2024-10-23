public interface IRacketBuilder 
{
    void MoveRacket(Ball ball);

    int getXPosition();

    int getYPosition();

    void addPoint();

    int currentPoint();

    /* void useAbility(); */
}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;
    private bool isFirstPlayer;

    public humanRacketBuilder(int xPos, int yPos, bool isFirstPlayer) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.isFirstPlayer = isFirstPlayer;
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

    IMoveRacket moves;

    private int Points = 0;


    public computerRacketBuilder(int xPos, int yPos, Ball ball, IMoveRacket move) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.moves = move;
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
       this.xPosition = moves.move(xPosition, ball);
    }
        
        

}