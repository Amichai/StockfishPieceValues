using ChessKit.ChessLogic;
using GameAnalyzer.Lib;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    internal sealed class GameEngine
    {
        public Position Position { get; }

        public Stockfish Stockfish { get; }

        public string ConnectionId { get; }

        private const string START_POSITION = @"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

    }
}