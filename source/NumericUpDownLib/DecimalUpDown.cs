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
    public partial class DecimalUpDown : AbstractBaseUpDown<decimal>
    {
        #region fields
        /// <summary>
        /// Backing store to define the size of the increment or decrement
        /// when using the up/down of the up/down numeric control.
        /// </summary>
        protected static readonly DependencyProperty StepSizeProperty =
            DependencyProperty.Register("StepSize",
                                        typeof(decimal), typeof(DecimalUpDown),
                                        new FrameworkPropertyMetadata((decimal)1),
                                        new ValidateValueCallback(IsValidStepSizeReading));

        /// <summary>
        /// Backing store to define the size of the increment or decrement
        /// when using the up/down of the up/down numeric control.
        /// </summary>
        protected static readonly DependencyProperty LargeStepSizeProperty =
            DependencyProperty.Register("LargeStepSize",
                                        typeof(decimal), typeof(DecimalUpDown),
                                        new FrameworkPropertyMetadata((decimal)10),
                                        new ValidateValueCallback(IsValidStepSizeReading));

        #endregion fields

        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static DecimalUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DecimalUpDown),
                       new FrameworkPropertyMetadata(typeof(DecimalUpDown)));

            MaxValueProperty.OverrideMetadata(typeof(DecimalUpDown),
                                                  new PropertyMetadata(decimal.MaxValue));

            MinValueProperty.OverrideMetadata(typeof(DecimalUpDown),
                                                  new PropertyMetadata(decimal.MinValue));

            // Override Min/Max default values
            ////            AbstractBaseUpDown<decimal>.MinValueProperty.OverrideMetadata(
            ////                typeof(DecimalUpDown), new PropertyMetadata(decimal.MinValue));
            ////
            ////            AbstractBaseUpDown<decimal>.MaxValueProperty.OverrideMetadata(
            ////                typeof(DecimalUpDown), new PropertyMetadata(decimal.MaxValue));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public DecimalUpDown()
            : base()
        {
        }
        #endregion constructor

        #region properties
        /// <summary>
        /// Gets or sets the step size (actual distance) of increment or decrement step.
        /// This value should at least be 1 or greater.
        /// </summary>
        public override decimal StepSize
        {
            get { return (decimal)GetValue(StepSizeProperty); }
            set { SetValue(StepSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the step size (actual distance) of increment or decrement step.
        /// This value should at least be 1 or greater.
        /// </summary>
        public override decimal LargeStepSize
        {
            get { return (decimal)GetValue(LargeStepSizeProperty); }
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
                this.Value = this.Value + this.StepSize;
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
                this.Value = this.Value - this.StepSize;
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
        protected override bool OnIncrement(decimal stepValue)
        {
            try
            {
                checked
                {
                    if (Value == MaxValue)
                        return false;

                    var result = (decimal)(Value + stepValue);

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
        protected override bool OnDecrement(decimal stepValue)
        {
            try
            {
                checked
                {
                    if (Value == MinValue)
                        return false;

                    var result = (decimal)(Value - stepValue);

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
        protected override decimal CoerceValue(decimal newValue)
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
        protected override decimal CoerceMinValue(decimal newValue)
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
        protected override decimal CoerceMaxValue(decimal newValue)
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
        /// Verify the text is valid or not while use is typing
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tempValue">the last value</param>
        protected override bool VerifyText(string text, ref Decimal tempValue)
        {
            if (Decimal.TryParse(text, base.NumberStyle, CultureInfo.CurrentCulture, out Decimal number))
            {
                tempValue = number;
                if (number > MaxValue || number < MinValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        protected override bool ParseText(string text, out decimal number)
        {
            return decimal.TryParse(text, base.NumberStyle, CultureInfo.CurrentCulture, out number);
        }

        /// <summary>
        /// Determines whether the step size in the <paramref name="value"/> parameter
        /// is larger 0 (valid) or not.
        /// </summary>
        /// <param name="value">returns true for valid values, otherwise false.</param>
        /// <returns></returns>
        private static bool IsValidStepSizeReading(object value)
        {
            decimal v = (decimal)value;
            return (v > 0);
        }
        #endregion methods
    }
}