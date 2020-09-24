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
    public class MegaViewModel// : ViewModelBase
    {
        public UserControl UserControlForever { get; set; }
        public string NUMBER { get; set; }

        private MyUserControl1 _firstContol { get; set; } = new MyUserControl1();
        private MyUserControl2 _secondContol { get; set; } = new MyUserControl2();
        private MyUserControl3 _thirdContol { get; set; } = new MyUserControl3();

        enum Pages
        {
            First,
            Second,
            Third
        }

        private static Pages ppage { get; set; }

        public async void UpdatePage()
        {
            //var rand = new Random();
            //NUMBER = rand.Next(301).ToString();

            var view = GetControl();

           // await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
           // {
           //     UserControlForever = view;
           //     RaisePropertyChanged(nameof(UserControlForever));
           // });
        }

        public UserControl GetControl()
        {
            switch (ppage)
            {
                case Pages.First:
                    {
                        ppage = Pages.Second;
                        _firstContol.Update();
                        return _firstContol;
                    }
                case Pages.Second:
                    {
                        ppage = Pages.Third;
                        _secondContol.Update();
                        return _secondContol;
                    }
                case Pages.Third:
                    {
                        ppage = Pages.First;
                        _thirdContol.Update();
                        return _thirdContol;
                    }
                default:
                    {
                        ppage = Pages.First;
                        _thirdContol.Update();
                        return _thirdContol;
                    }
            }
        }
    }
}
