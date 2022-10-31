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
        if (!(_board.GetCellStatus(Position.GetIn(0,1)) && _board.GetCellStatus(Position.GetIn(1,1)) && _board.GetCellStatus(Position.GetIn(2,1)))) _board.SetCellToDead(Position.GetIn(1, 1));
    }

    public bool GetCellStatus(Position position)
    {
        return _board.GetCellStatus(position);
    }
}