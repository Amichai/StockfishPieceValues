using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using ChessKit.ChessLogic;
using ChessKit.ChessLogic.Algorithms;
using ChessKit.ChessLogic.Primitives;
using ProcessHost = RunProcess.ProcessHost;

namespace GameAnalyzer.Lib
{
    public sealed class Stockfish
    {
        private readonly ProcessHost process;

        public Stockfish()
        {
            process = new ProcessHost(HostingEnvironment.MapPath("~/App_Data/stockfish-6-64.exe"), null);
            process.Start();
            process.StdIn.WriteLine(Encoding.ASCII, "uci");
            string output = process.StdOut.ReadAllText(Encoding.ASCII);
            Debug.Print(output);
            //process.StdIn.WriteLine(Encoding.ASCII, "debug on");
            output = process.StdOut.ReadAllText(Encoding.ASCII);
            Debug.Print(output);
        }

        private void WaitUntilReady()
        {
            process.StdIn.WriteLine(Encoding.ASCII, "isready");
            while (true)
            {
                var result = process.StdOut.ReadAllText(Encoding.ASCII);
                var r = result.Split('\n');
                if (r.Any(i => i.Contains("readyok")))
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private string WaitForMove()
        {
            while (true)
            {
                var result = process.StdOut.ReadAllText(Encoding.ASCII);
                var r = result.Split('\n');
                if (r.Any(i => i.Contains("bestmove")))
                {
                    return result;
                }
                Thread.Sleep(100);
            }
        }

        public string GetBestMove(Position positionState)
        {
            var position = positionState.PrintFen();
            WaitUntilReady();
            process.StdIn.WriteLine(Encoding.ASCII, "ucinewgame");
            WaitUntilReady();

            process.StdIn.WriteLine(Encoding.ASCII, "position fen " + position);
            process.StdIn.WriteLine(Encoding.ASCII, "go depth 10");
            var output = WaitForMove();
            var outputLines = output.Split('\n');

            return outputLines.First(i => i.Split(' ').First() == "bestmove").Split(' ')[1];
        }

        public double AnalyzePosition(Position positionState, out int mate)
        {
            var position = positionState.PrintFen();
            WaitUntilReady();
            process.StdIn.WriteLine(Encoding.ASCII, "ucinewgame");
            WaitUntilReady();

            process.StdIn.WriteLine(Encoding.ASCII, "position fen " + position);
            process.StdIn.WriteLine(Encoding.ASCII, "go depth 10");
            var output = WaitForMove();
            var outputLines = output.Split('\n');
            var lastLine = outputLines.Last(i => i.StartsWith("info"));
            //var error = process.StdErr.ReadAllText(Encoding.ASCII);
            var eval = int.Parse(lastLine.Split(' ')[9]) / 100.0;
            //var move = outputLines.Last(i => i.StartsWith("bestmove")).Split(' ')[1];
            mate = -1;
            var parts = lastLine.Split(' ');
            var index = parts.IndexOf("mate");
            if (index != -1)
            {
                mate = int.Parse(parts[index + 1]);
            }

            return eval * (positionState.Core.Turn == Color.White ? 1 : -1);
        }

        private IEnumerable<string> GetAdjustedFENs(string fen)
        {
            var c = ' ';

            for (var i = 0; i < fen.Length; i++)
            {
                var a = fen[i];

                if (a == '/' || char.IsDigit(a) || a == 'k' || a == 'K')
                {
                    continue;
                }

                if (a == ' ')
                {
                    yield break;
                }

                var b = fen[i + 1];

                if (i > 0)
                {
                    c = fen[i - 1];
                }

                if (char.IsDigit(b) && char.IsDigit(c))
                {
                    var s = int.Parse(b.ToString()) + int.Parse(c.ToString()) + 1;
                    yield return fen.Substring(0, i - 1) + s + fen.Substring(i + 2);
                }
                else if (char.IsDigit(b))
                {
                    var s = int.Parse(b.ToString()) + 1;
                    yield return fen.Substring(0, i) + s + fen.Substring(i + 2);
                }
                else if (char.IsDigit(c))
                {
                    var s = int.Parse(c.ToString()) + 1;
                    yield return fen.Substring(0, i - 1) + s + fen.Substring(i + 1);
                }
                else
                {
                    yield return fen.Substring(0, i) + "1" + fen.Substring(i + 1);
                }
            }
        }

        public List<double> DeterminePieceValues(Position position)
        {
            int mate;
            var initialEval = AnalyzePosition(position, out mate);

            if (mate != -1)
            {
                return new List<double>();
            }

            var toReturn = Enumerable.Range(0, 64).Select(i => 0d).ToList();

            var originalCells = position.Core.GetCopyOfCells();

            //"rnbqkbnr/pppppppp/8/8/3P4/8/PPP1PPPP/RNBQKBNR b KQkq d3 0 1"
            var fen = Fen.PrintFen(position);

            foreach (var adjustedFeN in GetAdjustedFENs(fen))
            {
                Debug.Print(adjustedFeN);

                var adjustedPosition = Fen.ParseFen(adjustedFeN);

                var eval = AnalyzePosition(adjustedPosition, out mate);

                var newCells = adjustedPosition.Core.GetCopyOfCells();

                var pieceVal = mate == -1 ? eval - initialEval : -1;

                for (var i = 0; i < 128; i++)
                {
                    if (originalCells[i] != newCells[i])
                    {
                        Debug.Print(i.ToString());

                        var a = i / 16;
                        var b = i % 16;
                        var c = a*8 + b;
                        Debug.Print($"{a}, {b}, {c}");

                        toReturn[c] = Math.Round(Math.Abs(pieceVal), 2);

                        break;
                    }
                }

                Debug.Print($"Eval diff: {pieceVal}");

            }

            return toReturn;
        }
    }
}
