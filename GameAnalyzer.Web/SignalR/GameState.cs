using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ChessKit.ChessLogic;
using ChessKit.ChessLogic.Algorithms;
using GameAnalyzer.Lib;
using Microsoft.AspNet.SignalR.Hubs;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    public class GameState
    {
        // Singleton instance
        private readonly static Lazy<GameState> _instance = new Lazy<GameState>(
            () => new GameState(GlobalHost.ConnectionManager.GetHubContext<GameStateHub>().Clients));

        private const string START_POSITION = @"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        private Position position;

        private Stockfish stockfish;

        private GameState(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            position = Fen.ParseFen(START_POSITION);

            stockfish = new Stockfish();

        }

        public static GameState Instance => _instance.Value;

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public string MakeComputerMove(string move)
        {
            move = move.Insert(2, "-");

            var m = ChessKit.ChessLogic.Move.Parse(move);

            var m2 = position.ValidateLegal(m);

            allMoves.Add(move);

            position = m2.ToPosition();

            return position.PrintFen();
        }

        private readonly List<string> allMoves = new List<string>();

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