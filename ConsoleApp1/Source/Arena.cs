using System;
using Boll;


namespace Arena {
    public class Arena
{
   Ball ball = new Ball(10, 10);
    humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, 3);
    humanRacketBuilder racket2 = new humanRacketBuilder(10, 79, 3);

    public bool game = true;

    public void createArena(Ball ball, humanRacketBuilder racket1, humanRacketBuilder racket2)
    {
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
            {
                switch (row)
                {
                    // Top and bottom boundaries
                    case 0:
                    case 19:
                        Console.Write("_");
                        break;

                    // Check if ball's position matches
                    case int _ when row == ball.ballX && col == ball.ballY:
                        Console.Write("O");
                        break;

                    // Racket positions (delegated to a separate function)
                    case int _ when IsRacketPosition(row, col, racket1) || IsRacketPosition(row, col, racket2):
                        Console.Write("I");
                        break;

                    // Left and right borders
                    case int _ when row > 0 && (col == 0 || col == 79):
                        Console.Write("|");
                        break;

                    // Default empty space
                    default:
                        Console.Write(" ");
                        break;
                }
            }
            Console.WriteLine(); // Move to the next line after completing a row
        }
    }

// Separate function to check if the current (row, col) is part of a racket
public bool IsRacketPosition(int row, int col, humanRacketBuilder racket)
{
    return col == racket1.yPos && (row == racket1.racketX - 1 || row == racket.racketX || row == racket.racketX + 1);
}

// Racket class to represent rackets
public class Racket
{
    public int racketX { get; set; }
    public int racketY { get; set; }

    public Racket(int x, int y)
    {
        racketX = x;
        racketY = y;
    }
}



}
}