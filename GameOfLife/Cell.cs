namespace GameOfLifeApp;

public class Cell
{
    private bool status;

    public Cell(Position position)
    {
        Position = position;
    }

    public bool GetStatus() => status;

    public void SetToLive() => status = true; 
    public void SetToDead() => status = false; 

    public Position Position { get; }
}