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
    private int lengthInput;

    public humanRacketBuilder(int xPos, int yPos, int length) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.lengthInput = length;
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
            
        }

}