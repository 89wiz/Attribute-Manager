using BeholderCaolho.AttributeManagerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var attrManager = new AttributeManager();
            attrManager
                .Add("Str", 10)
                .Add("modStr", 0)
                .SetUpdate("modStr", () => { return (int)((attrManager["Str"] - 10) / 2); })
                .Add("Dex", 18)
                .Add("modDex", 0)
                .SetUpdate("modDex", () => { return (int)((attrManager["Dex"] - 10) / 2); })
                .Add("Con", 10)
                .Add("modCon", 0)
                .SetUpdate("modCon", () => { return (int)((attrManager["Con"] - 10) / 2); })
                .Add("Int", 14)
                .Add("modInt", 0)
                .SetUpdate("modInt", () => { return (int)((attrManager["Int"] - 10) / 2); })
                .Add("Wis", 16)
                .Add("modWis", 0)
                .SetUpdate("modWis", () => { return (int)((attrManager["Wis"] - 10) / 2); })
                .Add("Cha", 12)
                .Add("modCha", 0)
                .SetUpdate("modCha", () => { return (int)((attrManager["Cha"] - 10) / 2); })
                .Add("ArmorClass", 10)
                .SetUpdate("Classe de Armadura", () => 10 + attrManager["modDex"])
                .UpdateAll();

            Console.WriteLine("Str:\t{0}\t{1}", attrManager["Str"], attrManager["modStr"]);
            Console.WriteLine("Dex:\t{0}\t{1}", attrManager["Dex"], attrManager["modDex"]);
            Console.WriteLine("Con:\t{0}\t{1}", attrManager["Con"], attrManager["modCon"]);
            Console.WriteLine("Int:\t{0}\t{1}", attrManager["Int"], attrManager["modInt"]);
            Console.WriteLine("Wis:\t{0}\t{1}", attrManager["Wis"], attrManager["modWis"]);
            Console.WriteLine("Cha:\t{0}\t{1}", attrManager["Cha"], attrManager["modCha"]);

            Console.ReadKey();
        }
    }
}
