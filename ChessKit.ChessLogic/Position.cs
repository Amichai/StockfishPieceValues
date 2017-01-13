using ChessKit.ChessLogic.Algorithms;
using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic
{
    /// <summary>Represents a position in the game
    /// (adding Properties to the position is a bit CPU consuming)</summary>
    public sealed class Position
    {
        /// <summary>Stuff that was calculated immediately with the legality check</summary>
        public PositionCore Core { get; }

        /// <summary>50 moves rule counter</summary>
        public int FiftyMovesClock { get; }

        /// <summary>Number of full moves (white, then black) counted</summary>
        public int MoveNumber { get; }

        /// <summary>Properties of the position like check, mate and stalemate</summary>
        public GameStates Properties { get; }

        /// <summary>The previous legal move if the position derives from
        /// some other position, -or- ...</summary>
        public LegalMove Move { get; }

        public Position(PositionCore core, int fiftyMovesClock, int moveNumber, GameStates properties, LegalMove move)
        {
            Core = core;
            FiftyMovesClock = fiftyMovesClock;
            MoveNumber = moveNumber;
            Properties = properties;
            Move = move;
        }

        public Position MakeMove(string algebraicMove)
        {
            return this.ParseMoveFromSan(algebraicMove)
                .ToPosition();
        }
    }
}