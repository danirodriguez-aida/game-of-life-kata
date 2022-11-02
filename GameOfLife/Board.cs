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

    private Cell GetCellBy(Position position)
    {
        return cells.Single(c => c.Position.Equals(position));
    }
}