using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameAnalyzer.Web.Controllers
{
    public class AnalysisController : Controller
    {
        // GET: Analysis
        public ActionResult Index(string id)
        {
            return View(id);
        }
    }
}