using System;
using System.Data;


public class Arena
{
    public int rows; // Number of rows
    public int columns; // Number of columns
    
    char[,] grid = [rows, columns]

    public Arena(int row, int col)
    {
        this.rows = row;
        this.columns = col;
    }


}