namespace GameOfLifeApp;

public class GameOfLife {
    private Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration() {
        var auxBoard = board.CreateBoardWithSameSize();
        foreach (var cell in board.Cells) {
            var position = cell.Position;
            var statusForCell = GetStatusForCell(position);
            if (statusForCell == CellStatus.Alive) {
                auxBoard.SetCellToLive(position);
            }
            else {
                auxBoard.SetCellToDead(position);
            }
        }
        board = auxBoard;
    }

    private CellStatus GetStatusForCell(Position position) {
        var neighbors = board.GetNeighbors(position);
        var aliveNeighbors = neighbors.Count(n => n.IsAlive());
        if (board.IsCellAlive(position))
        {
            return aliveNeighbors switch
            {
                2 => CellStatus.Alive,
                3 => CellStatus.Alive,
                _ => CellStatus.Dead
            };
        }
        return aliveNeighbors switch {
            3 => CellStatus.Alive,
            _ => CellStatus.Dead
        };
    }

    public bool IsCellAlive(Position position) {
        return board.IsCellAlive(position);
    }
}