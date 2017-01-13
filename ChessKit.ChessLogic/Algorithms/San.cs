using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ChessKit.ChessLogic.Primitives;
using JetBrains.Annotations;
using static ChessKit.ChessLogic.Primitives.MoveAnnotations;

namespace ChessKit.ChessLogic.Algorithms
{
    public static class San
    {
        /// <summary>
        ///     Get the SAN (standard algebraic notation) index for a move - move number and the side to move
        ///     without checking the status of the game or if it's a valid move.
        /// </summary>
        /// <returns></returns>
        public static string GetSanIndex([NotNull] this Position position)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            var sb = new StringBuilder(5);
            sb.Append(position.MoveNumber.ToString(CultureInfo.InvariantCulture));
            if (position.Core.Turn == Color.White)
            {
                sb.Append('.');
            }
            else
            {
                sb.Append("...");
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Gets the end of the SAN (standard algebraic notation) for a move - promotion and check/checkmate representation -
        ///     after the move is made
        ///     without checking the status of the game or if it's a valid move.
        /// </summary>
        /// <param name="position">The game</param>
        /// <param name="move">The move</param>
        /// <returns></returns>
        public static string GetSanEnd([NotNull] this Position position, [NotNull] Move move)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            if (move == null) throw new ArgumentNullException(nameof(move));

            var sb = new StringBuilder(3);

            if (move.PromoteTo != 0)
                sb.Append('=').Append(move.PromoteTo.With(Color.White).GetSymbol());

            if ((position.Properties & GameStates.Check) != 0) sb.Append('+');
            else if ((position.Properties & GameStates.Mate) != 0) sb.Append('#');

            return sb.ToString();
        }

        /// <summary>
        ///     Gets the begin of the SAN (standard algebraic notation) for a move - without promotion or check/checkmate
        ///     representation -  before the move is made
        ///     without checking the status of the game or if it's a valid move.
        /// </summary>
        /// <param name="position">The game</param>
        /// <param name="move">The move</param>
        /// <returns></returns>
        public static string GetSanBegin([NotNull] this Position position, LegalMove move)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));

            var sb = new StringBuilder(6);

            if ((move.Annotations & (WK | BK)) != 0)
            {
                sb.Append("O-O");
            }
            else if ((move.Annotations & (WQ | BQ)) != 0)
            {
                sb.Append("O-O-O");
            }
            else
            {
                if ((move.Annotations & Pawn) != 0)
                {
                    if ((move.Annotations & Capture) != 0)
                        sb.Append(move.Move.FromCell.GetFile());
                }
                else
                {
                    sb.Append(((Piece) position.Core.Cells[move.Move.FromCell]).GetSymbol());

                    // TODO: move should have Piece prop?
                    var disambiguationList = new List<int>(
                        from m in position.GetAllLegalMoves()
                        where m.Move.FromCell != move.Move.FromCell
                              && m.Move.ToCell == move.Move.ToCell
                              && position.Core.Cells[move.Move.FromCell] == position.Core.Cells[m.Move.FromCell]
                        select m.Move.FromCell);

                    if (disambiguationList.Count > 0)
                    {
                        var uniqueFile = true;
                        // ReSharper disable LoopCanBeConvertedToQuery
                        // ReSharper disable ForCanBeConvertedToForeach
                        for (var index = 0; index < disambiguationList.Count; index++)
                        {
                            var m = disambiguationList[index];
                            if (move.Move.FromCell.GetFile() == m.GetFile())
                            {
                                uniqueFile = false;
                                break;
                            }
                        }
                        if (uniqueFile)
                        {
                            sb.Append(move.Move.FromCell.GetFile());
                        }
                        else
                        {
                            var uniqueRank = true;
                            for (var i = 0; i < disambiguationList.Count; i++)
                            {
                                var m = disambiguationList[i];
                                if (move.Move.FromCell.GetRank() == m.GetRank())
                                {
                                    uniqueRank = false;
                                    break;
                                }
                            }
                            // ReSharper restore ForCanBeConvertedToForeach
                            // ReSharper restore LoopCanBeConvertedToQuery
                            if (uniqueRank)
                            {
                                sb.Append(move.Move.FromCell.GetRank().ToString(CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                sb.Append(move.Move.FromCell);
                            }
                        }
                    }
                }

                // if there is a capture, add capture notation
                if ((move.Annotations & Capture) == Capture)
                {
                    sb.Append('x');
                }

                // add destination square
                sb.Append(move.Move.ToCell);
            }

            return sb.ToString();
        }

        public static string GetSan([NotNull] this Position position, LegalMove move)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            return position.GetSanBegin(move) /*+ position.GetSanEnd(move)*/;
        }

        /// <summary>
        ///     Gets a move from its SAN (standard algebraic notation).
        ///     Throws ArgumentException if it's not a valid move.
        /// </summary>
        /// <param name="position">The game</param>
        /// <param name="san">The SAN string</param>
        /// <returns></returns>
        public static LegalMove ParseMoveFromSan([NotNull] this Position position, [NotNull] string san)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            if (san == null) throw new ArgumentNullException(nameof(san));

            if (san == "O-O")
                return position.ValidateLegal(Move.Parse(position.Core.Turn == Color.White ? "e1-g1" : "e8-g8"));
            if (san == "O-O-O")
                return position.ValidateLegal(Move.Parse(position.Core.Turn == Color.White ? "e1-c1" : "e8-c8"));

            var index = san.Length - 1;
            // remove chess and checkmate representation (if any)
            if (index > -1 && (san[index] == '+' || san[index] == '#')) index--;
            if (index < 1) return null;

            // get the promotion (if any)
            var prom = PieceType.Queen;
            if (san[index - 1] == '=')
            {
                prom = san[index].ParsePiece().PieceType();
                index -= 2;
            }

            if (index < 1) return null;
            var to = san.Substring(index - 1, 2).ParseCoordinate();
            index -= 2;

            // remove capture char (if any)
            if (index > -1 && san[index] == 'x') index--;

            // get the rank of the starting square (if any)
            int? rank = null;
            if (index > -1 && san[index] >= '1' && san[index] <= '8')
            {
                rank = san[index] - '1';
                index--;
            }

            // get the file of the starting square (if any)
            int? file = null;
            if (index > -1 && san[index] >= 'a' && san[index] <= 'h')
            {
                file = san[index] - 'a';
                index--;
            }

            // get piece Type char (if any)
            var pieceChar = PieceType.Pawn;
            if (index > -1)
            {
                pieceChar = san[index].ParsePiece().PieceType();
                index--;
            }
            if (index != -1) throw new FormatException("Illegal characters");
            return GetMove(position, to, file, rank, pieceChar, prom);
        }

        private static LegalMove GetMove(Position position, int to, int? file, int? rank, PieceType pieceChar,
            PieceType prom)
        {
            var move = default(LegalMove);
            foreach (var m in position.GetAllLegalMoves())
                if (m.Move.ToCell == to)
                    if (file == null || file == m.Move.FromCell.GetX())
                        if (rank == null || rank == m.Move.FromCell.GetY())
                            if (((Piece) position.Core.Cells[m.Move.FromCell]).PieceType() == pieceChar)
                            {
                                if (move != null) throw new FormatException("Ambiguity");
                                move = m;
                            }
            if (move == null) return null;
            if ((move.Annotations & Promotion) != 0)
            {
                return position.ValidateLegal(
                    new Move(move.Move.FromCell, move.Move.ToCell, prom));
            }
            return move;
        }
    }
}