
using System.Security.Cryptography.X509Certificates;
using System.Threading;
public class Game 
{
public bool game = true;

public static void createGame(Ball ball, IRacketBuilder racket1, IRacketBuilder racket2, Arena arena) {
    while (true) 
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.SetCursorPosition(0,0);


        racket1.MoveRacket();
        racket2.MoveRacket();

        

        if (racketCollision(ball, racket1) == true || racketCollision(ball, racket2) == true)
        {
            ball.changeDirection();
        }

        ball.move();

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

                    
                    case int _ when row == ball.ballX && col == ball.ballY:
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
    return col == racket.getYPosition() && (row == racket.getXPosition() - 1 || row == racket.getXPosition() || row == racket.getXPosition() + 1);
}

public static bool racketCollision(Ball ball, IRacketBuilder racket)
{
    if (ball.getballYPosition() == racket.getYPosition() && (ball.getballXPosition() == racket.getXPosition() || ball.getballXPosition() == racket.getXPosition() - 1 || ball.getballXPosition() == racket.getXPosition() + 1)){
        return true;
    }
    else 
    { 
        return false;
    }
}



}