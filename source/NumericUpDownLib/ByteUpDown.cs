namespace NumericUpDownLib
{
	using NumericUpDownLib.Base;
	using System;
	using System.Globalization;
	using System.Windows;

	/// <summary>
	/// Implements a Byte based Numeric Up/Down control.
	/// 
	/// Original Source:
	/// http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
	/// </summary>
	public partial class ByteUpDown : AbstractBaseUpDown<byte>
	{
		#region fields
		/// <summary>
		/// Backing store to define the size of the increment or decrement
		/// when using the up/down of the up/down numeric control.
		/// </summary>
		protected static readonly DependencyProperty StepSizeProperty =
			DependencyProperty.Register("StepSize",
										typeof(byte), typeof(ByteUpDown),
										new FrameworkPropertyMetadata((byte)1),
										new ValidateValueCallback(IsValidStepSizeReading));

		/// <summary>
		/// Backing store to define the size of the increment or decrement
		/// when using the up/down of the up/down numeric control.
		/// </summary>
		protected static readonly DependencyProperty LargeStepSizeProperty =
			DependencyProperty.Register("LargeStepSize",
										typeof(byte), typeof(ByteUpDown),
										new FrameworkPropertyMetadata((byte)10),
										new ValidateValueCallback(IsValidStepSizeReading));
		#endregion fields

		#region constructor
		/// <summary>
		/// Static class constructor
		/// </summary>
		static ByteUpDown()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ByteUpDown),
					   new FrameworkPropertyMetadata(typeof(ByteUpDown)));

			MaxValueProperty.OverrideMetadata(typeof(ByteUpDown),
			                                      new PropertyMetadata(byte.MaxValue));

			MinValueProperty.OverrideMetadata(typeof(ByteUpDown),
												  new PropertyMetadata(byte.MinValue));

			// Override Min/Max default values
////		AbstractBaseUpDown<byte>.MinValueProperty.OverrideMetadata(
////		    typeof(ByteUpDown), new PropertyMetadata(byte.MinValue));
////		
////		AbstractBaseUpDown<byte>.MaxValueProperty.OverrideMetadata(
////		    typeof(ByteUpDown), new PropertyMetadata(byte.MaxValue));
		}

		/// <summary>
		/// Initializes a new instance of the AbstractBaseUpDown Control.
		/// </summary>
		public ByteUpDown()
			: base()
		{
		}
		#endregion constructor

		#region properties
		/// <summary>
		/// Gets or sets the step size (actual distance) of increment or decrement step.
		/// This value should at least be 1 or greater.
		/// </summary>
		public override byte StepSize
		{
			get { return (byte)GetValue(StepSizeProperty); }
			set { SetValue(StepSizeProperty, value); }
		}

		/// <summary>
		/// Gets or sets the step size (actual distance) of increment or decrement step.
		/// This value should at least be 1 or greater.
		/// </summary>
		public override byte LargeStepSize
		{
			get { return (byte)GetValue(LargeStepSizeProperty); }
			set { SetValue(LargeStepSizeProperty, value); }
		}
		#endregion properties

		#region methods
		/// <summary>
		/// Determines whether the increase command is available or not.
		/// </summary>
		/// <returns>true if command is enabled, otherwise false</returns>
		protected override bool CanIncreaseCommand()
		{
			return (Value < MaxValue);
		}

		/// <summary>
		/// Determines whether the decrease command is available or not.
		/// </summary>
		/// <returns>true if command is enabled, otherwise false</returns>
		protected override bool CanDecreaseCommand()
		{
			return (Value > MinValue);
		}

		/// <summary>
		/// Increase the displayed value
		/// </summary>
		protected override void OnIncrease()
		{
			// Increment if possible
			if (this.Value + this.StepSize <= this.MaxValue)
			{
				this.Value = (byte)(this.Value + this.StepSize);
			}
			else
			{
				// Reset to max to ensure that value = max at this point
				if (this.Value != this.MaxValue)
					this.Value = this.MaxValue;
			}

			// Just to be sure
			// Value was incremented beyond bound so we reset it to max
			if (this.Value > this.MaxValue)
				this.Value = this.MaxValue;
		}

		/// <summary>
		/// Decrease the displayed value
		/// </summary>
		protected override void OnDecrease()
		{
			// Decrement if possible
			if (this.Value - this.StepSize > this.MinValue)
			{
				this.Value = (byte)(this.Value - this.StepSize);
			}
			else
			{
				// Reset to min to ensure that value = min at this point
				if (this.Value != this.MinValue)
					this.Value = this.MinValue;
			}

			// Just to be sure
			// Value was decremented beyond bound so we reset it to min
			if (this.Value < this.MinValue)
				this.Value = this.MinValue;
		}

		/// <summary>
		/// Increments the current value by the <paramref name="stepValue"/> and returns
		/// true if maximum allowed value was not reached, yet. Or returns false and
		/// changes nothing if maximum value is equal current value.
		/// </summary>
		/// <param name="stepValue"></param>
		/// <returns></returns>
		protected override bool OnIncrement(byte stepValue)
		{
			try
			{
				checked
				{
					if (Value == MaxValue)
						return false;

					var result = (byte)(Value + stepValue);

					if (result >= MaxValue)
					{
						Value = MaxValue;
						return true;
					}

					if (result >= MinValue)
						Value = result;

					return true;
				}
			}
			catch (OverflowException)
			{
				Value = MaxValue;
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Decrements the current value by the <paramref name="stepValue"/> and returns
		/// true if minimum allowed value was not reached, yet. Or returns false and
		/// changes nothing if minimum value is equal current value.
		/// </summary>
		/// <param name="stepValue"></param>
		/// <returns></returns>
		protected override bool OnDecrement(byte stepValue)
		{
			try
			{
				checked
				{
					if (Value == MinValue)
						return false;

					var result = (byte)(Value - stepValue);

					if (result <= MinValue)
					{
						Value = MinValue;
						return true;
					}

					if (result <= MaxValue)
						Value = result;

					return true;
				}
			}
			catch (OverflowException)
			{
				Value = MinValue;
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Attempts to force the new <see cref="Value"/> into the existing dependency property
		/// and attempts backup plans:
		/// Adjusts  <see cref="MinValue"/> or  <see cref="MaxValue"/>, if <see cref="Value"/> appears to be out of either range.
		/// </summary>
		/// <param name="newValue">The new Value to be forced into this dp.</param>
		/// <returns></returns>
		protected override byte CoerceValue(byte newValue)
		{
			if (newValue != Value)
			{
				if (MinValue > newValue)
					MinValue = newValue;

				if (MaxValue < newValue)
					MaxValue = newValue;
			}

			return newValue;
		}

		/// <summary>
		/// Attempts to force the new <see cref="MinValue"/> into the existing dependency property
		/// and attempts backup plans:
		/// Adjusts <see cref="MaxValue"/> or <see cref="Value"/>, if <see cref="MinValue"/> appears to be out of either range.
		/// </summary>
		/// <param name="newValue">The new Minimum value to be forced into this dp.</param>
		/// <returns></returns>
		protected override byte CoerceMinValue(byte newValue)
		{
			if (MinValue != newValue)
			{
				if (Value < newValue)
					Value = newValue;

				if (MaxValue < newValue)
					MaxValue = newValue;
			}

			return newValue;
		}

		/// <summary>
		/// Attempts to force the new <see cref="MaxValue"/> into the existing dependency property
		/// and attempts backup plans:
		/// Adjusts <see cref="MinValue"/> or <see cref="Value"/>, if <see cref="MaxValue"/> appears to be out of either range.
		/// </summary>
		/// <param name="newValue">The new Maximum value to be forced into this dp.</param>
		/// <returns></returns>
		protected override byte CoerceMaxValue(byte newValue)
		{
			if (MaxValue != newValue)
			{
				if (MinValue > newValue)
					MinValue = newValue;

				if (Value > newValue)
					Value = newValue;
			}

			return newValue;
		}

		/// <summary>
		/// Checks if the current string entered in the textbox is valid
		/// and conforms to a known format
		/// (<see cref="AbstractBaseUpDown{T}"/> base method for more details).
		/// </summary>
		/// <param name="text"></param>
		/// <param name="formatNumber"></param>
		protected override void FormatText(string text, bool formatNumber = true)
		{
			byte number = 0;

			// Does this text represent a valid number ?
			if (byte.TryParse(text, base.NumberStyle,
							  CultureInfo.CurrentCulture, out number) == true)
			{
				// yes -> but is the number within bounds?
				if (number >= MaxValue)
				{
					// Larger than allowed maximum
					_PART_TextBox.Text = FormatNumber(MaxValue);
					_PART_TextBox.SelectionStart = 0;
				}
				else
				{
					if (number <= MinValue)
					{
						// Smaller than allowed minimum
						_PART_TextBox.Text = FormatNumber(MinValue);
						_PART_TextBox.SelectionStart = 0;
					}
					else
					{
						// Number is valid and within bounds, just format if requested
						if (formatNumber == true)
							_PART_TextBox.Text = FormatNumber(number);
					}
				}
			}
			else
			{
				// Reset to minimum value since string does not appear to represent a number
				_PART_TextBox.SelectionStart = 0;
				_PART_TextBox.Text = FormatNumber(MinValue);
			}
		}

		/// <summary>
		/// Determines whether the step size in the <paramref name="value"/> parameter
		/// is larger 0 (valid) or not.
		/// </summary>
		/// <param name="value">returns true for valid values, otherwise false.</param>
		/// <returns></returns>
		private static bool IsValidStepSizeReading(object value)
		{
			byte v = (byte)value;
			return (v > 0);
		}

		/// <summary>
		/// Gets a formatted string for the value of the number passed in
		/// and ensures that a default string is returned even if there is
		/// no format specified.
		/// </summary>
		/// <param name="number">.Net type specific value to be formated as string</param>
		/// <returns>The string that was formatted with the FormatString
		/// dependency property</returns>
		private string FormatNumber(byte number)
		{
			string format = "{0}";

			var form = (string)GetValue(FormatStringProperty);

			if (string.IsNullOrEmpty(this.FormatString) == false)
				format = "{0:" + this.FormatString + "}";

			return string.Format(format, number);
		}
		#endregion methods
	}
}