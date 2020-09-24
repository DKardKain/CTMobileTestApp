using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CTMobileTestApp
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class MyUserControl1 : Page
    {
        //public MiniViewModel ViewModel { get; set; }

        public MyUserControl1()
        {
            //ViewModel = new MiniViewModel();
            this.InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    ViewModel.UpdatePage();
        //}

        public void Update()
        {
            var rand = new Random();
            //NUMBER = rand.Next(301).ToString();

            TextBlockNumber.Text = rand.Next(101).ToString();
        }
    }
}
