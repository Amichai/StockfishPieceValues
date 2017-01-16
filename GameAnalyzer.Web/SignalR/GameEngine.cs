using System;
using System.Collections.Generic;
using System.Linq;
using ChessKit.ChessLogic;
using ChessKit.ChessLogic.Algorithms;
using GameAnalyzer.Lib;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    internal sealed class GameEngine
    {
        private readonly Stockfish stockfish;

        public string ConnectionId { get; }

        private const string START_POSITION = @"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        private Position position;

        public GameEngine()
        {
            position = Fen.ParseFen(START_POSITION);

            stockfish = new Stockfish();
        }

        private readonly List<string> allMoves = new List<string>();


        public string MakeComputerMove(string move)
        {
            move = move.Insert(2, "-");

            var m = ChessKit.ChessLogic.Move.Parse(move);

            var m2 = position.ValidateLegal(m);

            allMoves.Add(move);

            position = m2.ToPosition();

            return position.PrintFen();
        }

        public string GetLastMove()
        {
            return allMoves.Last();
        }

        public string Move(string move)
        {
            try
            {
                var legalMove = position.ParseMoveFromSan(move);

                allMoves.Add(move);

                position = legalMove.ToPosition();
            }
            catch (NullReferenceException)
            {
                return "";
            }

            return position.PrintFen();
        }

        public void Reset()
        {
            position = START_POSITION.ParseFen();
        }

        public string GetComputerMove()
        {
            return stockfish.GetBestMove(position);
        }

        public string GetPosition()
        {
            return position.PrintFen();
        }

        public string GetEval()
        {
            int mate;
            var val = stockfish.AnalyzePosition(position, out mate);

            if (mate != -1)
            {
                return "#" + mate;
            }

            return val.ToString();
        }

        public List<double> GetPieceEvals()
        {
            return stockfish.DeterminePieceValues(position);
        }
    }
}