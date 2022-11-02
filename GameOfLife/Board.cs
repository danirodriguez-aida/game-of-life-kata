namespace GameOfLifeApp;

public class Board
{
    private readonly List<Cell> cells = new();

    public Board(int numberOfRows, int numberOfColumns)
    {
        InitializeBoard(numberOfRows, numberOfColumns);
    }

    private void InitializeBoard(int numberOfRows, int numberOfColumns)
    {
        for (var i = 0; i < numberOfRows; i++)
        {
            for (var j = 0; j < numberOfColumns; j++)
            {
                cells.Add(new Cell(Position.In(i, j)));
            }
        }
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

    public List<Cell> GetNeighbors(Position position)
    {
        var neighbors = new List<Cell>();
        var positionUpLeft = Position.In(position.Row - 1, position.Column - 1);
        neighbors.Add(GetCellBy(positionUpLeft));
        var positionUpCenter = Position.In(position.Row - 1, position.Column);
        neighbors.Add(GetCellBy(positionUpCenter));
        var positionUpRight = Position.In(position.Row - 1, position.Column +1);
        neighbors.Add(GetCellBy(positionUpRight));

        var positionCenterLeft = Position.In(position.Row, position.Column -1);
        neighbors.Add(GetCellBy(positionCenterLeft));
        var positionCenterRight = Position.In(position.Row, position.Column +1);
        neighbors.Add(GetCellBy(positionCenterRight));

        var positionDownLeft = Position.In(position.Row + 1, position.Column - 1);
        neighbors.Add(GetCellBy(positionDownLeft));
        var positionDownCenter = Position.In(position.Row + 1, position.Column);
        neighbors.Add(GetCellBy(positionDownCenter));
        var positionDownRight = Position.In(position.Row + 1, position.Column + 1 );
        neighbors.Add(GetCellBy(positionDownRight));

        return neighbors;
    }

    private Cell GetCellBy(Position position)
    {
        return cells.Single(c => c.Position.Equals(position));
    }
}