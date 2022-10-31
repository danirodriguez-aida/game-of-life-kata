namespace GameOfLifeApp;

public class Board
{
    private readonly bool[,] _cells;

    public bool[,] GetCells() => _cells;

    public Board(bool[,] board)
    {
        _cells = board;
    }

    public bool KillCell(int row, int column)
    {
        return _cells[row, column] = false;
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
        if (!(_board.GetCellStatus(0, 1) && _board.GetCellStatus(1,1) && _board.GetCellStatus(2,1))) _board.KillCell(1, 1);
    }

    public bool GetCellStatus(int row, int column)
    {
        return _board.GetCellStatus(row, column);
    }
}