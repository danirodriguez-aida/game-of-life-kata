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
            InitializeRow(i);
        }
    }

    private void InitializeRow(int i)
    {
        for (var j = 0; j < numberOfColumns; j++)
        {
            cells.Add(new Cell(Position.In(i, j)));
        }
    }

    private IEnumerable<Cell> GetNeighbors(Position position)
    {
        var neighbors = new List<Cell>();
        var positionUpLeft = position.GetUpLeftPosition();
        var positionUpCenter = position.GetUpCenterPosition();
        var positionUpRight = position.GetUpRightPosition();
        var positionCenterLeft = position.GetCenterLeftPosition();
        var positionCenterRight = position.GetCenterRightPosition();
        var positionDownLeft = position.GetDownLeftPosition();
        var positionDownCenter = position.GetDownCenterPosition();
        var positionDownRight = position.GetDownRightPosition();
        
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