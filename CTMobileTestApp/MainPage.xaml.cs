using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CTMobileTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       // private MegaViewModel _viewModel { get; set; } = new MegaViewModel();

        private bool navigateForvard = true;
        private bool firstNavigate = true;
        private Stopwatch watch = new Stopwatch();
        MyUserControl1 userControl1 = new MyUserControl1();
        MyUserControl2 userControl2 = new MyUserControl2();
        MyUserControl3 userControl3 = new MyUserControl3();


        public MainPage()
        {
            this.InitializeComponent();

            watch.Reset();
        }

        enum Pages
        {
            First,
            Second,
            Third
        }

        private static Pages ppage { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (watch.IsRunning)
            {
                if (watch.ElapsedMilliseconds < 1000)
                {
                    return;
                }
                else
                {
                    watch.Restart();
                }
            }
            else
            {
                watch.Start();
            }
            if (sender is Button buutton)
            {
                buutton.IsEnabled = false;
            }



            if (firstNavigate)
            {
                //SuperContentControl.Children.Clear();

                switch (ppage)
                {
                    case Pages.First:
                        {
                            ppage = Pages.Second;
                            //SuperContentControl.Children.Add(userControl1);
                            SuperContentControl.Navigate(typeof(MyUserControl1));
                            break;
                        }
                    case Pages.Second:
                        {
                            ppage = Pages.Third;
                            //SuperContentControl.Children.Add(userControl2);
                            SuperContentControl.Navigate(typeof(MyUserControl2));
                            break;
                        }
                    case Pages.Third:
                        {
                            ppage = Pages.First;
                            //SuperContentControl.Children.Add(userControl3);
                            SuperContentControl.Navigate(typeof(MyUserControl3));
                            firstNavigate = false;
                            navigateForvard = false;
                            break;
                        }
                }
            }
            else
            {
                if (navigateForvard)
                {
                    if (SuperContentControl.ForwardStack.Count() > 0)
                    {
                        SuperContentControl.GoForward();
                    }
                
                    if (SuperContentControl.ForwardStack.Count() == 0)
                    {
                        navigateForvard = false;
                    }
                }
                else 
                {
                    if (SuperContentControl.BackStack.Count() > 0)
                    {
                        SuperContentControl.GoBack();
                    }
                
                    if (SuperContentControl.BackStack.Count() == 0)
                    {
                        navigateForvard = true;
                    }
                }
            }
                //_viewModel.UpdatePage();
                //SuperContentControl.Content = _viewModel.GetControl();
            }

        private void SuperContentControl_Navigated(object sender, NavigationEventArgs e)
        {
           SuperButton.IsEnabled = true;
        }

        private void SuperContentControl_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            SuperButton.IsEnabled = false;
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //
        //    //SuperContentControl.DataContext = _viewModel;
        //   // SuperContentControl.Content = _viewModel.GetControl();
        //}
    }
}
