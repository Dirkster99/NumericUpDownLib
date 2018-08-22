namespace NumericUpDownLib
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Implements a Byte based Numeric Up/Down control.
    /// 
    /// Source: http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    [TemplatePart(Name = Part_TextBoxName, Type = typeof(TextBox))]
    public partial class ByteUpDown : AbstractBaseUpDown<byte>
    {
        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static ByteUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ByteUpDown),
                       new FrameworkPropertyMetadata(typeof(ByteUpDown)));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public ByteUpDown()
            : base()
        {
        }
        #endregion constructor

        #region methods
        /// <summary>
        /// is invoked whenever application code or internal processes call
        /// System.Windows.FrameworkElement.ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _PART_TextBox = this.GetTemplateChild(Part_TextBoxName) as TextBox;

            if (_PART_TextBox != null)
            {
                _PART_TextBox.TextChanged += _PART_TextBox_TextChanged;
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
        protected override void _PART_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte number = 0;

            if (_PART_TextBox.Text != "")
            {
                if (byte.TryParse(_PART_TextBox.Text, out number) == false)
                    _PART_TextBox.Text = MinValue.ToString();
                else
                {
                    if (number >= MaxValue)
                        _PART_TextBox.Text = MaxValue.ToString();
                    else
                    {
                        if (number <= MinValue)
                            _PART_TextBox.Text = MinValue.ToString();
                    }

                    _PART_TextBox.SelectionStart = _PART_TextBox.Text.Length;
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
                    int intValue = this.Value + this.StepSize;

                    if (intValue >= byte.MinValue && intValue <= byte.MaxValue)
                        this.Value = (byte)intValue;
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
                    int intValue = this.Value - this.StepSize;

                    if (intValue >= byte.MinValue && intValue <= byte.MaxValue)
                        this.Value = (byte)intValue;
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
        protected override byte CoerceValue(byte newValue)
        {
            byte min = MinValue;
            byte max = MaxValue;

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
        protected override byte CoerceMinValue(byte newValue)
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
        protected override byte CoerceMaxValue(byte newValue)
        {
            newValue = Math.Max(this.MinValue, Math.Max(this.MaxValue, newValue));

            return newValue;
        }
        #endregion methods
    }
}