using CommunityToolkit.Maui.Views;
using RecipesPlan.Core.Entities;
using System.Collections.ObjectModel;

namespace RecipesPlan.Presentation.Popups;

public partial class RecipeInfoPopup : Popup
{
    public RecipeInfoPopup(RecipeEntity recipeEntity = null)
    {
        InitializeComponent();
        BindingContext = new RecipeInfoVM(recipeEntity);

    }



    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close(null);
    }
    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (LabelInfo.Text == "")
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(new StandartPopup("The label cannot\nbe empty"));
        }
        else
        {
            Close(((RecipeInfoVM)BindingContext).RecipeEntity);
        }
    }

}