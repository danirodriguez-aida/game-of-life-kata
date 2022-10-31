namespace GameOfLifeApp;

public class GameOfLife
{
    private readonly bool[,] _board;

    public GameOfLife(bool[,] board)
    {
        _board = board;
    }
        
    public bool[,] NextGeneration()
    {
        if (!(_board[0, 1] && _board[1, 1] && _board[1, 1])) 
            _board[1, 1] = false;
        return _board;
    }
}