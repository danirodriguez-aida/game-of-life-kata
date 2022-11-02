using FluentAssertions;
using GameOfLifeApp;

namespace GameOfLifeTests {
    public class GameOfLifeShould {

        [Test]
        public void a_dead_cell_with_dead_neighbors_stays_dead() {
            var initialBoard = new Board(3, 3);
            var gameOfLife = new GameOfLife(initialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.IsCellAlive(Position.In(1, 1)).Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_less_than_two_living_neighboring_dies() {
            var initialBoard = new Board(3, 3);
            initialBoard.SetCellToLive(Position.In(1, 1));
            var gameOfLife = new GameOfLife(initialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.IsCellAlive(Position.In(1, 1)).Should().BeFalse();
        }

   
       
        [TestCaseSource(nameof(GetExpectedBoards))]
        public void a_living_cell_with_two_living_neighboring_cells_stays_alive(Board board) {
            var gameOfLife = new GameOfLife(board);

            gameOfLife.NextGeneration();

            gameOfLife.IsCellAlive(Position.In(1, 1)).Should().BeTrue();
        }

        private static IEnumerable<Board> GetExpectedBoards() {
            yield return GetBoardWithAliveCells(3, 3, Position.In(0, 1), Position.In(1, 1),Position.In(2, 1));
            yield return GetBoardWithAliveCells(3, 3, Position.In(1, 0), Position.In(1, 1),Position.In(1, 2));
        }

        private static Board GetBoardWithAliveCells(int numberOfRows, int numberOfColumns, params Position[] aliveCellPositions)
        {
            var initialBoard = new Board(numberOfRows, numberOfColumns);
            foreach (var cellPosition in aliveCellPositions)
            {
                initialBoard.SetCellToLive(cellPosition);
            }
            return initialBoard;
        }
    }
}