namespace GameOfLifeApp;

public class Cell {
    private CellStatus status = CellStatus.Dead;

    public Cell(Position position) {
        Position = position;
    }

    public bool IsAlive() => status == CellStatus.Alive;

    public void SetToLive() => status = CellStatus.Alive;
    public void SetToDead() => status = CellStatus.Dead;

    public Position Position { get; }
}