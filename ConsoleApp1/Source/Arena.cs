using System;


namespace Arena {
    public class Arena
{
    public void createArena() {
        int ballX = 15;
        int ballY = 57;
        int[,] ball = new int[ballX, ballY];
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
            else if (row == ballX && col == ballY) {
                Console.Write("O");
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
}
}