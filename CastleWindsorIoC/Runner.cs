using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorIoC
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            // Install dependencies
            var installer = new Installer();
            var container = installer.Install();

            var logger = container.Resolve<Logger>();

            logger.DisplayMessage(); // Takes the first registration when multiple registration are present.

            Console.ReadKey();
        }
    }
}
