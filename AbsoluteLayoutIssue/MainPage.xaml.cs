using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbsoluteLayoutIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ModeledButton_OnTap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbsoluteLayoutModeled());
        }

        private async void ProgrammaticButton_OnTap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbsoluteLayoutProgrammatic());
        }
    }
}
