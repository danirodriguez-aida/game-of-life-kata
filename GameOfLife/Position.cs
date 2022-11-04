namespace GameOfLifeApp;

public class Position : IEquatable<Position>
{
    private Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static Position In(int row, int column)
    {
        return new Position(row, column);
    }

    public int Row { get; }
    public int Column { get; }

    public bool Equals(Position? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Position)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public Position[] GetNeighborsPositions()
    {
        return new[]
        {
            this.GetUpLeftPosition(),
            this.GetUpCenterPosition(),
            this.GetUpRightPosition(),
            this.GetCenterLeftPosition(),
            this.GetCenterRightPosition(),
            this.GetDownLeftPosition(),
            this.GetDownCenterPosition(),
            this.GetDownRightPosition()
        };
    }
}