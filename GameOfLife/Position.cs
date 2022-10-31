namespace GameOfLifeApp;

public class Position
{
    private Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static Position GetIn(int row, int column)
    {
        return new Position(row, column);
    }

    public int Row { get; }
    public int Column { get; }
}