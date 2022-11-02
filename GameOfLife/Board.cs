namespace GameOfLifeApp;

public class Board
{
    private readonly bool[,] _cells;

    public Board(int numberOfRows, int numberOfColumns)
    {
        _cells = new bool[numberOfRows, numberOfColumns];
    }

    public void SetCellToDead(Position position)
    {
        _cells[position.Row, position.Column] = false;
    }

    public void SetCellToLive(Position position)
    {
        _cells[position.Row, position.Column] = true;
    }

    public bool GetCellStatus(Position position)
    {
        return new Cell(_cells[position.Row, position.Column]).Status;
    }
}