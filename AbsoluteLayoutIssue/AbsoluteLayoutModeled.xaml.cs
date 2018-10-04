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
	public partial class AbsoluteLayoutModeled : CommonContentPage
	{
		public AbsoluteLayoutModeled ()
		{
            InitializeComponent();
            this.StackLayout = this.MainPageStackLayout;
            this.BindingContext = this.Model;
        }
    }
}