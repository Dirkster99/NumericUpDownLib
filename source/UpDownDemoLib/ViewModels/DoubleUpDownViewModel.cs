namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    public class DoubleUpDownViewModel : BaseUpDownViewModel<double>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intMinimumValue"></param>
        /// <param name="intMaximumValue"></param>
        /// <param name="intStepSize"></param>
        public DoubleUpDownViewModel(double intValue,
                                     double intMinimumValue,
                                     double intMaximumValue,
                                     double intStepSize
            )
            : base()
        {
            IntValue = intValue;
            IntMinimumValue = intMinimumValue;
            IntMaximumValue = intMaximumValue;
            IntStepSize = intStepSize;
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
