using System;

namespace ChessKit.ChessLogic.Primitives
{
    public static class PieceExtensions
    {
        public static Piece With(this PieceType pieceType, Color color)
        {
            return (Piece)pieceType | (Piece)color;
        }

        public static Color Color(this Piece piece)
        {
            return (Color)piece & Primitives.Color.All;
        }

        public static PieceType PieceType(this Piece piece)
        {
            return (PieceType)piece & Primitives.PieceType.All;
        }

        public static char GetSymbol(this Piece piece)
        {
            switch (piece)
            {
                case Piece.WhitePawn:   return 'P';
                case Piece.WhiteKnight: return 'N';
                case Piece.WhiteBishop: return 'B';
                case Piece.WhiteRook:   return 'R';
                case Piece.WhiteQueen:  return 'Q';
                case Piece.WhiteKing:   return 'K';
                case Piece.BlackPawn:   return 'p';
                case Piece.BlackKnight: return 'n';
                case Piece.BlackBishop: return 'b';
                case Piece.BlackRook:   return 'r';
                case Piece.BlackQueen:  return 'q';
                case Piece.BlackKing:   return 'k';
                case Piece.EmptyCell:   return ' ';
                default: throw new Exception("Unexpected");
            }
        }

        public static bool TryParsePiece(this char ch, out Piece piece)
        {
            switch (ch)
            {
                case 'P': piece = Piece.WhitePawn; break;
                case 'N': piece = Piece.WhiteKnight; break;
                case 'B': piece = Piece.WhiteBishop; break;
                case 'R': piece = Piece.WhiteRook; break;
                case 'Q': piece = Piece.WhiteQueen; break;
                case 'K': piece = Piece.WhiteKing; break;
                case 'p': piece = Piece.BlackPawn; break;
                case 'n': piece = Piece.BlackKnight; break;
                case 'b': piece = Piece.BlackBishop; break;
                case 'r': piece = Piece.BlackRook; break;
                case 'q': piece = Piece.BlackQueen; break;
                case 'k': piece = Piece.BlackKing; break;
                default: piece = Piece.EmptyCell; return false;
            }
            return true;
        }

        public static Piece ParsePiece(this char ch)
        {
            Piece res;
            if (!TryParsePiece(ch, out res))
                throw new Exception("Unexpected");
            return res;
        }
    }
}