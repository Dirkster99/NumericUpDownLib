namespace UpDownDemoLib.Demos.ViewModels
{
    /// <summary>
    /// This viewmodel controls all aspects of the themed control demo
    /// in this test application.
    /// </summary>
    public class DemoViewModel : UpDownDemoLib.ViewModels.Base.ViewModelBase
    {
        #region private fields
        private ByteUpDownViewModel _ByteDemo;
        private DecimalUpDownViewModel _DecimalDemo;
        private DoubleUpDownViewModel _DoubleDemo;
        private IntegerUpDownViewModel _IntegerDemo;
        #endregion private fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        public DemoViewModel()
        {
            _ByteDemo = new ByteUpDownViewModel(5, 0, 255, 1);
            _DecimalDemo = new DecimalUpDownViewModel(0, 7922816251426433, 792281625142643375933950335M, 792281);
            _DoubleDemo = new DoubleUpDownViewModel(50, 0, 100, 1);
            _IntegerDemo = new IntegerUpDownViewModel(98, -3, 105, 1);
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// Gets byte data type demo viewmodel to be displayed
        /// in a byte based numeric up/down control
        /// </summary>
        public ByteUpDownViewModel ByteDemo
        {
            get
            {
                return _ByteDemo;
            }
        }

        /// <summary>
        /// Gets Decimal data type demo viewmodel to be displayed
        /// in a Decimal based numeric up/down control
        /// </summary>
        public DecimalUpDownViewModel DecimalDemo
        {
            get
            {
                return _DecimalDemo;
            }
        }

        /// <summary>
        /// Gets Integer data type demo viewmodel to be displayed
        /// in a Integer based numeric up/down control
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
