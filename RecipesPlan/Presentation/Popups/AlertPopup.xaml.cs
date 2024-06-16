using CommunityToolkit.Maui.Views;

namespace RecipesPlan.Presentation.Popups;

public partial class AlertPopup : Popup
{
	public AlertPopup(string title = "Are you sure?", string positiveButtonText = "Complete", string negativeButtonText = "Cancel")
	{
		InitializeComponent();
		TitlePopup.Text = title;
        PositiveButton.Text = positiveButtonText;   
        NegativeButton.Text = negativeButtonText;
    }

    private void PositiveButton_Clicked(object sender, EventArgs e)
    {
        Close(true);
    }

    private void NegativeButton_Clicked(object sender, EventArgs e)
    {
        Close(false);
    }
}