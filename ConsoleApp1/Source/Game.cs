using System.Security.Cryptography.X509Certificates;
using System.Threading;
public class Game 
{
public bool game = true;

public static void createGame(Ball ball, IRacketBuilder racket1, IRacketBuilder racket2, Arena arena) {
    while (true) 
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,0);
        Console.Clear();
        
        if (ball.directionX < 0){
        racket1.RacketAction(ball);
        }
        else {
        racket2.RacketAction(ball);
        }

        if (wallCollision(ball) == true)
        {
            ball.changeYDirection(-1, true);
        }

        if (racketCollision(ball, racket1) == true) {
            ball.changeYDirection(1, false);
            ball.changeXDirection();
            if (racket1.CheckIfAbilityActive() == true) {
                racket1.UseAbility();
            }
        }

        if (racketCollision(ball, racket2) == true) {
            ball.changeYDirection(1, false);
            ball.changeXDirection();
            if (racket2.CheckIfAbilityActive() == true) {
                racket2.UseAbility();
            }

        }
        
    
        ball.move();

        UI.Score(racket1, racket2, ball);
        UI.Scoreboard(racket1, racket2);

        createArena(ball, racket1, racket2, arena);
        
        Thread.Sleep(100);
    }

}

public static void createArena(Ball ball, IRacketBuilder racket1, IRacketBuilder racket2, Arena arena)
    {
        for (int row = 0; row < arena.rows; row++)
        {
            for (int col = 0; col < arena.columns; col++)
            {
                switch (row)
                {
                   
                    case 0:
                    case 19:
                        Console.Write("_");
                        break;

                    
                    case int _ when row == ball.ballY && col == ball.ballX:
                        Console.Write("O");
                        break;

                    // Skriv en funktion racketCollision() som kollar om ballX = RacketX
                    case int _ when IsRacketPosition(row, col, racket1) || IsRacketPosition(row, col, racket2):
                        Console.Write("I");
                        break;

                    
                    case int _ when col == 0 || col == 79:
                        Console.Write("|");
                        break;

                    default:
                        Console.Write(" ");
                        break;
                }
            }
            Console.WriteLine(); 
        }

    }


public static bool IsRacketPosition(int row, int col, IRacketBuilder racket)
{
    return col == racket.getXPosition() && (row == racket.getYPosition() - 1 || row == racket.getYPosition() || row == racket.getYPosition() + 1);
}

public static bool racketCollision(Ball ball, IRacketBuilder racket)
{
    if (ball.getBallYPosition() == racket.getYPosition() && (ball.getBallXPosition() == racket.getXPosition() || ball.getBallXPosition() == racket.getXPosition() - 1 || ball.getBallXPosition() == racket.getXPosition() + 1)){
        return true;
    }
    else 
    { 
        return false;
    }
}

public static bool wallCollision(Ball ball)
{
    if (ball.ballY < 1 && ball.directionY < 0 || ball.ballY > 19 && ball.directionY > 0)
    {
        return true;
    }
    else 
    {
        return false;
    }
}



}