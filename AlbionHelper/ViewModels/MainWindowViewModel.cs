using Prism.Mvvm;

namespace AlbionHelper.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Albion Helper ver 1.0";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
