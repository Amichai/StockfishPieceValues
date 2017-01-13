using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ChessKit.ChessLogic.Primitives;
using JetBrains.Annotations;

namespace ChessKit.ChessLogic.Internals
{
    /// <summary>Represents piece Type</summary>
    [Immutable, PublicAPI]
    public sealed class MetaPiece
    {
        /// <summary>Piece type</summary>
        public PieceType PieceType => _value.PieceType();

        /// <summary>Piece color</summary>
        public Color Color => _value.Color();

        /// <summary>Gets all directions of move piece can do</summary>
        public ReadOnlyCollection<MoveDirection> MoveDirections { get; private set; }

        private Piece _value;

        internal MetaPiece(Piece value)
        {
            _value = value;
        }

        /// <summary>All Types pieces may have</summary>
        public static ReadOnlyCollection<MetaPiece> All { get; private set; }

        static MetaPiece()
        {
            //      _______________
            // ____/ Create Pieces \____________________________________________________________
            var whitePawn = new MetaPiece(Piece.WhitePawn);
            var whiteBishop = new MetaPiece(Piece.WhiteBishop);
            var whiteKnight = new MetaPiece(Piece.WhiteKnight);
            var whiteRook = new MetaPiece(Piece.WhiteRook);
            var whiteQueen = new MetaPiece(Piece.WhiteQueen);
            var whiteKing = new MetaPiece(Piece.WhiteKing);

            var blackPawn = new MetaPiece(Piece.BlackPawn);
            var blackBishop = new MetaPiece(Piece.BlackBishop);
            var blackKnight = new MetaPiece(Piece.BlackKnight);
            var blackRook = new MetaPiece(Piece.BlackRook);
            var blackQueen = new MetaPiece(Piece.BlackQueen);
            var blackKing = new MetaPiece(Piece.BlackKing);
            //      _____________
            // ____/ Collections \______________________________________________________________
            All = new ReadOnlyCollection<MetaPiece>(new[]
            {
                whitePawn, whiteBishop, whiteKnight, whiteRook,
                whiteQueen, whiteKing, blackPawn, blackBishop,
                blackKnight, blackRook, blackQueen, blackKing
            });
            //      ________________
            // ____/ MoveDirections \___________________________________________________________
            whitePawn.MoveDirections = Join(Move(0, 1), Take(1, 1), Take(-1, 1), Special(0, 2));
            whiteBishop.MoveDirections = Join(Slide(1, 1), Slide(1, -1), Slide(-1, -1), Slide(-1, 1));
            whiteKnight.MoveDirections = Join(Take(1, 2), Take(-1, 2), Take(1, -2), Take(-1, -2), Take(2, 1),
                Take(-2, 1), Take(2, -1), Take(-2, -1));
            whiteRook.MoveDirections = Join(Slide(0, 1), Slide(1, 0), Slide(0, -1), Slide(-1, 0));
            whiteQueen.MoveDirections = Join(whiteRook.MoveDirections, whiteBishop.MoveDirections);
            whiteKing.MoveDirections = Join(Take(0, 1), Take(1, 1), Take(1, 0), Take(1, -1),
                Take(0, -1), Take(-1, -1), Take(-1, 0), Take(-1, 1),
                Special(2, 0), Special(-2, 0));

            blackPawn.MoveDirections = Join(Move(0, -1), Take(1, -1), Take(-1, -1), Special(0, -2));
            blackBishop.MoveDirections = whiteBishop.MoveDirections;
            blackKnight.MoveDirections = whiteKnight.MoveDirections;
            blackRook.MoveDirections = whiteRook.MoveDirections;
            blackQueen.MoveDirections = whiteQueen.MoveDirections;
            blackKing.MoveDirections = whiteKing.MoveDirections;
        }

        private static T Id<T>(T v) => v;
        private static ReadOnlyCollection<T> Join<T>(params IEnumerable<T>[] arr)
            => new ReadOnlyCollection<T>(arr.SelectMany(Id).ToList());

        private static IEnumerable<MoveDirection> Slide(int dx, int dy)
        {
            yield return new MoveDirection(dx, dy, 8, true);
        }

        private static IEnumerable<MoveDirection> Take(int dx, int dy)
        {
            yield return new MoveDirection(dx, dy, 1, true);
        }

        private static IEnumerable<MoveDirection> Move(int dx, int dy)
        {
            yield return new MoveDirection(dx, dy, 1, false);
        }

        private static IEnumerable<MoveDirection> Special(int dx, int dy)
        {
            yield return new MoveDirection(dx, dy, 1, false, true);
        }
    }
}