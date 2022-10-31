namespace GameOfLifeApp;

public class Board
{
    private readonly bool[,] _cells;

    public bool[,] GetCells() => _cells;

    public Board(bool[,] board)
    {
        _cells = board;
    }
    
}

public class GameOfLife
{
    private readonly Board _board;

    public GameOfLife(Board board)
    {
        _board = board;
    }
        
    public bool[,] NextGeneration()
    {
        if (!(_board.GetCells()[0, 1] && _board.GetCells()[1, 1] && _board.GetCells()[1, 1])) _board.GetCells()[1, 1] = false;
        return _board.GetCells();
    }
}