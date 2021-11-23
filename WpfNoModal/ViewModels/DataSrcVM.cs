using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfNoModal.Views;

namespace WpfNoModal {

    public class DataSrcVM : ViewModelBase {

        private string data;
        public string Data { get => data; set { SetProperty(ref data, value); } }

        public ICommand OpenDialogCommand => Commands.GetOrCreateCommand(OpenDialog);
        public ICommand CloseDialogCommand => Commands.GetOrCreateCommand(CloseDialog);

        //private string ReturnData() => Data;

        private void OpenDialog(object _) {
            var wnd = new Dialog(this);
            wnd.Show();
            //wnd.Closed += (_, _) => ReturnData();
            //GetDataCommand.Execute(_);
        }

        private void CloseDialog(object _) {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)?.Close();
        }

        //public string GetData() {
        //    OpenDialog(null);
        //    return Data;
        //}

        //public ICommand GetDataCommand => new RelayCommand((_) => {
        //        var ds = new SomeSource { VM = this };
        //        Data = ds.GetData();
        //    });
    }
}
