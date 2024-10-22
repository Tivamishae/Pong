public class UI {

    public static void Score(IRacketBuilder racket1, IRacketBuilder racket2, Ball ball)
    {
        if (ball.getballYPosition() > 80){
            racket1.addPoint();
            ball.resetBall(ball);
        }
        else if (ball.getballYPosition() < 0){
            racket2.addPoint();
            ball.resetBall(ball);
        }
    }

    public static void Scoreboard(IRacketBuilder racket1, IRacketBuilder racket2)
    {
        Console.Write(racket1.currentPoint());
        for (int i = 0; i < 78; i++)
        {
            Console.Write(" ");
        }
        Console.Write(racket2.currentPoint());
        Console.WriteLine();
    }

}