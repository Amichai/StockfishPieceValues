using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChessKit.ChessLogic.Primitives;
using MoreLinq;

namespace ChessKit.ChessLogic.Algorithms
{
    public static class EndGame
    {
        public static IEnumerable<Position> GetHistory(this Position position)
        {
            return new HistoryEnumerable(position);
        }

        public static Position ToPosition(this LegalMove legalMove)
        {
            var core = legalMove.ResultPosition;
            var prev = legalMove.OriginalPosition;
            var piece = legalMove.Piece;
            var obs = legalMove.Annotations;
            var color = prev.Core.Turn;
            var tempPosition = new Position(core, 0, 0, 0, legalMove);

            var newHalfMoveClock =
                piece == PieceType.Pawn || (obs & MoveAnnotations.Capture) != 0
                    ? 0
                    : prev.FiftyMovesClock + 1;

            var newMoveNumber =
                prev.MoveNumber + (color == Color.Black ? 1 : 0);

            var isCheck = core.IsInCheck(core.Turn);
            var noMoves = tempPosition.GetAllLegalMoves().Count == 0;

            var newState = default(GameStates);
            if (isCheck && noMoves) newState |= GameStates.Mate;
            if (isCheck && !noMoves) newState |= GameStates.Check;
            if (!isCheck && noMoves) newState |= GameStates.Stalemate;
            if (newHalfMoveClock >= 50) newState |= GameStates.FiftyMoveRule;

            var isRepetition = tempPosition.GetHistory()
                .Prepend(tempPosition)
                .Select(p => p.Core)
                .CountBy()
                .MaxBy(x => x.Value).Value > 2;
            if (isRepetition) newState |= GameStates.Repetition;

            return new Position(core, newHalfMoveClock,
                newMoveNumber, newState, legalMove);
        }


        sealed class HistoryEnumerable : IEnumerable<Position>
        {
            private readonly Position _position;

            public HistoryEnumerable(Position position)
            {
                _position = position;
            }

            public IEnumerator<Position> GetEnumerator()
                => new HistoryEnumerator(_position);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        sealed class HistoryEnumerator : IEnumerator<Position>
        {
            public HistoryEnumerator(Position position)
            {
                Current = position;
            }

            public bool MoveNext()
            {
                Current = Current?.Move?.OriginalPosition;
                return Current != null;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public Position Current { get; private set; }
            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        private static Dictionary<T, int> CountBy<T>(this IEnumerable<T> source)
        {
            var res = new Dictionary<T, int>();
            foreach (var item in source)
            {
                int counter;
                if (res.TryGetValue(item, out counter))
                   res[item] = counter + 1;
                else
                    res.Add(item, 1);
            }
            return res;
        }
    }
}
