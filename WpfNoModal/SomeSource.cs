using WpfNoModal.Views;

namespace WpfNoModal {

    public class SomeSource {
        /// <summary>
        /// Задачу не удалось выполнить - ниже нерабочий код
        /// </summary>

        public DataSrcVM VM;

        private void ReturnData() { }

        private void OpenDialog(object _) {
            var wnd = new Dialog(VM);
            wnd.Show();
            wnd.Closed += (_, _) => ReturnData();
        }

        public string GetData() {
            OpenDialog(null);
            return VM.Data;
        }
    }
}
