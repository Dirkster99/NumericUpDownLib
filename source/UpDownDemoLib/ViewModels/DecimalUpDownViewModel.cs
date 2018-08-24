namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements an integer based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class DecimalUpDownViewModel : BaseUpDownViewModel<decimal>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        public DecimalUpDownViewModel(decimal value,
                                      decimal minimumValue,
                                      decimal maximumValue,
                                      decimal stepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
        }

        /// <summary>
        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public override bool Compare(decimal intValue, decimal intValue1)
        {
            return decimal.Equals(intValue, intValue1);
        }
    }
}
