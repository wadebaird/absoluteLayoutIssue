using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AbsoluteLayoutIssue
{
    public class CommonContentPage : ContentPage
    {
        public ViewModel Model = new ViewModel();
        public StackLayout StackLayout { get; set; }

        public CommonContentPage()
        {
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await this.Model.LoadData(this);
        }
    }
}
