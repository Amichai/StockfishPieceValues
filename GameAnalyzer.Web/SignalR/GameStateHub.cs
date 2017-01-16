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

        public string Move(string move)
        {
            return _gameState.Move(move);
        }

        public void Reset()
        {
            _gameState.Reset();
        }

        public string GetComputerMove()
        {
            var move = _gameState.GetComputerMove();

            return _gameState.MakeComputerMove(move);
        }

        public string GetPosition()
        {
            return _gameState.GetPosition();
        }

        public string GetEval()
        {
            return _gameState.GetEval();
        }

        public string GetLastMove()
        {
            return _gameState.GetLastMove();
        }

        public List<double> GetPieceEvals()
        {
            return _gameState.GetPieceEvals();
        }
    }
}