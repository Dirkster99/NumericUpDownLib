namespace NumericUpDownLib
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// This class serve as target for styling the <see cref="AbstractBaseUpDown{T}"/> class
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
                typeof(bool),
                typeof(InputBaseUpDown), new PropertyMetadata(true));

        private static RoutedCommand mIncreaseCommand;
        private static RoutedCommand mDecreaseCommand;
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

        /// <summary>
        /// Determines whether the textbox portion of the control is editable
        /// (requires additional check of bounds) or not.
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        #endregion properties

        #region Commands
        /// <summary>
        /// Increase the displayed integer value
        /// </summary>
        protected abstract void OnIncrease();
        /***
            if (this.Value >= this.MaxValue)
            {
                // Value is not incremented if it is already maxed or above
                this.Value = this.MaxValue;
            }
            else
            {
                if (this.Value + this.StepSize <= this.MaxValue)
                    this.Value = (this.Value + this.StepSize);
                else
                {
                    if (this.Value <= this.MinValue)
                    {
                        // Value is not incremented if it is already min or below
                        this.Value = this.MinValue;
                    }
                }
            }
        ***/

        /// <summary>
        /// Decrease the displayed integer value
        /// </summary>
        protected abstract void OnDecrease();
        /***
           if (this.Value <= this.MinValue)
            {
                // Value is not decremented if it is already minimum or below
                this.Value = this.MinValue;
            }
            else
            {
                if (this.Value - this.StepSize > this.MinValue)
                    this.Value = (this.Value - this.StepSize);
                else
                {
                    if (this.Value >= this.MaxValue)
                    {
                        // Value is not incremented if it is already maxed or above
                        this.Value = this.MaxValue;
                    }
                }
            }
         ***/

        /// <summary>
        /// Initialize up down/button commands and key gestures for up/down cursor keys
        /// </summary>
        private void InitializeCommands()
        {
            InputBaseUpDown.mIncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(InputBaseUpDown));
            CommandManager.RegisterClassCommandBinding(typeof(InputBaseUpDown),
                                    new CommandBinding(mIncreaseCommand, OnIncreaseCommand));

            CommandManager.RegisterClassInputBinding(typeof(InputBaseUpDown),
                                    new InputBinding(mIncreaseCommand, new KeyGesture(Key.Up)));

            InputBaseUpDown.mDecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(InputBaseUpDown));

            CommandManager.RegisterClassCommandBinding(typeof(InputBaseUpDown),
                                    new CommandBinding(mDecreaseCommand, OnDecreaseCommand));

            CommandManager.RegisterClassInputBinding(typeof(InputBaseUpDown),
                                    new InputBinding(mDecreaseCommand, new KeyGesture(Key.Down)));
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
        #endregion

    }
}
