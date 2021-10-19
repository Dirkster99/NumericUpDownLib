namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements a <see cref="byte"/> based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class ByteUpDownViewModel : BaseUpDownViewModel<byte>
    {
		private bool _IsHexDisplayEnabled = false;
		private string _FormatString = "D";
		private string _NumberStyle = "None";

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="value"></param>
		/// <param name="minimumValue"></param>
		/// <param name="maximumValue"></param>
		/// <param name="stepSize"></param>
		/// <param name="largeStepSize"></param>
		public ByteUpDownViewModel(byte value,
                                   byte minimumValue,
                                   byte maximumValue,
                                   byte stepSize,
                                   byte largeStepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
            base.LargeStepSize = largeStepSize;
        }

        /// <summary>Get/set whether value in control should be displayed as normal integer or hex value.</summary>
        public bool IsHexDisplayEnabled
        {
            get
            {
                return _IsHexDisplayEnabled;
            }

            set
            {
                if (_IsHexDisplayEnabled != value)
                {
                    _IsHexDisplayEnabled = value;
                    NotifyPropertyChanged(() => IsHexDisplayEnabled);
                    
                    if (value)
					{
                        this.FormatString = "X2";
                        this.NumberStyle = "HexNumber";
                    }
                    else
					{
                        this.FormatString = "D";
                        this.NumberStyle = "None";
                    }
                }
            }
        }

        /// <summary>Get/sets the FormatString indicator that defines the format of the value display in the textbox portion.</summary>
        public string FormatString
        {
            get
            {
                return _FormatString;
            }

            set
            {
                if (_FormatString != value)
                {
                    _FormatString = value;
                    NotifyPropertyChanged(() => FormatString);
                }
            }
        }

        /// <summary>Get/sets the <seealso cref="System.Globalization.NumberStyles"/> indicator that defines the style of the value display in the textbox portion.</summary>
        public string NumberStyle
        {
            get
            {
                return _NumberStyle;
            }

            set
            {
                if (_NumberStyle != value)
                {
                    _NumberStyle = value;
                    NotifyPropertyChanged(() => NumberStyle);
                }
            }
        }

        /// <summary>
        /// Method determine whether two objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public override bool Compare(byte intValue, byte intValue1)
        {
            return byte.Equals(intValue, intValue1);
        }
    }
}
