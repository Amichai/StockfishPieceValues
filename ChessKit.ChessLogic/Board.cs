using ChessKit.ChessLogic.Algorithms;

namespace ChessKit.ChessLogic
{
    public static class Board
    {
        /// <summary>Board with all pieces set into the start position</summary>
        public static readonly Position StartPosition = 
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
            .ParseFen();
    }
}

