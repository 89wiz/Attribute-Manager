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
                .Add("Força", 10)
                .Add("Destreza", 18)
                .Add("Constituição", 10)
                .Add("Inteligência", 16)
                .Add("Sabedoria", 14)
                .Add("Carisma", 12)
                .Add("Classe de Armadura", 10)
                .SetUpdate("Classe de Armadura", () => 10 + attrManager["modDex"]);
        }
    }
}
