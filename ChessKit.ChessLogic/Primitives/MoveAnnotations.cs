using System;

namespace ChessKit.ChessLogic.Primitives
{
    [Flags]
    internal enum MoveAnnotations
    {
        None = 0,

        Black = Color.Black,

        Pawn = PieceType.Pawn,
        Bishop = PieceType.Bishop,
        Knight = PieceType.Knight,
        Rook = PieceType.Rook,
        Queen = PieceType.Queen,
        King = PieceType.King,
        AllPieces = PieceType.All,

        BK = Castlings.BK,
        BQ = Castlings.BQ,
        WK = Castlings.WK,
        WQ = Castlings.WQ,
        AllCastlings = Castlings.All,

        Promotion = MoveInfo.Promotion,
        Capture = MoveInfo.Capture,
        EnPassant = MoveInfo.EnPassant,
        DoublePush = MoveInfo.DoublePush,
        AllInfos = MoveInfo.All,

        MoveToCheck = MoveErrors.MoveToCheck,
        EmptyCell = MoveErrors.EmptyCell,
        WrongSideToMove = MoveErrors.WrongSideToMove,
        HasNoCastling = MoveErrors.HasNoCastling,
        ToOccupiedCell = MoveErrors.ToOccupiedCell,
        HasNoEnPassant = MoveErrors.HasNoEnPassant,
        DoesNotJump = MoveErrors.DoesNotJump,
        OnlyCapturesThisWay = MoveErrors.OnlyCapturesThisWay,
        DoesNotCaptureThisWay = MoveErrors.DoesNotCaptureThisWay,
        CastleThroughCheck = MoveErrors.CastleThroughCheck,
        DoesNotMoveThisWay = MoveErrors.DoesNotMoveThisWay,
        CastleFromCheck = MoveErrors.CastleFromCheck,
        AllErrors = MoveErrors.All,

        MissingPromotionHint = MoveWarnings.MissingPromotionHint,
        PromotionHintIsNotNeeded = MoveWarnings.PromotionHintIsNotNeeded,
        AllWarnings = MoveWarnings.All,
    }
}
