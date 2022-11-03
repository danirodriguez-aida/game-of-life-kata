namespace GameOfLifeApp;

public class GameOfLife {
    private Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration()
    {
        var auxBoard = board.CreateBoardWithSameSize();
        foreach (var cell in board.Cells)
        {
            var position = cell.Position;
            var statusForCell = GetStatusForCell(position);
            if (statusForCell)
            {
                auxBoard.SetCellToLive(position);
            }
            else
            {
                auxBoard.SetCellToDead(position);
            }
        }
        board = auxBoard;
    }

    private bool GetStatusForCell(Position position)
    {
        var neighbors = board.GetNeighbors(position);
        var aliveNeighbors = neighbors.Count(n => n.IsAlive());
        if (aliveNeighbors < 2) return false;
        return true;
    }

    public bool IsCellAlive(Position position) {
        return board.IsCellAlive(position);
    }
}