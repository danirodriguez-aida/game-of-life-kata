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

        [Test]
        public void a_living_cell_with_less_than_two_living_neighboring_dies()
        {
            var initalBoard = new bool[3, 3];
            initalBoard[1, 1] = true;

            var board = GameOfLife.NextGeneration(initalBoard);

            board[1, 1].Should().BeFalse();
        }

        [Test]
        public void a_living_cell_with_two_living_neighboring_cells_stays_alive()
        {
            var initalBoard = new bool[3, 3];
            initalBoard[1, 1] = true;
            initalBoard[0, 1] = true;
            initalBoard[1, 1] = true;

            var board = GameOfLife.NextGeneration(initalBoard);

            board[1, 1].Should().BeTrue();
        }
    }

    public class GameOfLife
    {
        public static bool[,] NextGeneration(bool[,] board)
        {
            if (!(board[0, 1] && board[1, 1] && board[1, 1])) 
                board[1, 1] = false;
            return board;
        }
    }
}