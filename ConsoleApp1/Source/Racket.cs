interface IRacketBuilder 
{
    void Move();

    void BuildRacket();

    int currentPostion();

    int racketLength();

}

class humanRacketBuilder : IRacketBuilder
{
    private int position;
    private int racketLength;

    public humanRacketBuilder(int startPosition, int length) 
    {
        this.position = startPosition;
        this.racketLength = length;
    }

    public void BuildRacket()
    {
        for (int i=0; i < racketLength; i++)
        {
            

        }
    }

    public void Move()
        {
            
        }

}