namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements an <see cref="double"/>  based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class DoubleUpDownViewModel : BaseUpDownViewModel<double>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        /// <param name="largestepSize"></param>
        public DoubleUpDownViewModel(double value,
                                     double minimumValue,
                                     double maximumValue,
                                     double stepSize,
                                     double largestepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
            base.LargeStepSize = largestepSize;
        }

        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        public override bool Compare(double intValue, double intValue1)
        {
            return double.Equals(intValue, intValue1);
        }
    }
}
