using MVVM_XML_RS.Infrastructure.Commands.Base;
using System.Windows;

namespace MVVM_XML_RS.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
