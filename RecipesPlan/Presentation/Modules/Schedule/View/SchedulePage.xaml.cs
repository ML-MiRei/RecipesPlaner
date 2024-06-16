using RecipesPlan.Presentation.Modules.Schedule.ViewModel;

namespace RecipesPlan.Presentation.Modules.Schedule.View;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(SchedulePageVM schedulePageVM)
	{
		InitializeComponent();
		BindingContext = schedulePageVM;
	}
}