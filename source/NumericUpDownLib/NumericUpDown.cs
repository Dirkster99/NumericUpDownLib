namespace NumericUpDownLib
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Implements an up/down numeric integer control.
    /// Source: http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    [TemplatePart(Name = Part_TextBoxName, Type = typeof(TextBox))]
    public partial class NumericUpDown : Control
    {
        #region fields
        /// <summary>
        /// Gets the required tamplate name of the textbox portion of this control.
        /// </summary>
        public const string Part_TextBoxName = "PART_TextBox";

        /// <summary>
        /// Determines whether the textbox portion of the control is editable
        /// (requires additional check of bounds) or not.
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly",
                typeof(bool),
                typeof(NumericUpDown), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the Value dependency property.
        /// </summary>
        private static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                                        typeof(int), typeof(NumericUpDown),
                                        new FrameworkPropertyMetadata(mMinValue,
                                        new PropertyChangedCallback(OnValueChanged),
                                        new CoerceValueCallback(CoerceValue)));

        private static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue",
                                        typeof(int), typeof(NumericUpDown),
                                        new FrameworkPropertyMetadata(mMinValue,
                                        new PropertyChangedCallback(OnMinValueChanged),
                                        new CoerceValueCallback(CoerceMinValue)));

        private static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue",
                                        typeof(int), typeof(NumericUpDown),
                                        new FrameworkPropertyMetadata(mMaxValue,
                                        new PropertyChangedCallback(OnMaxValueChanged),
                                        new CoerceValueCallback(CoerceMaxValue)));

        /// <summary>
        /// Identifies the ValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "ValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<int>),
                                            typeof(NumericUpDown));

        /// <summary>
        /// Identifies the MinValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent MinValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "MinValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<int>),
                                            typeof(NumericUpDown));

        /// <summary>
        /// Identifies the MaxValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent MaxValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "MaxValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<int>),
                                            typeof(NumericUpDown));

        private static RoutedCommand mIncreaseCommand;
        private static RoutedCommand mDecreaseCommand;

        private TextBox _PART_TextBox;
        private const int mMinValue = 0, mMaxValue = 100;
        #endregion fields

        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown),
                       new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        /// <summary>
        /// Initializes a new instance of the NumericUpDownControl.
        /// </summary>
        public NumericUpDown()
        {
            NumericUpDown.InitializeCommands();
        }
        #endregion constructor

        #region events
        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<int> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        /// <summary>
        /// Occurs when the MinValue property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<int> MinValueChanged
        {
            add { AddHandler(MinValueChangedEvent, value); }
            remove { RemoveHandler(MinValueChangedEvent, value); }
        }

        /// <summary>
        /// Occurs when the MaxValue property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<int> MaxValueChanged
        {
            add { AddHandler(MaxValueChangedEvent, value); }
            remove { RemoveHandler(MaxValueChangedEvent, value); }
        }
        #endregion events

        #region properties
        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Get/set dependency property to define the minimum legal value.
        /// </summary>
        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        /// <summary>
        /// Get/set dependency property to define the maximum legal value.
        /// </summary>
        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
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
        /// Expose the increase value command via <seealso cref="RoutedCommand"/> property.
        /// </summary>
        public static RoutedCommand IncreaseCommand
        {
            get
            {
                return mIncreaseCommand;
            }
        }

        /// <summary>
        /// Expose the decrease value command via <seealso cref="RoutedCommand"/> property.
        /// </summary>
        public static RoutedCommand DecreaseCommand
        {
            get
            {
                return mDecreaseCommand;
            }
        }
        #endregion properties

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
        private void _PART_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int number = 0;

            if (_PART_TextBox.Text != "")
            {
                if (int.TryParse(_PART_TextBox.Text, out number) == false)
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
        protected virtual void OnIncrease()
        {
            if (this.Value >= this.MaxValue)
            {
                // Value is not incremented if it is already maxed or above
                this.Value = this.MaxValue;
            }
            else
            {
                if (this.Value < this.MaxValue)
                    this.Value = this.Value + 1;
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
        protected virtual void OnDecrease()
        {
            if (this.Value <= this.MinValue)
            {
                // Value is not decremented if it is already minimum or below
                this.Value = this.MinValue;
            }
            else
            {
                if (this.Value > this.MinValue)
                    this.Value = this.Value - 1;
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

        #region Value dependency property helper methods
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<int> args)
        {
            this.RaiseEvent(args);
        }

        private static object CoerceValue(DependencyObject element, object value)
        {
            NumericUpDown control = element as NumericUpDown;

            try
            {
                int newValue = (int)value;

                if (control != null)
                {
                    if (newValue <= control.MinValue)
                    {
                        newValue = control.MinValue;
                    }
                    else
                    {
                        if (newValue >= control.MaxValue)
                            newValue = control.MaxValue;
                    }

                    return newValue;
                }
            }
            catch
            {
            }

            return control.MaxValue;
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            NumericUpDown control = obj as NumericUpDown;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<int> e = new RoutedPropertyChangedEventArgs<int>((int)args.OldValue, (int)args.NewValue, ValueChangedEvent);
                control.OnValueChanged(e);
            }
        }
        #endregion Value dependency property helper methods

        #region MinValue dependency property helper methods
        /// <summary>
        /// Raises the MinValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnMinValueChanged(RoutedPropertyChangedEventArgs<int> args)
        {
            this.RaiseEvent(args);
        }

        private static void OnMinValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            NumericUpDown control = obj as NumericUpDown;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<int> e = new RoutedPropertyChangedEventArgs<int>((int)args.OldValue, (int)args.NewValue, MinValueChangedEvent);
                control.OnMinValueChanged(e);
            }
        }

        private static object CoerceMinValue(DependencyObject element, object value)
        {
            NumericUpDown control = element as NumericUpDown;

            try
            {
                int newValue = (int)value;

                if (control != null)
                {
                    newValue = Math.Min(control.MinValue, Math.Min(control.MaxValue, newValue));

                    return newValue;
                }
            }
            catch
            {
            }

            return control.MinValue;
        }
        #endregion Value dependency property helper methods

        #region MaxValue dependency property helper methods
        /// <summary>
        /// Raises the MinValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnMaxValueChanged(RoutedPropertyChangedEventArgs<int> args)
        {
            this.RaiseEvent(args);
        }

        private static void OnMaxValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            NumericUpDown control = obj as NumericUpDown;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<int> e = new RoutedPropertyChangedEventArgs<int>((int)args.OldValue, (int)args.NewValue, MaxValueChangedEvent);
                control.OnMaxValueChanged(e);
            }
        }

        private static object CoerceMaxValue(DependencyObject element, object value)
        {
            NumericUpDown control = element as NumericUpDown;

            try
            {
                int newValue = (int)value;

                if (control != null)
                {
                    newValue = Math.Max(control.MinValue, Math.Max(control.MaxValue, newValue));

                    return newValue;
                }

                return newValue;
            }
            catch (Exception)
            {
            }

            return control.MaxValue;
        }
        #endregion Value dependency property helper methods

        #region Commands
        /// <summary>
        /// Initialize up down/button commands and key gestures for up/down cursor keys
        /// </summary>
        private static void InitializeCommands()
        {
            NumericUpDown.mIncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(NumericUpDown));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown),
                                    new CommandBinding(mIncreaseCommand, OnIncreaseCommand));

            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown),
                                    new InputBinding(mIncreaseCommand, new KeyGesture(Key.Up)));

            NumericUpDown.mDecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(NumericUpDown));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown),
                                    new CommandBinding(mDecreaseCommand, OnDecreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown),
                                    new InputBinding(mDecreaseCommand, new KeyGesture(Key.Down)));
        }

        /// <summary>
        /// Execute the increase value command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            NumericUpDown control = sender as NumericUpDown;
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
            NumericUpDown control = sender as NumericUpDown;
            if (control != null)
            {
                control.OnDecrease();
                e.Handled = true;
            }
        }
        #endregion
        #endregion methods
    }
}