using RecipesPlan.Presentation.Modules.Internet.ViewModel;

namespace RecipesPlan.Presentation.Modules.Internet.View;

public partial class RecipesPage : ContentPage
{

    public RecipesPage(RecipesPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OpenCloseFilter(object sender, EventArgs e)
    {
        if (GroupFilters.IsVisible)
            GroupFilters.IsVisible = false;
        else
            GroupFilters.IsVisible = true;
    }

}