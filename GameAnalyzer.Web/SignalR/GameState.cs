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

        private ConcurrentDictionary<string, GameEngine> engines = new ConcurrentDictionary<string, GameEngine>();

        private GameState(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        public static GameState Instance => _instance.Value;

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private GameEngine GetGameEngine(string connectionId)
        {
            GameEngine engine;
            if (!engines.TryGetValue(connectionId, out engine))
            {
                engine = new GameEngine();
                if (!engines.TryAdd(connectionId, engine))
                {
                }
            }

            return engine;
        }

        public string MakeComputerMove(string move, string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.MakeComputerMove(move);
        }

        public string GetLastMove(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.GetLastMove();
        }

        public string Move(string move, string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.Move(move);
        }

        public void Reset(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            engine.Reset();
        }

        public string GetComputerMove(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.GetComputerMove();
        }

        public string GetPosition(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.GetPosition();
        }

        public string GetEval(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.GetEval();
        }


        public List<double> GetPieceEvals(string connectionId)
        {
            var engine = GetGameEngine(connectionId);

            return engine.GetPieceEvals();
        }
    }
}