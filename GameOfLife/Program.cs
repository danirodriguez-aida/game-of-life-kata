// See https://aka.ms/new-console-template for more information

using System.Text;
using GameOfLifeApp;

async Task PrintBoard(Board board)
{
    Console.Clear();
    var printedBoard = new StringBuilder("");
    var cells = board.GetCells().ToList();
    var maxRow = cells.Max(x => x.Position.Row);
    for (var i = 0; i < maxRow; i++)
    {
        var row = i;
        var cellsForRow = cells.Where(x => x.Position.Row == row).OrderBy(x => x.Position.Column);
        foreach (var cell in cellsForRow)
        {
            var symbol = cell.IsAlive() ? "X" : "-";
            printedBoard.Append(symbol);
        }
        printedBoard.AppendLine("");
    }
    Console.WriteLine(printedBoard.ToString());
    await Task.Delay(1000);
}

var board = new Board(25,50);
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(0,0));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(0,1));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(1,0));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(5,5));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(5,4));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(4,4));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(3,4));

board.SetStatusCellInPosition(CellStatus.Alive, Position.In(20,30));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(20,31));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(20,32));
board.SetStatusCellInPosition(CellStatus.Alive, Position.In(20,33));
var gameOfLife = new GameOfLife(board);
await PrintBoard(gameOfLife.GetBoard());
for (var i = 1; i < 1000; i++) {
    gameOfLife.NextGeneration();
    var nextBoard = gameOfLife.GetBoard();
    await PrintBoard(nextBoard);
}

Console.ReadKey();


