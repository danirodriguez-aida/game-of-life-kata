namespace GameOfLifeApp;

public class Board
{
    private readonly int numberOfRows;
    private readonly int numberOfColumns;
    private readonly List<Cell> cells = new();

    public Board(int numberOfRows, int numberOfColumns)
    {
        this.numberOfRows = numberOfRows;
        this.numberOfColumns = numberOfColumns;
        InitializeBoard();
    }
    
    private void InitializeBoard()
    {
        for (var i = 0; i < numberOfRows; i++)
        {
            for (var j = 0; j < numberOfColumns; j++)
            {
                cells.Add(new Cell(Position.In(i, j)));
            }
        }
    }

    public Board GetNextBoard(GameOfLife gameOfLife)
    {
        var auxBoard = CreateBoardWithSameSize();
        foreach (var cell in cells)
        {
            var position = cell.Position;
            var statusForCell = GetStatusForCell(position);
            if (statusForCell == CellStatus.Alive)
            {
                auxBoard.SetCellToLive(position);
            }
            else
            {
                auxBoard.SetCellToDead(position);
            }
        }
        return auxBoard;
    }
   
    public void SetCellToDead(Position position)
    {
        GetCellBy(position).SetToDead();
    }

    public void SetCellToLive(Position position)
    {
        GetCellBy(position).SetToLive();
    }

    public bool IsCellAlive(Position position)
    {
        return GetCellBy(position).IsAlive();
    }

    private IEnumerable<Cell> GetNeighbors(Position position)
    {
        var neighbors = new List<Cell>();
        var positionUpLeft = Position.In(position.Row - 1, position.Column - 1);

        if (IsPosition(positionUpLeft)) neighbors.Add(GetCellBy(positionUpLeft));
        var positionUpCenter = Position.In(position.Row - 1, position.Column);
        if (IsPosition(positionUpCenter)) neighbors.Add(GetCellBy(positionUpCenter));
        var positionUpRight = Position.In(position.Row - 1, position.Column +1);
        if (IsPosition(positionUpRight)) neighbors.Add(GetCellBy(positionUpRight));
        var positionCenterLeft = Position.In(position.Row, position.Column -1);
        if (IsPosition(positionCenterLeft)) neighbors.Add(GetCellBy(positionCenterLeft));
        var positionCenterRight = Position.In(position.Row, position.Column +1);
        if (IsPosition(positionCenterRight)) neighbors.Add(GetCellBy(positionCenterRight));
        var positionDownLeft = Position.In(position.Row + 1, position.Column - 1);
        if (IsPosition(positionDownLeft)) neighbors.Add(GetCellBy(positionDownLeft));
        var positionDownCenter = Position.In(position.Row + 1, position.Column);
        if (IsPosition(positionDownCenter)) neighbors.Add(GetCellBy(positionDownCenter));
        var positionDownRight = Position.In(position.Row + 1, position.Column + 1 );
        if (IsPosition(positionDownRight)) neighbors.Add(GetCellBy(positionDownRight));
        return neighbors;
    }

    private Board CreateBoardWithSameSize()
    {
        return new Board(numberOfRows,numberOfColumns);
    }

    private Cell GetCellBy(Position position)
    {
        return cells.Single(c => c.Position.Equals(position));
    }

    private bool IsPosition(Position position)
    {
        return cells.SingleOrDefault(c => c.Position.Equals(position)) != null;
    }

    private CellStatus GetStatusForCell(Position position) {
        var neighbors = GetNeighbors(position);
        var aliveNeighbors = neighbors.Count(n => n.IsAlive());
        if (IsCellAlive(position))
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
}