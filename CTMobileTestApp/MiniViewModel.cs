using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace CTMobileTestApp
{
    public class MiniViewModel //: ViewModelBase
    {
        public UserControl UserControlForever { get; set; }
        public string NUMBER { get; set; }

        public async void UpdatePage()
        {
            var rand = new Random();
            NUMBER = rand.Next(301).ToString();

            //var view = new MyUserControl1();

            //await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            //    //UserControlForever = view;
            //    RaisePropertyChanged(nameof(NUMBER));
            //});
        }
    }
}
