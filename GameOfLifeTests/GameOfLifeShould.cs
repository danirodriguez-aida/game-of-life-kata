using FluentAssertions;

namespace GameOfLifeTests {
    public class GameOfLifeShould {
        
        [Test]
        public void a_dead_cell_with_dead_neighbors_stays_dead()
        {
            var initalBoard = new bool[3, 3];

            var board = GameOfLife.NextGeneration(initalBoard);

            board[1, 1].Should().BeFalse();
        }
    }

    public class GameOfLife
    {
        public static bool[,] NextGeneration(bool[,] board)
        {
            return board;
        }
    }
}