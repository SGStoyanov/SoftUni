using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCCatalog
{
    class PCCatalogClass
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

            Component mboardAsus = new Motherboard("ASUS p67le", 323.52m);
            Component mboardMSI = new Motherboard("MSI Z51 Pro", 289.90m, "not bad motherboard");

            Component gf560Ti = new GraphicsCard("Nvidia GeForce GTX 560 Ti", 400m, "Pretty good video card");
            Component radR9290 = new GraphicsCard("Sapphire ATI Radeon R9 290", 800m, "4 GB own memory!");

            Component intelI5 = new Processor("Intel i5 3920", 250m);
            Component amdOptX4 = new Processor("AMD Opteron X4", 180m, "2.2 GHz per core");

            Computer compAsusRadeonIntel = new Computer("Monster Machine", new List<Component>() { mboardAsus, radR9290, intelI5 });
            Computer compNvidiaMsiAmd = new Computer("A Good PC");

            compNvidiaMsiAmd.Components.Add(mboardMSI);
            compNvidiaMsiAmd.Components.Add(gf560Ti);
            compNvidiaMsiAmd.Components.Add(amdOptX4);

            List<Computer> computers = new List<Computer>() { compAsusRadeonIntel, compNvidiaMsiAmd };

            computers.OrderBy(c=>c.Price).ToList().ForEach(c => Console.WriteLine(c.ToString()));
            
        }
    }
}