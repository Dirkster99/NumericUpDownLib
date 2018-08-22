namespace ThemedDemo.Demos.ViewModels
{
    /// <summary>
    /// Class implements an abstract base class that can be used as viewmodel
    /// for binding to a control that is based on the AbstractBaseUpDown control.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseUpDownViewModel<T> : ThemedDemo.ViewModels.Base.ViewModelBase
    {
        #region fields
        private T _IntValue = default(T);
        private T _IntMinimumValue = default(T);
        private T _IntMaximumValue = default(T);
        private T _IntStepSize = default(T);
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
        public virtual T IntValue
        {
            get
            {
                return _IntValue;
            }

            set
            {
                if (Compare(_IntValue, value) == false)
                {
                    _IntValue = value;
                    NotifyPropertyChanged(() => IntValue);
                }
            }
        }

        /// <summary>
        /// Gets or sets the step size
        /// (actual distance) of increment or decrement step.
        /// This value should at leat be one or greater.
        /// </summary>
        public virtual T IntStepSize
        {
            get
            {
                return _IntStepSize;
            }

            set
            {
                if (Compare(_IntStepSize, value) == false)
                {
                    _IntStepSize = value;
                    NotifyPropertyChanged(() => IntStepSize);
                }
            }
        }

        /// <summary>
        /// Get/set minimum integer Value to be displayed in numeric up/down control
        /// </summary>
        public virtual T IntMinimumValue
        {
            get
            {
                return _IntMinimumValue;
            }

            set
            {
                if (Compare(_IntMinimumValue, value) == false)
                {
                    _IntMinimumValue = value;
                    NotifyPropertyChanged(() => IntMinimumValue);
                }
            }
        }

        /// <summary>
        /// Get/set maximum integer Value to be displayed in numeric up/down control
        /// </summary>
        public virtual T IntMaximumValue
        {
            get
            {
                return _IntMaximumValue;
            }

            set
            {
                if (Compare(_IntMaximumValue, value) == false)
                {
                    _IntMaximumValue = value;
                    NotifyPropertyChanged(() => IntMaximumValue);
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
                    _IntMinimumValue, IntMaximumValue);
            }
        }
        #endregion methods
    }
}
