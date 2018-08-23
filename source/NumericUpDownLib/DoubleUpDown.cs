namespace NumericUpDownLib
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Implements a Byte based Numeric Up/Down control.
    /// 
    /// Source: http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    [TemplatePart(Name = Part_TextBoxName, Type = typeof(TextBox))]
    public partial class DoubleUpDown : AbstractBaseUpDown<double>
    {
        private bool _UserInput = false;

        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static DoubleUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleUpDown),
                       new FrameworkPropertyMetadata(typeof(DoubleUpDown)));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public DoubleUpDown()
            : base()
        {
        }
        #endregion constructor

        #region methods
        /// <summary>
        /// Is invoked whenever application code or internal processes call
        /// System.Windows.FrameworkElement.ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _PART_TextBox = this.GetTemplateChild(Part_TextBoxName) as TextBox;

            if (_PART_TextBox != null)
            {
                _PART_TextBox.TextChanged += _PART_TextBox_TextChanged;

                _PART_TextBox.PreviewKeyDown += textBox_PreviewKeyDown;
                _PART_TextBox.PreviewTextInput += textBox_PreviewTextInput;
                DataObject.AddPastingHandler(_PART_TextBox, textBox_TextPasted);
                _PART_TextBox.TextChanged += _PART_TextBox_TextChanged;
                _PART_TextBox.LostKeyboardFocus += _PART_TextBox_LostKeyboardFocus;
            }
        }

        /// <summary>
        /// Method executes when the text portion in the textbox is changed
        /// The Value is corrected to a valid value if text was illegal or
        /// value was outside of the specified bounds.
        /// 
        /// https://stackoverflow.com/questions/841293/where-is-the-wpf-numeric-updown-control#2752538
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void _PART_TextBox_TextChanged(object sender,
                                                          TextChangedEventArgs e)
        {
            if (_PART_TextBox != null)
            {
                if (_UserInput == true)
                {
                    int pos = _PART_TextBox.CaretIndex;

                    FormatText(_PART_TextBox.Text, false);

                    if (_PART_TextBox.IsFocused == false)
                        SetUserInput(false);

                    _PART_TextBox.CaretIndex = pos;
                }
                else
                {
                    FormatText(_PART_TextBox.Text);
                }
            }
        }

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
        protected override double CoerceValue(double newValue)
        {
            double min = MinValue;
            double max = MaxValue;

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
        protected override double CoerceMinValue(double newValue)
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
        protected override double CoerceMaxValue(double newValue)
        {
            newValue = Math.Max(this.MinValue, Math.Max(this.MaxValue, newValue));

            return newValue;
        }

        private void _PART_TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (_PART_TextBox != null)
                FormatText(_PART_TextBox.Text);
        }

        /// <summary>
        /// Catches pasting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextPasted(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.SourceDataObject.GetDataPresent(DataFormats.Text, true) == false)
            {
                return;
            }

            SetUserInput(true);
        }

        /// <summary>
        /// Catches Backspace, Delete, Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            SetUserInput(true);
        }

        /// <summary>
        /// Catches pasting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            SetUserInput(true);
        }

        private void SetUserInput(bool userInput)
        {
            _UserInput = userInput;
        }

        private void _PART_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_PART_TextBox != null)
                FormatText(_PART_TextBox.Text);
        }

        private void FormatText(string text,
                                bool formatNumber = true)
        {
            double number = 0;

            // Does this text represent a valid number ?
            if (double.TryParse(text, NumberStyles.Any,
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

        private string FormatNumber(double number)
        {
            return string.Format("{0:F2}", number);
        }
        #endregion methods
    }
}