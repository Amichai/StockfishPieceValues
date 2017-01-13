using System;
using System.Linq;
using System.Text;
using ChessKit.ChessLogic.Primitives;
using JetBrains.Annotations;

namespace ChessKit.ChessLogic.Algorithms
{
    public static class Fen
    {
        /// <summary> Load position from FEN string </summary>
        /// <param name="fen">FEN string</param>
        /// <remarks>http://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation</remarks>
        public static Position ParseFen([NotNull] this string fen)
        {
            if (fen == null) throw new ArgumentNullException(nameof(fen));
            var offset = 0;
            try
            {
                var cells = PiecePlacement(fen, ref offset);
                var color = ActiveColor(fen, ref offset);
                var castling = CastlingAvailability(fen, ref offset);
                var enPassant = EnPassant(fen, ref offset);
                var halfmoveClock = HalfmoveClock(fen, ref offset);
                var moveNumber = FullmoveNumber(fen, ref offset);
                var whiteKing = Coordinates.All.SingleOrDefault(p => ((Piece)cells[p]) == Piece.WhiteKing);
                var blackKing = Coordinates.All.SingleOrDefault(p => ((Piece)cells[p]) == Piece.BlackKing);
                return new Position(
                    new PositionCore(cells, color, castling, enPassant, whiteKing, blackKing),
                    halfmoveClock, moveNumber, GameStates.None, null);
            }
            catch (IndexOutOfRangeException x)
            {
                throw new FormatException("Unexpected end of FEN string", x);
            }
        }

        private static byte[] PiecePlacement(string fen, ref int i)
        {
            var res = new byte[128];
            for (var sq = 63;; i++)
            {
                if (fen[i] == ' ') break;
                if (fen[i] >= '1' && fen[i] <= '9') sq -= fen[i] - '0';
                else if ('/' == fen[i])
                {
                }
                else
                {
                    var c = (sq/8)*8 + 7 - sq%8;
                    res[c + (c & ~7)] = (byte) fen[i].ParsePiece();
                    sq--;
                }
            }
            i++; // Skip the space
            return res;
        }

        private static Color ActiveColor(string fen, ref int i)
        {
            var res = fen[i++].ParseColor();
            if (fen[i] != ' ')
                throw new FormatException("Unexpected symbol");
            i++; // skip the space 
            return res;
        }

        private static Castlings CastlingAvailability(string fen, ref int i)
        {
            var flags = default(Castlings);
            for (;; i++)
            {
                if (fen[i] == '-')
                {
                }
                else if (fen[i] == 'K') flags |= Castlings.WK;
                else if (fen[i] == 'Q') flags |= Castlings.WQ;
                else if (fen[i] == 'k') flags |= Castlings.BK;
                else if (fen[i] == 'q') flags |= Castlings.BQ;
                else if (fen[i] == ' ') break;
                else throw new FormatException("illegal character");
            }
            i++; // Skip the space
            return flags;
        }

        private static int? EnPassant(string fen, ref int i)
        {
            int? res = null;
            if (fen[i] != '-')
            {
                res = EnPassantParser.Parse(fen[i]);
            }
            i++; // Skip the rank, or skip the '-'
            i++; // Skip the space
            return res;
        }

        private static int HalfmoveClock(string fen, ref int i)
        {
            var res = 0;
            for (;; i++)
            {
                if (fen[i] == ' ') break;
                if (fen[i] >= '0' && fen[i] <= '9')
                    res = res*10 + fen[i] - '0';
            }
            i++; // Skip the space
            return res;
        }

        private static int FullmoveNumber(string fen, ref int i)
        {
            var res = 0;
            for (; i < fen.Length; i++)
                if (fen[i] >= '0' && fen[i] <= '9')
                    res = res*10 + fen[i] - '0';
            return res;
        }

        private static class EnPassantParser
        {
            private static readonly int[] Symbols;
            private const char Z = '-';
            private const int Illegal = 99;

            static EnPassantParser()
            {
                Symbols = new int['z' - Z];

                for (var i = 0; i < Symbols.Length; i++)
                    Symbols[i] = Illegal;

                Symbols['-' - Z] = -1;

                Symbols['a' - Z] = 0;
                Symbols['b' - Z] = 1;
                Symbols['c' - Z] = 2;
                Symbols['d' - Z] = 3;
                Symbols['e' - Z] = 4;
                Symbols['f' - Z] = 5;
                Symbols['g' - Z] = 6;
                Symbols['h' - Z] = 7;

                Symbols['A' - Z] = 0;
                Symbols['B' - Z] = 1;
                Symbols['C' - Z] = 2;
                Symbols['D' - Z] = 3;
                Symbols['E' - Z] = 4;
                Symbols['F' - Z] = 5;
                Symbols['G' - Z] = 6;
                Symbols['H' - Z] = 7;
            }

            public static int Parse(char symbol)
            {
                int res;
                try
                {
                    res = Symbols[symbol - Z];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new FormatException("illegal character");
                }
                if (res == Illegal)
                    throw new FormatException("illegal character");
                return res;
            }
        }
        public static string ToFenString(this Position position)
        {
            var fen = new StringBuilder(77);
            for (int empty = 0, sq = 63; sq >= 0; sq--)
            {
                var idx = (sq / 8) * 8 + 7 - sq % 8;
                idx = idx + (idx & ~7);
                if (position.Core.Cells[idx] == 0)
                {
                    empty++;
                    if (0 == sq % 8)
                    {
                        if (empty != 0) fen.Append((char)('0' + empty));
                        if (sq != 0) fen.Append('/');
                        empty = 0;
                    }
                    continue;
                }

                if (empty != 0) fen.Append((char)('0' + empty));
                fen.Append(((Piece)position.Core.Cells[idx]).GetSymbol());
                empty = 0;
                if (sq != 0 && sq % 8 == 0) fen.Append('/');
            }

            fen.Append(' ');
            fen.Append(position.Core.Turn == Color.White ? 'w' : 'b');

            fen.Append(' ');
            var castling = position.Core.CastlingAvailability;
            if (castling == Castlings.None)
            {
                fen.Append('-');
            }
            else
            {
                if ((castling & Castlings.WK) != 0) fen.Append('K');
                if ((castling & Castlings.WQ) != 0) fen.Append('Q');
                if ((castling & Castlings.BK) != 0) fen.Append('k');
                if ((castling & Castlings.BQ) != 0) fen.Append('q');
            }

            fen.Append(' ');
            if (!position.Core.EnPassant.HasValue)
            {
                fen.Append('-');
            }
            else
            {
                fen.Append("abcdefgh"[position.Core.EnPassant.GetValueOrDefault()]);
                fen.Append(position.Core.Turn == Color.White ? '6' : '3');
            }

            fen.Append(' ');
            fen.Append(position.FiftyMovesClock);

            fen.Append(' ');
            fen.Append(position.MoveNumber);

            return fen.ToString();
        }
        public static string PrintFen(this Position position)
        {
            return position.ToFenString();
        }
    }
}