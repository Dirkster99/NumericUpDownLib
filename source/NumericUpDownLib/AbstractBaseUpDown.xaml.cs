namespace NumericUpDownLib
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;

    /// <summary>
    /// Implements an up/down abstract base control.
    /// Source: http://msdn.microsoft.com/en-us/library/vstudio/ms771573%28v=vs.90%29.aspx
    /// </summary>
    [TemplatePart(Name = Part_TextBoxName, Type = typeof(TextBox))]
    [TemplatePart(Name = PART_MeasuringFrameWorkElementName, Type = typeof(FrameworkElement))]
    public abstract partial class AbstractBaseUpDown<T> : InputBaseUpDown
    {
        #region fields
        /// <summary>
        /// Gets the required tamplate name of the textbox portion of this control.
        /// </summary>
        public const string Part_TextBoxName = "PART_TextBox";

        /// <summary>
        /// Gets the required tamplate name of the textbox portion of this control.
        /// </summary>
        public const string PART_MeasuringFrameWorkElementName = "PART_Measuring_Element";

        /// <summary>
        /// Holds the REQUIRED textbox instance part for this control.
        /// </summary>
        protected TextBox _PART_TextBox;

        private FrameworkElement _PART_Measuring_Element;

        /// <summary>
        /// Dependency property backing store for the Value property.
        /// </summary>
        protected static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                                        typeof(T), typeof(AbstractBaseUpDown<T>),
                                        new FrameworkPropertyMetadata(mMinValue,
                                        new PropertyChangedCallback(OnValueChanged),
                                        new CoerceValueCallback(CoerceValue)));

        private static readonly DependencyProperty StepSizeProperty =
            DependencyProperty.Register("StepSize",
                                        typeof(T), typeof(AbstractBaseUpDown<T>),
                                        new FrameworkPropertyMetadata(default(T)));

        /// <summary>
        /// Dependency property backing store for Minimum Value property.
        /// </summary>
        protected static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue",
                                        typeof(T), typeof(AbstractBaseUpDown<T>),
                                        new FrameworkPropertyMetadata(mMinValue,
                                        new PropertyChangedCallback(OnMinValueChanged),
                                        new CoerceValueCallback(CoerceMinValue)));

        /// <summary>
        /// Dependency property backing store for Maximum Value property.
        /// </summary>
        protected static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue",
                                        typeof(T), typeof(AbstractBaseUpDown<T>),
                                        new FrameworkPropertyMetadata(mMaxValue,
                                        new PropertyChangedCallback(OnMaxValueChanged),
                                        new CoerceValueCallback(CoerceMaxValue)));

        /// <summary>
        /// Identifies the ValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "ValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<T>),
                                            typeof(AbstractBaseUpDown<T>));

        /// <summary>
        /// Identifies the MinValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent MinValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "MinValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<T>),
                                            typeof(AbstractBaseUpDown<T>));

        /// <summary>
        /// Identifies the MaxValueChanged routed event.
        /// </summary>
        private static readonly RoutedEvent MaxValueChangedEvent = EventManager.RegisterRoutedEvent(
                                            "MaxValueChanged", RoutingStrategy.Bubble,
                                            typeof(RoutedPropertyChangedEventHandler<T>),
                                            typeof(AbstractBaseUpDown<T>));

        private static readonly DependencyProperty DisplayLengthProperty =
                                DependencyProperty.Register("DisplayLength", typeof(byte),
                                    typeof(AbstractBaseUpDown<T>), new PropertyMetadata((byte)3));

        private static readonly DependencyProperty IsDisplayLengthFixedProperty =
            DependencyProperty.Register("IsDisplayLengthFixed",
                typeof(bool), typeof(AbstractBaseUpDown<T>), new PropertyMetadata(true, OnIsDisplayLengthFixedChanged));

        private static readonly DependencyProperty SelectAllTextOnFocusProperty =
            DependencyProperty.Register("SelectAllTextOnFocus",
                typeof(bool), typeof(AbstractBaseUpDown<T>), new PropertyMetadata(true));

        /// <summary>
        /// Gets/sets the default applicable minimum value
        /// </summary>
        protected static T mMinValue = default(T);

        /// <summary>
        /// Gets/sets the default applicable maximum value
        /// </summary>
        protected static T mMaxValue = default(T);
        #endregion fields

        #region constructor
        /// <summary>
        /// Static class constructor
        /// </summary>
        static AbstractBaseUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AbstractBaseUpDown<T>),
                       new FrameworkPropertyMetadata(typeof(AbstractBaseUpDown<T>)));
        }

        /// <summary>
        /// Initializes a new instance of the AbstractBaseUpDown Control.
        /// </summary>
        public AbstractBaseUpDown()
            : base()
        {
        }
        #endregion constructor

        #region events
        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<T> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        /// <summary>
        /// Occurs when the MinValue property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<T> MinValueChanged
        {
            add { AddHandler(MinValueChangedEvent, value); }
            remove { RemoveHandler(MinValueChangedEvent, value); }
        }

        /// <summary>
        /// Occurs when the MaxValue property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<T> MaxValueChanged
        {
            add { AddHandler(MaxValueChangedEvent, value); }
            remove { RemoveHandler(MaxValueChangedEvent, value); }
        }
        #endregion events

        #region properties
        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the step size
        /// (actual distance) of increment or decrement step.
        /// This value should at leat be one or greater.
        /// </summary>
        public T StepSize
        {
            get { return (T)GetValue(StepSizeProperty); }
            set { SetValue(StepSizeProperty, value); }
        }


        /// <summary>
        /// Get/set dependency property to define the minimum legal value.
        /// </summary>
        public T MinValue
        {
            get { return (T)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        /// <summary>
        /// Get/set dependency property to define the maximum legal value.
        /// </summary>
        public T MaxValue
        {
            get { return (T)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        /// <summary>
        /// Gets/sets the number of characters to display in the textbox portion of the
        /// AbstractBaseUpDown control.
        /// </summary>
        public byte DisplayLength
        {
            get { return (byte)GetValue(DisplayLengthProperty); }
            set { SetValue(DisplayLengthProperty, value); }
        }

        /// <summary>
        /// Gets/sets whether the textbox portion of the numeric up down control
        /// can go grow and shrink with its input or whether it should stay with
        /// a fixed width.
        /// </summary>
        public bool IsDisplayLengthFixed
        {
            get { return (bool)GetValue(IsDisplayLengthFixedProperty); }
            set { SetValue(IsDisplayLengthFixedProperty, value); }
        }

        /// <summary>
        /// Gets/sets a dependency property to determine whether all text
        /// in the textbox should be selected on textbox focus or not.
        /// </summary>
        public bool SelectAllTextOnFocus
        {
            get { return (bool)GetValue(SelectAllTextOnFocusProperty); }
            set { SetValue(SelectAllTextOnFocusProperty, value); }
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
            _PART_Measuring_Element = this.GetTemplateChild(PART_MeasuringFrameWorkElementName) as FrameworkElement;

            if (_PART_TextBox != null)
            {
                _PART_TextBox.TextChanged += _PART_TextBox_TextChanged;
                _PART_TextBox.GotKeyboardFocus += _PART_TextBox_GotKeyboardFocus;

                BindMeasuringObject(IsDisplayLengthFixed);
            }
        }

        private void _PART_TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var tb = sender as TextBox;

            if (SelectAllTextOnFocus == true)
            {
                if (tb != null)
                    tb.SelectAll();
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
        protected abstract void _PART_TextBox_TextChanged(object sender, TextChangedEventArgs e);
        /***
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
        ***/

        /// <summary>
        /// Attempts to force the new value into the existing dependency property
        /// and attempts backup plans (uses minimum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="NewValue"></param>
        /// <returns></returns>
        protected abstract T CoerceValue(T NewValue);
        /***
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
        ***/

        /// <summary>
        /// Attempts to force the new Minimum value into the existing dependency property
        /// and attempts backup plans (uses minimum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="NewValue"></param>
        /// <returns></returns>
        protected abstract T CoerceMinValue(T NewValue);
        /***
            newValue = Math.Min(control.MinValue, Math.Min(control.MaxValue, newValue));

            return newValue;
        ***/

        /// <summary>
        /// Attempts to force the new Minimum value into the existing dependency property
        /// and attempts backup plans (uses maximum or maximum values) if value appears
        /// to be out of either range.
        /// </summary>
        /// <param name="NewValue"></param>
        /// <returns></returns>
        protected abstract T CoerceMaxValue(T NewValue);
        /***
            newValue = Math.Max(control.MinValue, Math.Max(control.MaxValue, newValue));

            return newValue;
        ***/

        #region Value dependency property helper methods
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<T> args)
        {
            this.RaiseEvent(args);
        }

        private static object CoerceValue(DependencyObject element, object value)
        {
            var control = element as AbstractBaseUpDown<T>;

            try
            {
                T newValue = (T)value;

                if (control != null)
                    return control.CoerceValue(newValue);
            }
            catch
            {
            }

            return control.MaxValue;
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as AbstractBaseUpDown<T>;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<T> e = new RoutedPropertyChangedEventArgs<T>((T)args.OldValue, (T)args.NewValue, ValueChangedEvent);
                control.OnValueChanged(e);
            }
        }
        #endregion Value dependency property helper methods

        #region MinValue dependency property helper methods
        /// <summary>
        /// Raises the MinValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnMinValueChanged(RoutedPropertyChangedEventArgs<T> args)
        {
            this.RaiseEvent(args);
        }

        private static void OnMinValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as AbstractBaseUpDown<T>;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<T> e = new RoutedPropertyChangedEventArgs<T>((T)args.OldValue, (T)args.NewValue, MinValueChangedEvent);
                control.OnMinValueChanged(e);

                control.CoerceValue(MaxValueProperty);
                control.CoerceValue(ValueProperty);
            }
        }

        private static object CoerceMinValue(DependencyObject element, object value)
        {
            var control = element as AbstractBaseUpDown<T>;

            try
            {
                T newValue = (T)value;

                if (control != null)
                {
                    return control.CoerceMinValue(newValue);
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
        protected virtual void OnMaxValueChanged(RoutedPropertyChangedEventArgs<T> args)
        {
            this.RaiseEvent(args);
        }

        private static void OnMaxValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as AbstractBaseUpDown<T>;

            if (control != null && args != null)
            {
                RoutedPropertyChangedEventArgs<T> e = new RoutedPropertyChangedEventArgs<T>((T)args.OldValue, (T)args.NewValue, MaxValueChangedEvent);
                control.OnMaxValueChanged(e);

                control.CoerceValue(ValueProperty);
            }
        }

        private static object CoerceMaxValue(DependencyObject element, object value)
        {
            var control = element as AbstractBaseUpDown<T>;

            try
            {
                T newValue = (T)value;

                if (control != null)
                    return control.CoerceMaxValue(newValue);

                return newValue;
            }
            catch (Exception)
            {
            }

            return control.MaxValue;
        }
        #endregion Value dependency property helper methods

        #region DisplayLength IsDisplayLengthFixed
        /// <summary>
        /// Sets or unsets the binding between measuring and user textbox.
        /// </summary>
        /// <param name="SetBinding"></param>
        private void BindMeasuringObject(bool SetBinding = true)
        {
            BindMeasuringObject(_PART_TextBox, _PART_Measuring_Element, SetBinding);
        }

        /// <summary>
        /// Sets or Unsets a binding between a
        /// - MeasuringControl.ActualWidth and
        /// - UserControl.MaxWidth
        /// 
        /// Both controls can be any <see cref="FrameworkElement"/>.
        /// </summary>
        /// <param name="UserControl"></param>
        /// <param name="MeasuringControl"></param>
        /// <param name="SetBinding"></param>
        private void BindMeasuringObject(FrameworkElement UserControl,
                                         FrameworkElement MeasuringControl,
                                         bool SetBinding = true)
        {
            if (UserControl != null)
            {
                UserControl.ClearValue(FrameworkElement.MaxWidthProperty);

                if (SetBinding == true && MeasuringControl != null)
                {
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("ActualWidth");
                    binding.Source = MeasuringControl;

                    BindingOperations.SetBinding(UserControl, FrameworkElement.MaxWidthProperty, binding);
                }
            }
        }

        /// <summary>
        /// Method is invoked when the value of the <see cref="IsDisplayLengthFixed"/>
        /// dependency property is changed. This results in changing the behavior of
        /// the textbox resizing which in turn is dependent on the binding between
        /// the PART_TextBox.NaxWidth = PART_Measuring_TextBox.ActualWidh.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnIsDisplayLengthFixedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AbstractBaseUpDown<T>;

            if (control != null && e.NewValue is bool)
                control.BindMeasuringObject((bool)e.NewValue);
        }
        #endregion DisplayLength IsDisplayLengthFixed
        #endregion methods DisplayLength IsDisplayLengthFixed
    }
}