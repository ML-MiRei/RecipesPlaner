using CommunityToolkit.Maui.Views;

namespace RecipesPlan.Presentation.Popups;

public partial class StandartPopup : Popup
{
	public StandartPopup(string text)
	{
		InitializeComponent();
		PopupText.Text = text;
	}
}