namespace GameOfLifeApp;

public class Board
{
    private readonly bool[,] _cells;

    public Board(int numberOfRows, int numberOfColumns)
    {
        _cells = new bool[numberOfRows, numberOfColumns];
    }

    public bool SetCellToDead(int row, int column)
    {
        return _cells[row, column] = false;
    }

    public bool SetCellToLive(int row, int column)
    {
        return _cells[row, column] = true;
    }

    public bool GetCellStatus(int row, int column)
    {
        return _cells[row, column];
    }
}