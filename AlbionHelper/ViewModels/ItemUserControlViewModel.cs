using AlbionHelper.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace AlbionHelper.ViewModels
{
    public class ItemUserControlViewModel : BindableBase
    {
        private BitmapImage icon;
        public BitmapImage Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }
        public ItemUserControlViewModel()
        {
            SetItem("T6_2H_CLAWPAIR@1");
        }

        public void SetItem(string item)
        {
            Icon = ImageController.GetItemImage(item);
        }
    }
}
