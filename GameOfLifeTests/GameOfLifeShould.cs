using FluentAssertions;
using GameOfLifeApp;

namespace GameOfLifeTests {
    public class GameOfLifeShould {

        [Test]
        public void a_dead_cell_with_dead_neighbors_stays_dead() {
            var initialBoard = new bool[3, 3];
            var gameOfLife = new GameOfLife(new Board(initialBoard));

            gameOfLife.NextGeneration();

            gameOfLife.GetBoard().GetCells()[1, 1].Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_less_than_two_living_neighboring_dies() {
            var initialBoard = new bool[3, 3];
            initialBoard[1, 1] = true;
            var gameOfLife = new GameOfLife(new Board(initialBoard));

            gameOfLife.NextGeneration();

            gameOfLife.GetBoard().GetCells()[1, 1].Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_two_living_neighboring_cells_stays_alive() {
            var initialBoard = new bool[3, 3];
            initialBoard[1, 1] = true;
            initialBoard[0, 1] = true;
            initialBoard[2, 1] = true;
            var gameOfLife = new GameOfLife(new Board(initialBoard));

            gameOfLife.NextGeneration();

            gameOfLife.GetBoard().GetCells()[1, 1].Should().BeTrue();
        }
    }
}