using AlbionHelper.Common;
using AlbionHelper.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
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

            // 테스트
            InitMainWindowData();


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

        private async void InitMainWindowData()
        {
            var result = await ItemController.GetItemListFromJsonAsync().ConfigureAwait(true);
            var items = ItemController.Items;
            // 가방
            var bag_List = items.Where(g => g.UniqueName.Contains("_BAG")
                            && !g.UniqueName.Contains("ARTEFACT")
                            && g.Tier > -1).ToList();
            // 머리
            var head_List = items.Where(g=> g.UniqueName.Contains("HEAD") 
                                        && !g.UniqueName.Contains("ARTEFACT")
                                        && g.Tier > -1).ToList();
            // 망토
            var cape_List = items.Where(g => g.UniqueName.Contains("CAPEITEM")
                                        && !g.UniqueName.Contains("ARTEFACT")
                                        && g.Tier > -1).ToList();

            // 한손
            var onehand_List = items.Where(g => g.UniqueName.Contains("_MAIN_")
                            && !g.UniqueName.Contains("ARTEFACT")
                            && g.Tier > -1).ToList();
            // 양손
            var twohand_List = items.Where(g => g.UniqueName.Contains("_2H_")
                && !g.UniqueName.Contains("ARTEFACT")
                && g.Tier > -1).ToList();

            // 보조
            var offhand_List = items.Where(g => g.UniqueName.Contains("_OFF_")
                && !g.UniqueName.Contains("ARTEFACT")
                && g.Tier > -1).ToList();
        }
    }
}
