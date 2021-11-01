namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements a <see cref="uint"/> based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class UIntegerUpDownViewModel : BaseUpDownViewModel<uint>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        /// <param name="largeStepSize"></param>
        public UIntegerUpDownViewModel(uint value,
                                       uint minimumValue,
                                       uint maximumValue,
                                       uint stepSize,
                                       uint largeStepSize
            )
            : base()
        {
            base._FormatString = "D8";

            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
            base.LargeStepSize = largeStepSize;
        }

        /// <summary>
        /// Method determine whether two objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public override bool Compare(uint intValue, uint intValue1)
        {
            return uint.Equals(intValue, intValue1);
        }
    }
}
