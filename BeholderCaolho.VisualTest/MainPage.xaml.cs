using BeholderCaolho.AttributeManagerLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BeholderCaolho.VisualTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        protected AttributeManager attrManager;

        public MainPage()
        {
            this.InitializeComponent();

            attrManager = new AttributeManager()
                .Add("Str", 10)
                .Add("modStr", 0)
                .SetUpdate("modStr", () => { return (int)((attrManager["Str"] - 10) / 2); })
                .Add("Dex", 10)
                .Add("modDex", 0)
                .SetUpdate("modDex", () => { return (int)((attrManager["Dex"] - 10) / 2); })
                .Add("Con", 10)
                .Add("modCon", 0)
                .SetUpdate("modCon", () => { return (int)((attrManager["Con"] - 10) / 2); })
                .Add("Int", 10)
                .Add("modInt", 0)
                .SetUpdate("modInt", () => { return (int)((attrManager["Int"] - 10) / 2); })
                .Add("Wis", 10)
                .Add("modWis", 0)
                .SetUpdate("modWis", () => { return (int)((attrManager["Wis"] - 10) / 2); })
                .Add("Cha", 10)
                .Add("modCha", 0)
                .SetUpdate("modCha", () => { return (int)((attrManager["Cha"] - 10) / 2); })
                .Add("ArmorClass", 10)
                .SetUpdate("Classe de Armadura", () => 10 + attrManager["modDex"]);
        }
    }
}
