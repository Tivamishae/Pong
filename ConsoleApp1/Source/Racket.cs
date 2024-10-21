public interface IRacketBuilder 
{
    void MoveRacket();

    void racketLength(int length);

    int getXPosition();

    int getYPosition();

}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;
    private bool isFirstPlayer;
    private int lengthInput;

    public humanRacketBuilder(int xPos, int yPos, int length, bool isFirstPlayer) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.lengthInput = length;
        this.isFirstPlayer = isFirstPlayer;
    }

    public void racketLength(int length)
    {
        this.lengthInput = length;
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
                        this.yPosition = yPosition - 1;
                        break;
                    case ConsoleKey.S:
                        this.yPosition = yPosition + 1;
                        break;
                    }
                }
                else {
                    switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        this.yPosition = yPosition - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.yPosition = yPosition + 1;
                        break;
                    }
                }
            }
        }

}