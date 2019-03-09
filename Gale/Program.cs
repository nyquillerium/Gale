using System;
using Gale.VisualTests;
using osu.Framework;
using osu.Framework.Platform;

namespace Gale
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
#if VISUALTESTS
            using (Game game = new VisualTestRunner())
#else
            using (Game game = new GaleGame())
#endif
            using (GameHost host = Host.GetSuitableHost(@"Gale"))
                host.Run(game);
        }
    }
}