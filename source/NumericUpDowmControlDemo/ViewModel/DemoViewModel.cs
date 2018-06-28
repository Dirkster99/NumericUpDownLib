using System.ComponentModel;
namespace NumericUpDowmControlDemo.ViewModel
{
    /// <summary>
    /// Viewmodel class to demonstrate the usage
    /// of a bound numeric up/down control.
    /// </summary>
    public class DemoViewModel : Base.ViewModelBase
    {
        #region fields
        private int _MyIntValue = 98;
        private int _MyIntMinimumValue = -3;
        private int _MyIntMaximumValue = 105;
        private uint _MyIntStepSize = 1;
        #endregion fields

        #region properties
        /// <summary>
        /// Get/set integer Value to be displayed in numeric up/down control
        /// </summary>
        public int MyIntValue
        {
            get
            {
                return this._MyIntValue;
            }

            set
            {
                if (this._MyIntValue != value)
                {
                    this._MyIntValue = value;
                    this.NotifyPropertyChanged(() => this.MyIntValue);
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
                    this.NotifyPropertyChanged(() => MyIntStepSize);
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
                return this._MyIntMinimumValue;
            }

            set
            {
                if (this._MyIntMinimumValue != value)
                {
                    this._MyIntMinimumValue = value;
                    this.NotifyPropertyChanged(() => this.MyIntMinimumValue);
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
                return this._MyIntMaximumValue;
            }

            set
            {
                if (this._MyIntMaximumValue != value)
                {
                    this._MyIntMaximumValue = value;
                    this.NotifyPropertyChanged(() => this.MyIntMaximumValue);
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
                return string.Format("Enter a value between {0} and {1}", this._MyIntMinimumValue, this.MyIntMaximumValue);
            }
        }
        #endregion properties
    }
}
