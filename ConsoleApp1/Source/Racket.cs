public interface IRacketBuilder 
{
    void MoveRacket();


    int getXPosition();

    int getYPosition();

}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;
    private bool isFirstPlayer;

    public humanRacketBuilder(int xPos, int yPos, bool isFirstPlayer) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.isFirstPlayer = isFirstPlayer;
    }


    public int getXPosition()
    {
        return xPosition;
    }

    public int getYPosition()
    {
        return yPosition;
    }

    public void MoveRacket()
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