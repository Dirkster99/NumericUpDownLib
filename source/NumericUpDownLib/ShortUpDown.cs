namespace NumericUpDownLib
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Implements a <see cref="short"/> based Numeric Up/Down control.
    /// 
    /// Original Source:
    /// http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    public partial class ShortUpDown : AbstractBaseUpDown<short>
    {
        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static ShortUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShortUpDown),
                       new FrameworkPropertyMetadata(typeof(ShortUpDown)));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public ShortUpDown()
            : base()
        {
        }
        #endregion constructor

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
                this.Value = (short)(this.Value + this.StepSize);
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
                this.Value = (short)(this.Value - this.StepSize);
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
        /// Attempts to force the new value into the existing dependency property
        /// and attempts backup plans (uses minimum or maximum values) if value appears
        /// to be out of either range.
        /// 
        /// http://drwpf.com/blog/category/value-coercion/
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected override short CoerceValue(short newValue)
        {
            if (newValue < MinValue)
                return MinValue;

            if (newValue > MaxValue)
                return MaxValue;

            return newValue;
        }

        /// <summary>
        /// Attempts to force the new Minimum value into the existing dependency property
        /// and attempts backup plans (uses minimum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected override short CoerceMinValue(short newValue)
        {
            newValue = Math.Min(MinValue, Math.Min(MaxValue, newValue));

            return newValue;
        }

        /// <summary>
        /// Attempts to force the new Minimum value into the existing dependency property
        /// and attempts backup plans (uses maximum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected override short CoerceMaxValue(short newValue)
        {
            newValue = Math.Max(this.MinValue, Math.Max(this.MaxValue, newValue));

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
            short number = 0;

            // Does this text represent a valid number ?
            if (short.TryParse(text, base.NumberStyle,
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

        private string FormatNumber(short number)
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