namespace GameOfLifeApp;

public class Cell
{
    private bool status;

    public Cell(Position position)
    {
        Position = position;
    }

    public bool GetStatus() => status;

    public void SetStatus(bool value) => status = value;

    public Position Position { get; }
}