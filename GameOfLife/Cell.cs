namespace GameOfLifeApp;

public class Cell
{
    public Cell(bool status, Position position)
    {
        Status = status;
        Position = position;
    }

    public bool Status { get; set; }
    public Position Position { get; }
}