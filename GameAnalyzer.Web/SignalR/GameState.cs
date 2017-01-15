using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static GameState Instance
        {
            get
            {
                return _instance.Value;
            }
        }

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

            position = m2.ToPosition();

            return position.PrintFen();
        }

        public string Move(string move)
        {
            try
            {
                position = position.MakeMove(move);
            }
            catch (NullReferenceException)
            {
                Debug.Print($"Error making move: {move}");
            }

            return position.PrintFen();
        }

        public void Reset()
        {
            position = Fen.ParseFen(START_POSITION);
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
    }

}