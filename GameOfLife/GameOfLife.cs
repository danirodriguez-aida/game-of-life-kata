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

public class GameOfLife
{
    private readonly Board _board;

    public GameOfLife(Board board)
    {
        _board = board;
    }
        
    public void NextGeneration()
    {
        if (!(_board.GetCellStatus(0, 1) && _board.GetCellStatus(1,1) && _board.GetCellStatus(2,1))) _board.SetCellToDead(1, 1);
    }

    public bool GetCellStatus(int row, int column)
    {
        return _board.GetCellStatus(row, column);
    }
}