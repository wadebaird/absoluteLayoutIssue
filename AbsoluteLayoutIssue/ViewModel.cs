using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbsoluteLayoutIssue
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                this._isBusy = value;
                OnPropertyChanged();
            }
        }

        public void SetIsBusy() => this.IsBusy = true;
        public void ClearIsBusy() => this.IsBusy = false;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task LoadData(CommonContentPage page)
        {
            this.SetIsBusy();

            await Task.Delay(2000);

            for (int i = 0; i < 100; i++)
            {
                var button = new Button()
                {
                    Text = $"Button {i}",
                    HorizontalOptions = LayoutOptions.Center,
                };

                Frame frame = new Frame
                {
                    Padding = new Thickness(2d),
                    Content = button
                };

                page.StackLayout.Children.Add(frame);
            }

            this.ClearIsBusy();
        }
    }
}
