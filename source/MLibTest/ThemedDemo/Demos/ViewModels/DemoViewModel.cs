namespace ThemedDemo.Demos.ViewModels
{
    /// <summary>
    /// This viewmodel controls all aspects of the themed control demo
    /// in this test application.
    /// </summary>
    public class DemoViewModel : ThemedDemo.ViewModels.Base.ViewModelBase
    {
        #region private fields
        private IntegerUpDownViewModel _IntegerDemo = null;
        private DoubleUpDownViewModel _DoubleDemo = null;
        #endregion private fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        public DemoViewModel()
        {
            _IntegerDemo = new IntegerUpDownViewModel(98, -3, 105, 1);
            _DoubleDemo = new DoubleUpDownViewModel(98, -3, 105, 1);
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// Gets integer data type demo viewmodel to be displayed
        /// in an integer based numeric up/down control
        /// </summary>
        public IntegerUpDownViewModel IntegerDemo
        {
            get
            {
                return _IntegerDemo;
            }
        }

        /// <summary>
        /// Gets double data type demo viewmodel to be displayed
        /// in a double type based numeric up/down control
        /// </summary>
        public DoubleUpDownViewModel DoubleDemo
        {
            get
            {
                return _DoubleDemo;
            }
        }
        #endregion properties
    }
}
