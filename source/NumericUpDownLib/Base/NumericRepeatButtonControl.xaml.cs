namespace NumericUpDownLib.Base
{
	using System.Windows;
	using System.Windows.Controls.Primitives;
	using System.Windows.Input;
	using System.Windows.Media;

	/// <summary>
	/// Class implements a repeat button custom control that supports
	/// custom <seealso cref="Geometry"/> data for display as an error and
	/// and <seealso cref="ICommand"/> binding to relay a click command
	/// to a hosting control or bound viewmodel.
	/// </summary>
	public class NumericRepeatButtonControl : RepeatButton
	{
		static NumericRepeatButtonControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericRepeatButtonControl), new FrameworkPropertyMetadata(typeof(NumericRepeatButtonControl)));
		}

		#region RepeatButtonContent dependency property
		/// <summary>
		/// Gets/sets an object that is bound to the
		/// ContentControl of the RepeatButton.
		/// </summary>
		public Geometry RepeatButtonContent
		{
			get { return (Geometry)GetValue(RepeatButtonContentProperty); }
			set { SetValue(RepeatButtonContentProperty, value); }
		}

		/// <summary>
		/// Using a DependencyProperty as the backing store for RepeatButtonContent.
		/// This enables styling and usage of flexible binding.
		/// </summary>
		public static readonly DependencyProperty RepeatButtonContentProperty =
			DependencyProperty.Register("RepeatButtonContent",
										typeof(Geometry),
										typeof(NumericRepeatButtonControl),
										new PropertyMetadata(null));
		#endregion RepeatButtonContent dependency property

		#region ICommand dependency property
		/// <summary>
		/// Gets/sets the command that is bound and
		/// invocked when the repeat button is clicked.
		/// </summary>
		public ICommand ClickCommand
		{
			get { return (ICommand)GetValue(ClickCommandProperty); }
			set { SetValue(ClickCommandProperty, value); }
		}

		/// <summary>
		/// Implments the backing store for a DependencyProperty of the ClickCommand.
		/// </summary>
		public static readonly DependencyProperty ClickCommandProperty =
			DependencyProperty.Register("ClickCommand",
										typeof(ICommand),
										typeof(NumericRepeatButtonControl),
										new PropertyMetadata(null));
		#endregion ICommand dependency property
	}
}
