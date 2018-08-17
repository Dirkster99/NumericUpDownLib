namespace ThemedDemo.Demos.ViewModels
{
    /// <summary>
    /// This viewmodel controls all aspects of the themed control demo in this test application.
    /// </summary>
    public class DemoViewModel : ThemedDemo.ViewModels.Base.ViewModelBase
    {
        #region private fields
        private int _MyIntValue = 98;
        private int _MyIntMinimumValue = -3;
        private int _MyIntMaximumValue = 105;
        private uint _MyIntStepSize = 1;
        #endregion private fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        public DemoViewModel()
        {
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// Get/set integer Value to be displayed in numeric up/down control
        /// </summary>
        public int MyIntValue
        {
            get
            {
                return _MyIntValue;
            }

            set
            {
                if (_MyIntValue != value)
                {
                    _MyIntValue = value;
                    NotifyPropertyChanged(() => MyIntValue);
                }
            }
        }

        /// <summary>
        /// Gets or sets the step size
        /// (actual distance) of increment or decrement step.
        /// This value should at leat be one or greater.
        /// </summary>
        public uint MyIntStepSize
        {
            get
            {
                return _MyIntStepSize;
            }

            set
            {
                if (_MyIntStepSize != value)
                {
                    _MyIntStepSize = value;
                    NotifyPropertyChanged(() => MyIntStepSize);
                }
            }
        }

        /// <summary>
        /// Get/set minimum integer Value to be displayed in numeric up/down control
        /// </summary>
        public int MyIntMinimumValue
        {
            get
            {
                return _MyIntMinimumValue;
            }

            set
            {
                if (_MyIntMinimumValue != value)
                {
                    _MyIntMinimumValue = value;
                    NotifyPropertyChanged(() => MyIntMinimumValue);
                }
            }
        }

        /// <summary>
        /// Get/set maximum integer Value to be displayed in numeric up/down control
        /// </summary>
        public int MyIntMaximumValue
        {
            get
            {
                return _MyIntMaximumValue;
            }

            set
            {
                if (_MyIntMaximumValue != value)
                {
                    _MyIntMaximumValue = value;
                    NotifyPropertyChanged(() => MyIntMaximumValue);
                }
            }
        }

        /// <summary>
        /// Get/set maximum integer Value to be displayed in numeric up/down control
        /// </summary>
        public string MyToolTip
        {
            get
            {
                return string.Format("Enter a value between {0} and {1}", _MyIntMinimumValue, MyIntMaximumValue);
            }
        }
        #endregion properties
    }
}
