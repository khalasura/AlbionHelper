using AlbionHelper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AlbionHelper.Models
{
    public class Item
    {
        public string LocalizationNameVariable { get; set; }
        public string LocalizationDescriptionVariable { get; set; }
        public LocalizedNames LocalizedNames { get; set; }
        public int Index { get; set; }
        public string UniqueName { get; set; }


        public string LocalizedNameAndEnglish =>
            LanguageController.CurrentCultureInfo.TextInfo.CultureName.ToUpper() == "EN-US"
                ? ItemController.LocalizedName(LocalizedNames, null, UniqueName)
                : $"{ItemController.LocalizedName(LocalizedNames, null, UniqueName)}\n{ItemController.LocalizedName(LocalizedNames, "EN-US", string.Empty)}";

        public string LocalizedName => ItemController.LocalizedName(LocalizedNames, null, UniqueName);

        public int Level => ItemController.GetItemLevel(UniqueName);
        public int Tier => ItemController.GetItemTier(this);

        private BitmapImage _icon;
        public BitmapImage Icon => _icon ?? (_icon = ImageController.GetItemImage(UniqueName));

        public BitmapImage ExistFullItemInformationLocal => ItemController.ExistFullItemInformationLocal(UniqueName);
        public ItemInformation FullItemInformation { get; set; }
    }
}
