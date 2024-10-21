public class Game 
{
public static void createArena(Ball ball, IRacketBuilder racket1, IRacketBuilder racket2, Arena arena)
    {


        for (int row = 0; row < arena.rows; row++)
        {
            for (int col = 0; col < arena.columns; col++)
            {
                arena.grid[row, col] = ' '; 
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
public static bool IsRacketPosition(int row, int col, IRacketBuilder racket)
{
    return col == racket.getYPosition() && (row == racket.getXPosition() - 1 || row == racket.getXPosition() || row == racket.getXPosition() + 1);
}


}