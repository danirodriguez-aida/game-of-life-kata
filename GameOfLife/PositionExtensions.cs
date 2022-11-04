namespace GameOfLifeApp;

public static class PositionExtensions
{
    public static Position GetUpLeftPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row - 1, originPosition.Column - 1);
    }
    public static Position GetUpCenterPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row - 1, originPosition.Column);
    }
    public static Position GetUpRightPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row - 1, originPosition.Column + 1);
    }
    public static Position GetCenterLeftPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row, originPosition.Column - 1);
    }
    public static Position GetCenterRightPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row, originPosition.Column + 1);
    }
    public static Position GetDownLeftPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row + 1, originPosition.Column - 1);
    }
    public static Position GetDownCenterPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row + 1, originPosition.Column);
    }
    public static Position GetDownRightPosition(this Position originPosition)
    {
        return Position.In(originPosition.Row + 1, originPosition.Column + 1);
    }
}