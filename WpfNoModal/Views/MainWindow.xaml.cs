using System.Windows;

namespace WpfNoModal.Views {

    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();

            DataContext = new DataSrcVM();
        }
    }
}
