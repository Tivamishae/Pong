public interface IRacketBuilder 
{
    void MoveRacket();

    void setPosition(int x, int y);

    void racketLength(int length);

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
    public void setPosition(int x, int y) 
    {
        this.xPosition = x;
        this.yPosition = y;
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