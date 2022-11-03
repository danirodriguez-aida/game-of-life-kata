namespace GameOfLifeApp;

public class GameOfLife {
    private readonly Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration() {
        ProcessCell(Position.In(1, 1));
        ProcessCell(Position.In(2, 2));
        ProcessCell(Position.In(0, 2));
    }

    private void ProcessCell(Position position)
    {
        var neighbors = board.GetNeighbors(position);
        var aliveNeighbors = neighbors.Count(n => n.IsAlive());
        if (aliveNeighbors < 2) board.SetCellToDead(position);
    }

    public bool IsCellAlive(Position position) {
        return board.IsCellAlive(position);
    }
}