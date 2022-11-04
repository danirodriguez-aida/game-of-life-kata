namespace GameOfLifeApp;

public class Cell {
    private CellStatus status = CellStatus.Dead;

    public Cell(Position position) {
        Position = position;
    }

    public bool IsAlive() => status == CellStatus.Alive;

    public void SetTo(CellStatus newStatus) => this.status = newStatus;

    public Position Position { get; }
}