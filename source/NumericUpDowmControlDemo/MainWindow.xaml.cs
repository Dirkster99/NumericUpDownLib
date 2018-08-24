namespace NumericUpDowmControlDemo
{
  using System.Windows;
  using NumericUpDowmControlDemo.ViewModel;

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
