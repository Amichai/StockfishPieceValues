using System;
using ChessKit.ChessLogic.Primitives;
using S = ChessKit.ChessLogic.Cells;
using static ChessKit.ChessLogic.Primitives.MoveAnnotations;

namespace ChessKit.ChessLogic.Algorithms
{
    public static partial class MoveLegality
    {
        public static LegalMove ValidateLegal(this Position source, Move move)
        {
            var analyzedMove = Validate(source, move);
            var legalMove = analyzedMove as LegalMove;
            if (legalMove == null)
                throw new Exception(analyzedMove.Annotations.ToString());
            return legalMove;
        }

        public static AnalyzedMove Validate(this Position source, Move move)
        {
            var whiteKingSquare = source.Core.WhiteKing;
            var blackKingSquare = source.Core.BlackKing;

            var sourceCells = source.Core.Cells;
            var cells = source.Core.GetCopyOfCells();

            MoveAnnotations notes;
            // Piece in the from cell?
            var moveFrom = move.FromCell;
            var piece = (Piece)sourceCells[moveFrom];
            if (piece == Piece.EmptyCell)
            {
                notes = EmptyCell;
                return new IllegalMove(move, source, notes);
            }

            // Side to move?
            var color = piece.Color();
            if (color != source.Core.Turn)
            {
                notes = (MoveAnnotations)piece.PieceType() | WrongSideToMove;
                return new IllegalMove(move, source, notes);
            }

            // Move to occupied cell?
            var moveTo = move.ToCell;
            var toPiece = (Piece)sourceCells[moveTo];
            if (toPiece != Piece.EmptyCell && toPiece.Color() == color)
            {
                notes = (MoveAnnotations)piece.PieceType() | ToOccupiedCell;
                return new IllegalMove(move, source, notes);
            }
            notes = ValidateMove(cells, piece,
                moveFrom, moveTo, toPiece, source.Core.CastlingAvailability);
            if (toPiece != Piece.EmptyCell) notes |= Capture;
            // ---------------- SetupBoard ---------------------
            if ((notes & AllErrors) != 0)
                return new IllegalMove(move, source, notes);
            if ((notes & EnPassant) != 0)
            {
                if (source.Core.EnPassant != moveTo % 16)
                {
                    notes |= HasNoEnPassant;
                    return new IllegalMove(move, source, notes);
                }
            }
            else if ((notes & Promotion) != 0)
            {
                var proposedPromotion = move.PromoteTo;
                if (move.PromoteTo == PieceType.None)
                {
                    notes |= MissingPromotionHint;
                    proposedPromotion = PieceType.Queen;
                }
                piece = proposedPromotion.With(color);
            }
            else if (move.PromoteTo != PieceType.None)
            {
                notes |= PromotionHintIsNotNeeded;
            }

            cells[moveTo] = (byte)piece;

            switch (piece)
            {
                case Piece.WhiteKing:
                    whiteKingSquare = moveTo;
                    break;
                case Piece.BlackKing:
                    blackKingSquare = moveTo;
                    break;
            }

            cells[moveFrom] = 0;
            var enPassantFile = new int?();
            if ((notes & (DoublePush | EnPassant | AllCastlings)) != 0)
            {
                if ((notes & DoublePush) != 0)
                {
                    enPassantFile = moveFrom % 16;
                }
                else if ((notes & EnPassant) != 0)
                {
                    cells[moveTo + (color == Color.White ? -16 : +16)] = 0;
                }
                else
                    switch (notes)
                    {
                        case (King | WK):
                            cells[S.H1] = (byte)Piece.EmptyCell;
                            cells[S.F1] = (byte)Piece.WhiteRook;
                            break;
                        case (King | WQ):
                            cells[S.A1] = (byte)Piece.EmptyCell;
                            cells[S.D1] = (byte)Piece.WhiteRook;
                            break;
                        case (King | BK):
                            cells[S.H8] = (byte)Piece.EmptyCell;
                            cells[S.F8] = (byte)Piece.BlackRook;
                            break;
                        case (King | BQ):
                            cells[S.A8] = (byte)Piece.EmptyCell;
                            cells[S.D8] = (byte)Piece.BlackRook;
                            break;
                    }
            }
            var isUnderCheck = source.Core.Turn == Color.White
                ? cells.IsSquareAttackedByBlack(whiteKingSquare)
                : cells.IsSquareAttackedByWhite(blackKingSquare);

            if (isUnderCheck)
            {
                notes |= MoveToCheck;
            }
            var castlings = source.Core.CastlingAvailability
                            & ~KilledAvailability(moveTo)
                            & ~KilledAvailability(moveFrom);

            // ---------------- ---------- ---------------------
            if ((notes & AllErrors) != 0)
                return new IllegalMove(move, source, notes);

            var positionCore = new PositionCore(
                cells, color.Invert(), castlings, enPassantFile,
                whiteKingSquare, blackKingSquare);
            var legalMove = new LegalMove(
                move, source, positionCore, notes);
            return legalMove;
        }

        private static Castlings KilledAvailability(int touchedSquare)
        {
            switch (touchedSquare)
            {
                case S.A1: return Castlings.WQ;
                case S.E1: return Castlings.White;
                case S.H1: return Castlings.WK;
                case S.A8: return Castlings.BQ;
                case S.E8: return Castlings.Black;
                case S.H8: return Castlings.BK;
                default: return Castlings.None;
            }
        }


        static MoveAnnotations ValidateWhiteCastlingMove(byte[] cells, int fromSquare, int toSquare, Castlings availableCastlings)
        {
            if (fromSquare != S.E1) return King | DoesNotMoveThisWay;
            switch (toSquare)
            {
                case S.C1: // Queenside
                    if (cells[S.D1] != 0 || cells[S.B1] != 0) return King | DoesNotJump | WQ;
                    if (cells[S.C1] != 0) return King | Capture | DoesNotCaptureThisWay | WQ;
                    if ((availableCastlings & Castlings.WQ) == 0) return King | WQ | HasNoCastling;
                    if (cells.IsSquareAttackedByBlack(S.E1)) return King | CastleFromCheck | WQ;
                    if (cells.IsSquareAttackedByBlack(S.D1)) return King | CastleThroughCheck | WQ;
                    return King | WQ;
                case S.G1: // Kingside
                    if (cells[S.F1] != 0) return King | DoesNotJump | WK;
                    if (cells[S.G1] != 0) return King | Capture | DoesNotCaptureThisWay | WK;
                    if ((availableCastlings & Castlings.WK) == 0) return King | WK | HasNoCastling;
                    if (cells.IsSquareAttackedByBlack(S.E1)) return King | CastleFromCheck | WK;
                    if (cells.IsSquareAttackedByBlack(S.F1)) return King | CastleThroughCheck | WK;
                    return King | WK;
            }
            return King | DoesNotMoveThisWay;
        }
        static MoveAnnotations ValidateBlackCastlingMove(byte[] cells, int fromSquare, int toSquare, Castlings availableCastlings)
        {
            if (fromSquare != S.E8) return King | DoesNotMoveThisWay;
            switch (toSquare)
            {
                case S.C8: // Queenside
                    if (cells[S.D8] != 0 || cells[S.B8] != 0) return King | DoesNotJump | BQ;
                    if (cells[S.C8] != 0) return King | Capture | DoesNotCaptureThisWay | BQ;
                    if ((availableCastlings & Castlings.BQ) == 0) return King | BQ | HasNoCastling;
                    if (cells.IsSquareAttackedByWhite(S.E8)) return King | CastleFromCheck | BQ;
                    if (cells.IsSquareAttackedByWhite(S.D8)) return King | CastleThroughCheck | BQ;
                    return King | BQ;
                case S.G8: // Kingside
                    if (cells[S.F8] != 0) return King | DoesNotJump | BK;
                    if (cells[S.G8] != 0) return King | Capture | DoesNotCaptureThisWay | BK;
                    if ((availableCastlings & Castlings.BK) == 0) return King | BK | HasNoCastling;
                    if (cells.IsSquareAttackedByWhite(S.E8)) return King | CastleFromCheck | BK;
                    if (cells.IsSquareAttackedByWhite(S.F8)) return King | CastleThroughCheck | BK;
                    return King | BK;
            }
            return King | DoesNotMoveThisWay;
        }
        static MoveAnnotations ValidateWhitePawnMove(byte[] cells, int fromSquare, int toSquare, Piece capture)
        {
            switch (toSquare - fromSquare)
            {
                case 32:
                    if (fromSquare / 16 != 1) return Pawn | DoesNotMoveThisWay;
                    if (capture != 0) return Pawn | DoesNotCaptureThisWay;
                    return cells[fromSquare + 16] != 0
                             ? Pawn | DoesNotJump : Pawn | DoublePush;
                case 16:
                    if (capture != 0) return Pawn | DoesNotCaptureThisWay;
                    return toSquare / 16 != 7 ? Pawn : Pawn | Promotion;
                case 17:
                case 15:
                    if (capture == Piece.EmptyCell)
                        return (toSquare / 16 == 5)
                            && cells[toSquare] == (byte)None
                            && (cells[toSquare - 16] & (byte)AllPieces) == (byte)Pawn
                          ? Pawn | Capture | EnPassant : Pawn | OnlyCapturesThisWay;
                    return toSquare / 16 != 7 ? Pawn | Capture
                      : Pawn | Promotion | Capture;
                default:
                    return Pawn | DoesNotMoveThisWay;
            }

        }
        static MoveAnnotations ValidateBlackPawnMove(byte[] cells, int fromSquare, int toSquare, Piece capture)
        {
            switch (fromSquare - toSquare)
            {
                case 32:
                    if (fromSquare / 16 != 6) return Pawn | DoesNotMoveThisWay;
                    if (capture != 0) return Pawn | DoesNotCaptureThisWay;
                    return cells[fromSquare - 16] != 0
                             ? Pawn | DoesNotJump : Pawn | DoublePush;
                case 16:
                    if (capture != 0) return Pawn | DoesNotCaptureThisWay;
                    return toSquare / 16 != 0 ? Pawn : Pawn | Promotion;
                case 17:
                case 15:
                    if (capture == Piece.EmptyCell)
                        return (toSquare / 16 == 2)
                            && cells[toSquare] == (byte)None
                            && (cells[toSquare + 16] & (byte)AllPieces) == (byte)Pawn
                          ? Pawn | Capture | EnPassant : Pawn | OnlyCapturesThisWay;
                    return toSquare / 16 != 0
                      ? Pawn | Capture : Pawn | Promotion | Capture;
                default:
                    return Pawn | DoesNotMoveThisWay;
            }
        }
    }
}
