namespace GameOfLifeApp;

public class Cell
{
    public Cell(bool status)
    {
        Status = status;
    }

    public bool Status { get; private set; }
}