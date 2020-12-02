using AlbionHelper.Common;
using AlbionHelper.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;

namespace AlbionHelper.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private MainWindow mainCtrl;
        private bool IsLanguageFileLoaded;

        private string _title = "Albion Helper ver 1.0";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // 테스트
        private Dictionary<ParentCategory, string> itemParentCategories;
        public Dictionary<ParentCategory, string> ItemParentCategories
        {
            get { return itemParentCategories; }
            set { SetProperty(ref itemParentCategories, value); }
        }

        private ParentCategory selectedItemParentCategory;
        public ParentCategory SelectedItemParentCategory
        {
            get { return selectedItemParentCategory; }
            set 
            {
                SetProperty(ref selectedItemParentCategory, value);
                ItemCategories = CategoryController.GetCategoriesByParentCategory(SelectedItemParentCategory);
                SelectedItemCategory = Category.Unknown;
            }
        }

        private Dictionary<Category, string> itemCategories;
        public Dictionary<Category, string> ItemCategories
        {
            get { return itemCategories; }
            set { SetProperty(ref itemCategories, value); }
        }

        private Category selectedItemCategory;
        public Category SelectedItemCategory
        {
            get { return selectedItemCategory; }
            set { SetProperty(ref selectedItemCategory, value); }
        }

        // [ctor] 생성자
        public MainWindowViewModel()
        {
            IsLanguageFileLoaded = LanguageController.InitializeLanguage();
        }

        // [Command] 뷰 로드
        private DelegateCommand<RoutedEventArgs> loadedCommand;
        public DelegateCommand<RoutedEventArgs> LoadedCommand =>
            loadedCommand ?? (loadedCommand = new DelegateCommand<RoutedEventArgs>((e) =>
            {
                if (mainCtrl == null)
                {
                    mainCtrl = e.Source as MainWindow;
                    if (!IsLanguageFileLoaded)
                        mainCtrl.Close();
                    ItemParentCategories = CategoryController.ParentCategoryNames;

                }
            }));
    }
}
