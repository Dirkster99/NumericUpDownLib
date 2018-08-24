namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    public class DoubleUpDownViewModel : BaseUpDownViewModel<double>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        public DoubleUpDownViewModel(double value,
                                     double minimumValue,
                                     double maximumValue,
                                     double stepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
        }

        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        public override bool Compare(double intValue, double intValue1)
        {
            return int.Equals(intValue, intValue1);
        }
    }
}
