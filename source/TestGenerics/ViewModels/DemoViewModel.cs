namespace TestGenerics.ViewModel
{
	using UpDownDemoLib.Demos.ViewModels;

	/// <summary>
	/// Application Viewmodel class to be bound to MainWindow...
	/// </summary>
	public class AppViewModel : Base.ViewModelBase
	{
		public AppViewModel()
		{
			Demo = new DemoViewModel();
		}

		public DemoViewModel Demo { get; }
	}
}
