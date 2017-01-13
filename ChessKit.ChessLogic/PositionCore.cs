using System;
using System.Diagnostics;
using ChessKit.ChessLogic.Algorithms;
using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic
{
    /// <summary>The part of the chess position that can be compared
    /// to determine threefold repetitions</summary>
    public sealed class PositionCore : IEquatable<PositionCore>
    {
        const int BytesCount = 128;

        /// <summary>An array of the 64 squares the chess board consists of
        /// Note that index 0 corresponds to a8, and NOT a1!
        /// Indexes read left to right, top to bottom!</summary>
        internal byte[] Cells { get; }

        /// <summary>The color of the side that makes the next move</summary>
        public Color Turn { get; }

        /// <summary>Castlings available to the both sides
        /// (one that changes when they move their kings/rooks)</summary>
        public Castlings CastlingAvailability { get; }

        /// <summary>The index is the file the opponent last
        /// made pawn double move -or- ...</summary>
        public int? EnPassant { get; }

        public int WhiteKing { get; }
        public int BlackKing { get; }

        public PositionCore(byte[] cells, Color turn, Castlings availableCastlings, int? enPassant, int whiteKing, int blackKing)
        {
            Debug.Assert(cells.Length == BytesCount);
            Cells = cells;
            Turn = turn;
            CastlingAvailability = availableCastlings;
            EnPassant = enPassant;
            WhiteKing = whiteKing;
            BlackKing = blackKing;
        }

        public Piece this[int index]
        {
            get
            {
                if ((index & 0x88) != 0)
                    throw new IndexOutOfRangeException("Invalid 0x88 index!");
                return (Piece)Cells[index];
            }
        }

        public Piece this[string index] => (Piece) Cells[index.ParseCoordinate()];

        public byte[] GetCopyOfCells()
        {
            var result = new byte[BytesCount];
            Buffer.BlockCopy(Cells, 0, result, 0, BytesCount);
            return result; 
        }

        #region ' Equality '

        public bool Equals(PositionCore other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            for (var i = 0; i < 64; i++)
            {
                var sq = i + (i & ~7);
                if (Cells[sq] != other.Cells[sq])
                    return false;
            }
            return Turn == other.Turn &&
                   CastlingAvailability == other.CastlingAvailability &&
                   EnPassant == other.EnPassant;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is PositionCore && Equals((PositionCore)obj);
        }

        public override int GetHashCode()
        {
            var hash = this.GetHash();
            return unchecked((int)hash & (int)(hash >> 32));
        }

        public static bool operator ==(PositionCore left, PositionCore right) => Equals(left, right);
        public static bool operator !=(PositionCore left, PositionCore right) => !Equals(left, right);

        #endregion        
    }
}