namespace GameOfLifeApp;

public class GameOfLife {
    private Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration()
    {
        board = board.GetNextBoard();
    }

    public bool IsCellAlive(Position position) {
        return board.IsCellAlive(position);
    }
}