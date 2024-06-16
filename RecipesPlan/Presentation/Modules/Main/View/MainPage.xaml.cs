using RecipesPlan.Presentation.Modules.Main.ViewModel;
using System.Diagnostics;

namespace RecipesPlan.Presentation.Modules.Main.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageVM mainPageVM)
        {
            InitializeComponent();
            BindingContext = mainPageVM;

        }
    }

}
