using System.Windows;

namespace WpfNoModal.Views {

    public partial class Dialog : Window {

        public Dialog() {
            InitializeComponent();
        }

        public Dialog(DataSrcVM vm) : this() {
            DataContext = vm;
        }
    }
}
