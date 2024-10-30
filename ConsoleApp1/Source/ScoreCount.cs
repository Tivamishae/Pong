public class ScoreCount 
{
    public static bool checkWinner(IRacketBuilder racket)
    {
        if (racket.currentPoint() == 5) 
        {
            return true;
        }
        else return false;
    }
}