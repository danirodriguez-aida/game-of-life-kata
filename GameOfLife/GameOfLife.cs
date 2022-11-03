namespace GameOfLifeApp;

public class GameOfLife {
    private readonly Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration() {
        var neighbors11 = board.GetNeighbors(Position.In(1, 1));
        var aliveNeighbors11 = neighbors11.Count(n => n.IsAlive());
        if (aliveNeighbors11 < 2) board.SetCellToDead(Position.In(1, 1));

        var neighborsFor22 = board.GetNeighbors(Position.In(2, 2));
        var aliveNeighbors22 = neighborsFor22.Count(n => n.IsAlive());
        if (aliveNeighbors22 < 2) board.SetCellToDead(Position.In(2, 2));

        var neighborsFor02 = board.GetNeighbors(Position.In(0, 2));
        var aliveNeighbors02 = neighborsFor02.Count(n => n.IsAlive());
        if (aliveNeighbors02 < 2) board.SetCellToDead(Position.In(0, 2));
    }

    public bool IsCellAlive(Position position) {
        return board.IsCellAlive(position);
    }
}