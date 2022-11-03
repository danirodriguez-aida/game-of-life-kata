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

        [TestCaseSource(nameof(CasesALivingCellAndLowerThanTwoLivingNeighbors))]
        public void a_living_cell_with_less_than_two_living_neighboring_dies(TestBoards boards) {
            var gameOfLife = new GameOfLife(boards.InitialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.IsCellAlive(boards.CheckStatusInPosition).Should().BeFalse();
        }
        
       
        [TestCaseSource(nameof(CasesALivingCellAndTwoLivingNeighbors))]
        public void a_living_cell_with_two_living_neighboring_cells_stays_alive(TestBoards boards) {
            
            var gameOfLife = new GameOfLife(boards.InitialBoard);

            gameOfLife.NextGeneration();

            gameOfLife.IsCellAlive(boards.CheckStatusInPosition).Should().BeTrue();
        }

        private static IEnumerable<TestBoards> CasesALivingCellAndTwoLivingNeighbors()
        {
            var board1 = GetBoardWithAliveCells(3, 3, Position.In(0, 1), Position.In(1, 1), Position.In(2, 1));
            var test1 = new TestBoards(board1, Position.In(1, 1));
            var board2 = GetBoardWithAliveCells(3, 3, Position.In(0, 1), Position.In(1, 1), Position.In(2, 1));
            var test2 = new TestBoards(board2, Position.In(1, 1));
            return new[] {test1, test2};
        }

        private static IEnumerable<TestBoards> CasesALivingCellAndLowerThanTwoLivingNeighbors()
        {
            var board1 = GetBoardWithAliveCells(3, 3, Position.In(1, 1));
            var test1 = new TestBoards(board1, Position.In(1, 1));
            var board2 = GetBoardWithAliveCells(3, 3, Position.In(2, 2));
            var test2 = new TestBoards(board2, Position.In(2, 2));
            var board3 = GetBoardWithAliveCells(3, 3, Position.In(0, 2));
            var test3 = new TestBoards(board3, Position.In(0, 2));
            return new[] {test1, test2, test3};
        }

        public class TestBoards
        {
            public Board InitialBoard { get; }
            public Position CheckStatusInPosition { get; }

            public TestBoards(Board initialBoard, Position checkStatusInPosition)
            {
                InitialBoard = initialBoard;
                CheckStatusInPosition = checkStatusInPosition;
            }
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