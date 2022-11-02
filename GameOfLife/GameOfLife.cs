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
        if (!(GetCellStatus(Position.In(0,1)) && GetCellStatus(Position.In(1,1)) && GetCellStatus(Position.In(2,1)))) _board.SetCellToDead(Position.In(1, 1));
    }

    public bool GetCellStatus(Position position)
    {
        return _board.GetCellStatus(position);
    }
}