using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbsoluteLayoutIssue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbsoluteLayoutProgrammatic : CommonContentPage
    {
		public AbsoluteLayoutProgrammatic ()
		{
            InitializeComponent();

            this.StackLayout = this.MainPageStackLayout;
            this.BindingContext = this.Model;

            this.AddActivityIndicator();
		}

        public void AddActivityIndicator()
        {
            var content = this.Content;
            var overlay = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var activityIndicator = new ActivityIndicator
            {
                IsEnabled = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //Use the same color as the school text color as it should contrast the background the same.
                Color = Color.Black,
            };

            var activityMessage = new Label
            {
                IsEnabled = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                Text = "Loading...",
            };

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(activityIndicator);
            stackLayout.Children.Add(activityMessage);

            activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, nameof(ViewModel.IsBusy));
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(ViewModel.IsBusy));
            activityMessage.SetBinding(Label.IsVisibleProperty, nameof(ViewModel.IsBusy));

            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, 1, 1));
            //AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            overlay.Children.Add(content);
            overlay.Children.Add(stackLayout);

            stackLayout.IsVisible = true;

            this.Content = overlay;
        }
    }
}