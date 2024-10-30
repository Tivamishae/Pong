using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
public class Game
{
    public bool game = true;

    private Ball ball;
    private IRacketBuilder racket1;
    private IRacketBuilder racket2;
    private Arena arena;

    public Game(Ball ball, IRacketBuilder racket1, IRacketBuilder racket2, Arena arena)
    {
        this.ball = ball;
        this.racket1 = racket1;
        this.racket2 = racket2;
        this.arena = arena;
        bool game = true;


        while (game)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();

            if (ball.xBounces % 2 == 0)
            {
                racket2.RacketAction(ball);
            }
            else
            {
                racket1.RacketAction(ball);
            }

            if (wallCollision(ball) == true)
            {
                ball.changeYDirection(-1, true);
            }

            if (racketCollision(ball, racket1) == true)
            {
                ball.changeYDirection(1, false);
                ball.changeXDirection(1);
                if (racket1.CheckIfAbilityActive() == true)
                {
                    racket1.UseAbility();
                }
            }

            if (racketCollision(ball, racket2) == true)
            {
                ball.changeYDirection(1, false);
                ball.changeXDirection(1);
                if (racket2.CheckIfAbilityActive() == true)
                {
                    racket2.UseAbility();
                }

            }


            ball.move();
            racket1.HandleCooldownReduction();
            racket2.HandleCooldownReduction();

            Score(racket1, racket2, ball);
            UI.Names(racket1, racket2);
            UI.Scoreboard(racket1, racket2);
            UI.AbilityRecharge(racket1, racket2);

            createArena(ball, racket1, racket2, arena);
            
            if (ScoreCount.checkWinner(racket1))
            {
                Console.Clear();
                game = false;
                EndMenu menu = new EndMenu(racket1, arena);
            }
            if (ScoreCount.checkWinner(racket2))
            {
                Console.Clear();
                game = false;
                EndMenu menu = new EndMenu(racket2, arena);
            }


            Thread.Sleep(100);

            
        }

    }

    public static void Score(IRacketBuilder racket1, IRacketBuilder racket2, Ball ball)
    {

        if (ball.getBallXPosition() > 80)
        {
            racket1.addPoint();
            ball.resetBall(true);
            racket1.resetRacket();
            racket2.resetRacket();
        }

        else if (ball.getBallXPosition() < 0)
        {
            racket2.addPoint();
            ball.resetBall(false);
            racket1.resetRacket();
            racket2.resetRacket();
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
                        Console.ForegroundColor = ball.ballShape.returnShape().Item1;
                        Console.Write($"{ball.ballShape.returnShape().Item2}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                        

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
        if (ball.getBallYPosition() == racket.getYPosition() && (ball.getBallXPosition() == racket.getXPosition() || ball.getBallXPosition() == racket.getXPosition() - 1 || ball.getBallXPosition() == racket.getXPosition() + 1))
        {
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