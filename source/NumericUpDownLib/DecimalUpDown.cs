namespace NumericUpDownLib
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Implements a Byte based Numeric Up/Down control.
    /// 
    /// Original Source:
    /// http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    public partial class DecimalUpDown : AbstractBaseUpDown<decimal>
    {
        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static DecimalUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DecimalUpDown),
                       new FrameworkPropertyMetadata(typeof(DecimalUpDown)));

            // overide default values inherited dependency properties
            MaxValueProperty.OverrideMetadata(typeof(DecimalUpDown),
                                              new FrameworkPropertyMetadata(decimal.MaxValue));
            MinValueProperty.OverrideMetadata(typeof(DecimalUpDown),
                                              new FrameworkPropertyMetadata(decimal.MinValue));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public DecimalUpDown()
            : base()
        {
        }
        #endregion constructor

        #region methods
        /// <summary>
        /// Increase the displayed integer value
        /// </summary>
        protected override void OnIncrease()
        {
            if (this.Value >= this.MaxValue)
            {
                // Value is not incremented if it is already maxed or above
                this.Value = this.MaxValue;
            }
            else
            {
                if (this.Value + this.StepSize <= this.MaxValue)
                {
                        this.Value = this.Value + this.StepSize;
                }
                else
                {
                    if (this.Value <= this.MinValue)
                    {
                        // Value is not incremented if it is already min or below
                        this.Value = this.MinValue;
                    }
                }
            }
        }

        /// <summary>
        /// Decrease the displayed integer value
        /// </summary>
        protected override void OnDecrease()
        {
            if (this.Value <= this.MinValue)
            {
                // Value is not decremented if it is already minimum or below
                this.Value = this.MinValue;
            }
            else
            {
                if (this.Value - this.StepSize > this.MinValue)
                {
                    this.Value = this.Value - this.StepSize;
                }
                else
                {
                    if (this.Value >= this.MaxValue)
                    {
                        // Value is not incremented if it is already maxed or above
                        this.Value = this.MaxValue;
                    }
                }
            }
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
        protected override decimal CoerceValue(decimal newValue)
        {
            decimal min = MinValue;
            decimal max = MaxValue;

            if (newValue < min)
                return min;

            if (newValue > max)
                return max;

            return newValue;
        }

        /// <summary>
        /// Attempts to force the new Minimum value into the existing dependency property
        /// and attempts backup plans (uses minimum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected override decimal CoerceMinValue(decimal newValue)
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
        protected override decimal CoerceMaxValue(decimal newValue)
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
            decimal number = 0;

            // Does this text represent a valid number ?
            if (decimal.TryParse(text, base.NumberStyle,
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

        private string FormatNumber(decimal number)
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