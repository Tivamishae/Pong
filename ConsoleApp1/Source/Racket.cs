interface IRacketBuilder 
{
    void MoveRacket();

    int currentPostion();

    int racketLength();

}

class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;
    private int racketLength;

    public humanRacketBuilder(int xPos, int yPos, int length) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.racketLength = length;
    }

    public void MoveRacket()
        {
            
        }

}