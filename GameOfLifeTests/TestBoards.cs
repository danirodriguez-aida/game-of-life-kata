using GameOfLifeApp;

namespace GameOfLifeTests {
    public class TestBoards {
        public Board InitialBoard { get; }
        public Position CheckStatusInPosition { get; }

        public TestBoards(Board initialBoard, Position checkStatusInPosition) {
            InitialBoard = initialBoard;
            CheckStatusInPosition = checkStatusInPosition;
        }
    }
}
