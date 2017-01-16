using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNet.SignalR.Hubs;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    [HubName("gameState")]
    public class GameStateHub : Hub
    {
        private readonly GameState _gameState;

        public GameStateHub() :
            this(GameState.Instance)
        {
        }

        public GameStateHub(GameState gameState)
        {
            _gameState = gameState;
        }

        public string Move(string move, string connectionId)
        {
            return _gameState.Move(move, connectionId);
        }

        public void Reset(string connectionId)
        {
            _gameState.Reset(connectionId);
        }

        public string GetComputerMove(string connectionId)
        {
            var move = _gameState.GetComputerMove(connectionId);

            return _gameState.MakeComputerMove(move, connectionId);
        }

        public string GetPosition(string connectionId)
        {
            return _gameState.GetPosition(connectionId);
        }

        public string GetEval(string connectionId)
        {
            return _gameState.GetEval(connectionId);
        }

        public string GetLastMove(string connectionId)
        {
            return _gameState.GetLastMove(connectionId);
        }

        public List<double> GetPieceEvals(string connectionId)
        {
            return _gameState.GetPieceEvals(connectionId);
        }
    }
}