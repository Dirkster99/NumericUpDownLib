using System.Windows.Input;

namespace UpDownDemoLib.ViewModels
{
    /// <summary>
    /// Class implements an abstract base class that can be used as viewmodel
    /// for binding to a control that is based on the AbstractBaseUpDown control.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseUpDownViewModel<T> : UpDownDemoLib.ViewModels.Base.ViewModelBase
    {
        #region fields
        private T _Value = default(T);
        private T _MinimumValue = default(T);
        private T _MaximumValue = default(T);
        private T _StepSize = default(T);
        private T _LargeStepSize = default(T);
        private ModifierKeys _AccelModifierKeys = ModifierKeys.Control;
        #endregion fields

        #region CTors
        /// <summary>
        /// Standard hidden class constructor
        /// </summary>
        protected BaseUpDownViewModel()
        {
        }
        #endregion CTors

        #region properties
        /// <summary>
        /// Get/set integer Value to be displayed in numeric up/down control
        /// </summary>
        public virtual T Value
        {
            get
            {
                return _Value;
            }

            set
            {
                if (Compare(_Value, value) == false)
                {
                    _Value = value;
                    NotifyPropertyChanged(() => Value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the step size
        /// (actual distance) of increment or decrement step.
        /// This value should at leat be one or greater.
        /// </summary>
        public virtual T StepSize
        {
            get
            {
                return _StepSize;
            }

            set
            {
                if (Compare(_StepSize, value) == false)
                {
                    _StepSize = value;
                    NotifyPropertyChanged(() => StepSize);
                }
            }
        }

        /// <summary>
        /// Gets or sets the step size
        /// (actual distance) of increment or decrement step.
        /// This value should at leat be one or greater.
        /// </summary>
        public virtual T LargeStepSize
        {
            get
            {
                return _LargeStepSize;
            }

            set
            {
                if (Compare(_LargeStepSize, value) == false)
                {
                    _LargeStepSize = value;
                    NotifyPropertyChanged(() => LargeStepSize);
                }
            }
        }

        /// <summary>
        /// Get/set minimum integer Value to be displayed in numeric up/down control
        /// </summary>
        public virtual T MinimumValue
        {
            get
            {
                return _MinimumValue;
            }

            set
            {
                if (Compare(_MinimumValue, value) == false)
                {
                    _MinimumValue = value;
                    NotifyPropertyChanged(() => MinimumValue);
                }
            }
        }

        /// <summary>
        /// Get/set maximum integer Value to be displayed in numeric up/down control
        /// </summary>
        public virtual T MaximumValue
        {
            get
            {
                return _MaximumValue;
            }

            set
            {
                if (Compare(_MaximumValue, value) == false)
                {
                    _MaximumValue = value;
                    NotifyPropertyChanged(() => MaximumValue);
                }
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public abstract bool Compare(T intValue, T intValue1);

        /// <summary>
        /// Get/set maximum Value of {T} to be displayed in tool tip
        /// of numeric up/down control
        /// </summary>
        public string ToolTip
        {
            get
            {
                return string.Format("Enter a value between {0} and {1}",
                    _MinimumValue, MaximumValue);
            }
        }

        public ModifierKeys AccelModifierKey
        {
            get
            {
                return _AccelModifierKeys;
            }

            set
            {
                if (_AccelModifierKeys != value)
                {
                    _AccelModifierKeys = value;
                    NotifyPropertyChanged(() => AccelModifierKey);
                }
            }
        }
        #endregion methods
    }
}
