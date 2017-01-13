using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GameAnalyzer.Web.Startup))]

namespace GameAnalyzer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Microsoft.AspNet.SignalR.StockTicker.Startup.ConfigureSignalR(app);

            ConfigureAuth(app);
        }
    }
}
