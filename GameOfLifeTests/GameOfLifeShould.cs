using FluentAssertions;
using GameOfLifeApp;

namespace GameOfLifeTests {
    public class GameOfLifeShould {

        [Test]
        public void a_dead_cell_with_dead_neighbors_stays_dead() {
            var initialBoard = new Board(3, 3);
            var gameOfLife = new GameOfLife(initialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.GetCellStatus(Position.GetIn(1, 1)).Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_less_than_two_living_neighboring_dies() {
            var initialBoard = new Board(3, 3);
            initialBoard.SetCellToLive(Position.GetIn(1, 1));
            var gameOfLife = new GameOfLife(initialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.GetCellStatus(Position.GetIn(1, 1)).Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_two_living_neighboring_cells_stays_alive() {
            var initialBoard = new Board(3, 3);
            initialBoard.SetCellToLive(Position.GetIn(0, 1));
            initialBoard.SetCellToLive(Position.GetIn(1, 1));
            initialBoard.SetCellToLive(Position.GetIn(2, 1));
            var gameOfLife = new GameOfLife(initialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.GetCellStatus(Position.GetIn(1, 1)).Should().BeTrue();
        }
    }
}