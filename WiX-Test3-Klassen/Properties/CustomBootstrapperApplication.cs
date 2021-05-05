using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WiX_Test3_Klassen.Models;
using WiX_Test3_Klassen.ViewModels;
using WiX_Test3_Klassen.Views;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Windows.Threading;

namespace WiX_Test3_Klassen
{
    public class CustomBootstrapperApplication :
    BootstrapperApplication
    {
        public static Dispatcher Dispatcher { get; set; }
        protected override void Run()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            var model = new BootstrapperApplicationModel(this);
            var viewModel = new InstallViewModel(model);
            var view = new InstallView(viewModel);
            model.SetWindowHandle(view);

            this.Engine.Detect();   // Prüfen, ob Bundle bereits installiert ist

            view.Show();            // Dialogfenster anzeigen
            Dispatcher.Run();       // Warteschleife für Ereignisse

            this.Engine.Quit(model.FinalResult);
        }
    }
}

