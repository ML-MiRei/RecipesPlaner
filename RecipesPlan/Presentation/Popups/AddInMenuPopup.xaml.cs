using CommunityToolkit.Maui.Views;

namespace RecipesPlan.Presentation.Popups;

public partial class AddInMenuPopup : Popup
{
	public AddInMenuPopup()
	{
		InitializeComponent();
	}

    private void PositiveButton_Clicked(object sender, EventArgs e)
    {
        Close(SelectDate.Date);
    }
    private void NegativeButton_Clicked(object sender, EventArgs e)
    {
        Close(null);
    }
}