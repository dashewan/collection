using System.ComponentModel;
using Xamarin.Forms;
using Phone.ViewModels;

namespace Phone.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}