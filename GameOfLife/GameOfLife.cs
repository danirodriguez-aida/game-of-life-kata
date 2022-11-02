namespace GameOfLifeApp;

public class GameOfLife
{
    private readonly Board board;

    public GameOfLife(Board board)
    {
        this.board = board;
    }
        
    public void NextGeneration()
    {
        var neighbors = board.GetNeighbors(Position.In(1, 1));
        var aliveNeighbors =  neighbors.Count(n => n.IsAlive());
        if (aliveNeighbors < 2 )   board.SetCellToDead(Position.In(1, 1));
    }

    public bool IsCellAlive(Position position)
    {
        return board.IsCellAlive(position);
    }

}