public class ScoreCount 
{
    public static bool checkWinner(IRacketBuilder racket)
    {
        if (racket.currentPoint() == 1) 
        {
            return true;
        }
        else return false;
    }
}