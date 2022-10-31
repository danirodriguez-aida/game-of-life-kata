namespace GameOfLifeApp;

public class Board
{
    private readonly bool[,] _cells;

    public Board(int numberOfRows, int numberOfColumns)
    {
        _cells = new bool[numberOfRows, numberOfColumns];
    }

    public bool SetCellToDead(Position position)
    {
        return _cells[position.Row, position.Column] = false;
    }

    public bool SetCellToLive(Position position)
    {
        return _cells[position.Row, position.Column] = true;
    }

    public bool GetCellStatus(Position position)
    {
        return _cells[position.Row, position.Column];
    }
}