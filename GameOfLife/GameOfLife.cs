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
        
    public void NextGeneration()
    {
        if (!(GetCell(0, 1) && GetCell(1,1) && GetCell(2,1))) 
            _board.GetCells()[1, 1] = false;
    }

    private bool GetCell(int row, int column)
    {
        return _board.GetCells()[row, column];
    }

    public Board GetBoard() => _board;
}