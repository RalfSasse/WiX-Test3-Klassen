using WiX_Test3_Klassen.ViewModels;
using System.Windows;

namespace WiX_Test3_Klassen.Views
{
    public partial class InstallView : Window
    {
        public InstallView(InstallViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            this.Closed += (sender, e) => viewModel.CancelCommand.Execute(this);
        }
    }
}