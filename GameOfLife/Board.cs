namespace GameOfLifeApp;

public class Board
{
    private readonly int numberOfRows;
    private readonly int numberOfColumns;
    private readonly CellCollection cells;

    public Board(int numberOfRows, int numberOfColumns)
    {
        this.numberOfRows = numberOfRows;
        this.numberOfColumns = numberOfColumns;
        cells = new CellCollection();
        InitializeBoard();
    }
    

    public Board GetNextBoard()
    {
        var auxBoard = CreateBoardWithSameSize();
        foreach (var cell in cells.GetCells())
        {
            var position = cell.Position;
            var nextStatusForCell = GetNextStatusForCell(position);
            auxBoard.SetStatusCellInPosition(nextStatusForCell, position);
        }
        return auxBoard;
    }

    // No se si debería estar en CellCollection
    public void SetStatusCellInPosition(CellStatus newCellStatus, Position position)
    {
        cells.GetCellBy(position).SetTo(newCellStatus);
    }

    // No se si debería estar en CellCollection
    public bool IsCellAlive(Position position)
    {
        return cells.GetCellBy(position).IsAlive();
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

    private IEnumerable<Cell> GetNeighbors(Position position)
    {
        var neighbors = new List<Cell>();
        var positionUpLeft = Position.In(position.Row - 1, position.Column - 1);
        var positionUpCenter = Position.In(position.Row - 1, position.Column);
        var positionUpRight = Position.In(position.Row - 1, position.Column +1);
        var positionCenterLeft = Position.In(position.Row, position.Column -1);
        var positionCenterRight = Position.In(position.Row, position.Column +1);
        var positionDownLeft = Position.In(position.Row + 1, position.Column - 1);
        var positionDownCenter = Position.In(position.Row + 1, position.Column);
        var positionDownRight = Position.In(position.Row + 1, position.Column + 1 );
        if (cells.ExistsCellIn(positionUpLeft)) neighbors.Add(cells.GetCellBy(positionUpLeft));
        if (cells.ExistsCellIn(positionUpCenter)) neighbors.Add(cells.GetCellBy(positionUpCenter));
        if (cells.ExistsCellIn(positionUpRight)) neighbors.Add(cells.GetCellBy(positionUpRight));
        if (cells.ExistsCellIn(positionCenterLeft)) neighbors.Add(cells.GetCellBy(positionCenterLeft));
        if (cells.ExistsCellIn(positionCenterRight)) neighbors.Add(cells.GetCellBy(positionCenterRight));
        if (cells.ExistsCellIn(positionDownLeft)) neighbors.Add(cells.GetCellBy(positionDownLeft));
        if (cells.ExistsCellIn(positionDownCenter)) neighbors.Add(cells.GetCellBy(positionDownCenter));
        if (cells.ExistsCellIn(positionDownRight)) neighbors.Add(cells.GetCellBy(positionDownRight));
        return neighbors;
    }

    private Board CreateBoardWithSameSize()
    {
        return new Board(numberOfRows,numberOfColumns);
    }

    private CellStatus GetNextStatusForCell(Position position) {
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