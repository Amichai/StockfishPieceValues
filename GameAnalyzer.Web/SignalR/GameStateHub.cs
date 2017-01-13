using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Stock> GetAllStocks()
        {
            return _gameState.GetAllStocks();
        }

        public string GetMarketState()
        {
            return _gameState.MarketState.ToString();
        }

        public void OpenMarket()
        {
            _gameState.OpenMarket();
        }

        public void CloseMarket()
        {
            _gameState.CloseMarket();
        }

        public void Reset()
        {
            _gameState.Reset();
        }

        public void Submit(string move)
        {
            
        }
    }
}