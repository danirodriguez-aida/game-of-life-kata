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

    private IEnumerable<Cell> GetCellNeighbors(Position position)
    {
        var neighborsPositions = position.GetNeighborsPositions();
        return (from neighborPosition in neighborsPositions where cells.ExistsCellIn(neighborPosition) select cells.GetCellBy(neighborPosition)).ToList();
    }

    private Board CreateBoardWithSameSize()
    {
        return new Board(numberOfRows,numberOfColumns);
    }

    private CellStatus GetNextStatusForCell(Position position) {
        var cellNeighbors = GetCellNeighbors(position);
        var aliveNeighbors = cellNeighbors.Count(n => n.IsAlive());
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