namespace NumericUpDownLib.Base
{
	using System.Globalization;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;

	/// <summary>
	/// This class serves as a target for styling the <see cref="AbstractBaseUpDown{T}"/> class
	/// since styling directly on <see cref="AbstractBaseUpDown{T}"/> is not supported in XAML.
	/// </summary>
	public abstract class InputBaseUpDown : Control
	{
		#region fields
		/// <summary>
		/// Determines whether the textbox portion of the control is editable
		/// (requires additional check of bounds) or not.
		/// </summary>
		public static readonly DependencyProperty IsReadOnlyProperty =
			DependencyProperty.Register("IsReadOnly",
				typeof(bool), typeof(InputBaseUpDown), new PropertyMetadata(true));

		/// <summary>
		/// Determines the allowed style of a number entered and displayed in the textbox.
		/// </summary>
		public static readonly DependencyProperty NumberStyleProperty =
			DependencyProperty.Register("NumberStyle", typeof(NumberStyles),
				typeof(InputBaseUpDown), new PropertyMetadata(NumberStyles.Any));

		/// <summary>
		/// Backing store of <see cref="EnableValidatingIndicator"/> dependency property.
		/// </summary>
		public static readonly DependencyProperty EnableValidatingIndicatorProperty =
			DependencyProperty.Register("EnableValidatingIndicator", typeof(bool), typeof(InputBaseUpDown), new PropertyMetadata(false));

		/// <summary>
		/// Backing store of <see cref="EditingVisibility"/> dependency property.
		/// </summary>
		public static readonly DependencyProperty EditingVisibilityProperty =
			DependencyProperty.Register("EditingVisibility", typeof(Visibility), typeof(InputBaseUpDown), new PropertyMetadata(Visibility.Hidden));

		/// <summary>
		/// Backing store of <see cref="EditingColorBrush"/> dependency property.
		/// </summary>
		public static readonly DependencyProperty EditingColorBrushProperty =
			DependencyProperty.Register("EditingColorBrush", typeof(System.Windows.Media.SolidColorBrush),
				typeof(InputBaseUpDown), new PropertyMetadata(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green)));

		// Using a DependencyProperty as the backing store for HeaderProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register(nameof(Header), typeof(object), typeof(InputBaseUpDown), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for HeaderProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty OrientationProperty =
			DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(InputBaseUpDown), new PropertyMetadata(Orientation.Vertical));



		/// <summary>
		/// identify that the inputing data is valid or not.,
		/// </summary>
		/// <value></value>
		protected System.Windows.Media.SolidColorBrush EditingColorBrush
		{
			get { return (System.Windows.Media.SolidColorBrush)GetValue(EditingColorBrushProperty); }
			set { SetValue(EditingColorBrushProperty, value); }
		}

		/// <summary>
		/// identify that the editing Visibility
		/// </summary>
		/// <value></value>
		protected Visibility EditingVisibility
		{
			get { return (Visibility)GetValue(EditingVisibilityProperty); }
			set { SetValue(EditingVisibilityProperty, value); }
		}

		/// <summary>
		/// identify that the is enable the red/green tip while editing
		/// </summary>
		/// <value></value>
		public bool EnableValidatingIndicator
		{
			get { return (bool)GetValue(EnableValidatingIndicatorProperty); }
			set { SetValue(EnableValidatingIndicatorProperty, value); }
		}

		private static RoutedCommand _IncreaseCommand;
		private static RoutedCommand _DecreaseCommand;
		#endregion fields

		/// <summary>
		/// Class constructor
		/// </summary>
		public InputBaseUpDown()
		{
			InitializeCommands();
		}

		#region properties
		/// <summary>
		/// Expose the increase value command via <seealso cref="RoutedCommand"/> property.
		/// </summary>
		public static RoutedCommand IncreaseCommand
		{
			get
			{
				return _IncreaseCommand;
			}
		}

		/// <summary>
		/// Expose the decrease value command via <seealso cref="RoutedCommand"/> property.
		/// </summary>
		public static RoutedCommand DecreaseCommand
		{
			get
			{
				return _DecreaseCommand;
			}
		}

		/// <summary>
		/// Determines whether the textbox portion of the control is editable
		/// (requires additional check of bounds) or not.
		/// </summary>
		public bool IsReadOnly
		{
			get { return (bool)GetValue(IsReadOnlyProperty); }
			set { SetValue(IsReadOnlyProperty, value); }
		}

		/// <summary>
		/// Gets/sets the allowed style of a number entered and displayed in the textbox.
		/// </summary>
		public NumberStyles NumberStyle
		{
			get { return (NumberStyles)GetValue(NumberStyleProperty); }
			set { SetValue(NumberStyleProperty, value); }
		}
		/// <summary>
		/// Header, <see langword="null"/> will be not visible
		/// </summary>
		public object Header
		{
			get { return GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}

		/// <summary>
		/// default <see cref="Orientation.Vertical"/>, Header is on top
		/// </summary>
		public Orientation Orientation
		{
			get { return (Orientation)GetValue(OrientationProperty); }
			set { SetValue(OrientationProperty, value); }
		}

		#endregion properties

		#region methods
		#region Commands
		/// <summary>
		/// Increase the displayed integer value
		/// </summary>
		protected abstract void OnIncrease();

		/// <summary>
		/// Determines whether the increase command is available or not.
		/// </summary>
		protected abstract bool CanIncreaseCommand();

		/// <summary>
		/// Decrease the displayed integer value
		/// </summary>
		protected abstract void OnDecrease();

		/// <summary>
		/// Determines whether the decrease command is available or not.
		/// </summary>
		protected abstract bool CanDecreaseCommand();

		/// <summary>
		/// Initialize up down/button commands and key gestures for up/down cursor keys
		/// </summary>
		private void InitializeCommands()
		{
			InputBaseUpDown._IncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(InputBaseUpDown));
			CommandManager.RegisterClassCommandBinding(typeof(InputBaseUpDown),
									new CommandBinding(_IncreaseCommand, OnIncreaseCommand, OnCanIncreaseCommand));

			CommandManager.RegisterClassInputBinding(typeof(InputBaseUpDown),
									new InputBinding(_IncreaseCommand, new KeyGesture(Key.Up)));

			InputBaseUpDown._DecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(InputBaseUpDown));

			CommandManager.RegisterClassCommandBinding(typeof(InputBaseUpDown),
									new CommandBinding(_DecreaseCommand, OnDecreaseCommand, OnCanDecreaseCommand));
		}

		/// <summary>
		/// Determine whether the IncreaseCommand can be executed or not and return the result
		/// in the <see cref="CanExecuteRoutedEventArgs.CanExecute"/> property of the given
		/// <paramref name="e"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnCanIncreaseCommand(object sender, CanExecuteRoutedEventArgs e)
		{
			var control = sender as InputBaseUpDown;
			if (control != null)
			{
				e.CanExecute = control.CanIncreaseCommand();
				e.Handled = true;
			}
		}

		/// <summary>
		/// Execute the increase value command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
		{
			var control = sender as InputBaseUpDown;
			if (control != null)
			{
				control.OnIncrease();
				e.Handled = true;
			}
		}

		/// <summary>
		/// Execute the decrease value command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e)
		{
			var control = sender as InputBaseUpDown;
			if (control != null)
			{
				control.OnDecrease();
				e.Handled = true;
			}
		}

		/// <summary>
		/// Determine whether the DecreaseCommand can be executed or not and return the result
		/// in the <see cref="CanExecuteRoutedEventArgs.CanExecute"/> property of the given
		/// <paramref name="e"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnCanDecreaseCommand(object sender, CanExecuteRoutedEventArgs e)
		{
			var control = sender as InputBaseUpDown;
			if (control != null)
			{
				e.CanExecute = control.CanDecreaseCommand();
				e.Handled = true;
			}
		}
		#endregion
		#endregion methods
	}
}
