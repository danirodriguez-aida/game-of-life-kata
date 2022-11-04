namespace GameOfLifeApp;

public class CellCollection
{
    private readonly List<Cell> cells = new();

    public IEnumerable<Cell> GetCells()
    {
        return cells;
    }

    public void Add(Cell cell)
    {
        cells.Add(cell);
    }

    public bool ExistsCellIn(Position position)
    {
        return cells.SingleOrDefault(c => c.Position.Equals(position)) != null;
    }

    public Cell GetCellBy(Position position)
    {
        return cells.Single(c => c.Position.Equals(position));
    }
}