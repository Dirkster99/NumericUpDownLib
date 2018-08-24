namespace UpDownDemoLib.Demos.ViewModels
{
    /// <summary>
    /// This viewmodel controls all aspects of the themed control demo
    /// in this test application.
    /// </summary>
    public class DemoViewModel : UpDownDemoLib.ViewModels.Base.ViewModelBase
    {
        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        public DemoViewModel()
        {
            ByteDemo = new ByteUpDownViewModel(5, 0, 255, 1);
            DecimalDemo = new DecimalUpDownViewModel(0, 7922816251426433, 792281625142643375933950335M, 792281);
            DoubleDemo = new DoubleUpDownViewModel(50, 0, 100, 1);
            FloatDemo = new FloatUpDownViewModel(5000, 0, 10000000, 1);
            IntegerDemo = new IntegerUpDownViewModel(98, -3, 105, 1);
            LongDemo = new LongUpDownViewModel(980, -3000000, 10500000, 55);
            SByteDemo = new SByteUpDownViewModel(-5, -127, 127, 1);
            ShortDemo = new ShortUpDownViewModel(-5555, short.MinValue, short.MaxValue, 1);

            UShortDemo = new UShortUpDownViewModel(0, ushort.MinValue, ushort.MaxValue, 1);
            UIntegerDemo = new UIntegerUpDownViewModel(0, uint.MinValue, uint.MaxValue, 1);
            ULongDemo = new ULongUpDownViewModel(0, ulong.MinValue, ulong.MaxValue, 1);
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// Gets byte data type demo viewmodel to be displayed
        /// in a byte based numeric up/down control
        /// </summary>
        public ByteUpDownViewModel ByteDemo { get; }

        /// <summary>
        /// Gets Decimal data type demo viewmodel to be displayed
        /// in a Decimal based numeric up/down control
        /// </summary>
        public DecimalUpDownViewModel DecimalDemo { get; }

        /// <summary>
        /// Gets Integer data type demo viewmodel to be displayed
        /// in a Integer based numeric up/down control
        /// </summary>
        public IntegerUpDownViewModel IntegerDemo { get; }

        /// <summary>
        /// Gets <see cref="long"/> data type demo viewmodel to be displayed
        /// in a <see cref="long"/> based numeric up/down control
        /// </summary>
        public LongUpDownViewModel LongDemo { get; }

        /// <summary>
        /// Gets double data type demo viewmodel to be displayed
        /// in a double type based numeric up/down control
        /// </summary>
        public DoubleUpDownViewModel DoubleDemo { get; }

        /// <summary>
        /// Gets <see cref="float"/> data type demo viewmodel to be displayed
        /// in a <see cref="float"/> type based numeric up/down control
        /// </summary>
        public FloatUpDownViewModel FloatDemo { get; }

        /// <summary>
        /// Gets <see cref="sbyte"/> data type demo viewmodel to be displayed
        /// in a <see cref="sbyte"/> type based numeric up/down control
        /// </summary>
        public SByteUpDownViewModel SByteDemo { get; }

        /// <summary>
        /// Gets <see cref="short"/> data type demo viewmodel to be displayed
        /// in a <see cref="short"/> type based numeric up/down control
        /// </summary>
        public ShortUpDownViewModel ShortDemo { get; }

        /// <summary>
        /// Gets <see cref="ushort"/> data type demo viewmodel to be displayed
        /// in a <see cref="ushort"/> type based numeric up/down control
        /// </summary>
        public UShortUpDownViewModel UShortDemo { get; }

        /// <summary>
        /// Gets <see cref="uint"/> data type demo viewmodel to be displayed
        /// in a <see cref="uint"/> type based numeric up/down control
        /// </summary>
        public UIntegerUpDownViewModel UIntegerDemo { get; }

        /// <summary>
        /// Gets <see cref="ulong"/> data type demo viewmodel to be displayed
        /// in a <see cref="ulong"/> type based numeric up/down control
        /// </summary>
        public ULongUpDownViewModel ULongDemo { get; }
        #endregion properties
    }
}
