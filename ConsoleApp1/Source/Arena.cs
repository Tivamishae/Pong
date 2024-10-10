using System;
using Boll;
using Racket;


namespace Arena {
    public class Arena
{
    Boll.Boll boll = new Boll.Boll(10, 10);
    Racket.Racket racket1 = new Racket.Racket(10, 4);
    Racket.Racket racket2 = new Racket.Racket(10, 76);

    public bool game = true;

    public void createArena() {
        int rows = 20; // Number of rows
        int columns = 80; // Number of columns
        char[,] grid = new char[rows, columns];

                for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                grid[row, col] = '+'; // Assign a "+" to each coordinate
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            if (row == 0 || row == 19) {
                Console.Write("_");
            }
            else if ( row == boll.bollX && col == boll.bollY) {
                Console.Write("O");
            }
            else if ( row == racket1.racketX-1 && col == racket1.racketY) {
                Console.Write("I");
            }
            else if ( row == racket1.racketX && col == racket1.racketY) {
                Console.Write("I");
            }
            else if ( row == racket1.racketX+1 && col == racket1.racketY) {
                Console.Write("I");
            }
            else if ( row == racket2.racketX-1 && col == racket2.racketY) {
                Console.Write("I");
            }
            else if ( row == racket2.racketX && col == racket2.racketY) {
                Console.Write("I");
            }
            else if ( row == racket2.racketX+1 && col == racket2.racketY) {
                Console.Write("I");
            }
            else
            {
                if (row > 0 && (col == 0 || col == 79)) {
                Console.Write("|");
            }
            else
                Console.Write(" ");
            }
            Console.WriteLine(); // Move to the next line after completing a row
        }
    }
    public void updateBoll()
{
    // Check for collision with the top or bottom boundaries
    if (boll.bollX >= 19 || boll.bollX <= 0)
    {
        boll.directionX = -boll.directionX;
    }
    // Check for collision with the racket
    else if (boll.bollY == racket1.racketY &&
             (boll.bollX >= racket1.racketX - 1 && boll.bollX <= racket1.racketX + 1))
    {
        boll.directionY = -boll.directionY;
    }
    // Check for collision with the left or right boundaries
    else if (boll.bollY >= 79 || boll.bollY <= 0)
    {
        boll.directionY = -boll.directionY;
    }

    // Move the ball according to its direction
    boll.move();
}
    public void updateRacket1(int direction) {
            if (racket1.racketX < 17 && direction == 1) {
                racket1.racketX = racket1.racketX + direction;
            } else if (racket1.racketX > 2 && direction == -1) {
                racket1.racketX = racket1.racketX + direction;
            }
    }
    public void updateRacket2(int direction) {
            if (racket2.racketX < 17 && direction == 1) {
                racket2.racketX = racket2.racketX + direction;
            } else if (racket2.racketX > 2 && direction == -1) {
                racket2.racketX = racket2.racketX + direction;
            }
    }
 }
}