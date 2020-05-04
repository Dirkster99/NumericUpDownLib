namespace TestGenerics
{
	using System.Windows;
	using TestGenerics.ViewModel;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new AppViewModel();
		}
	}
}
