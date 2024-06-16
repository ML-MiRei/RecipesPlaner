using CommunityToolkit.Maui.Views;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace RecipesPlan.Presentation.Popups;

public partial class InputPopup : Popup
{
	public InputPopup(string text = "")
	{
		InitializeComponent();
        InputData.Text = text;
	}
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close(null);
    }
    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (InputData.Text == "")
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(new StandartPopup("The data cannot\nbe empty"));
        }
        else
        {
            Close((string)InputData.Text);
        }
    }

}