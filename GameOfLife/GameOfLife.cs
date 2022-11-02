namespace GameOfLifeApp;

public class GameOfLife
{
    private readonly Board _board;

    public GameOfLife(Board board)
    {
        _board = board;
    }
        
    public void NextGeneration()
    {
        if (!(IsCellAlive(Position.In(0,1)) && IsCellAlive(Position.In(1,1)) && IsCellAlive(Position.In(2,1)))) _board.SetCellToDead(Position.In(1, 1));
    }

    public bool IsCellAlive(Position position)
    {
        return _board.IsCellAlive(position);
    }
}