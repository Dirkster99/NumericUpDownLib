namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements an <see cref="int"/>  based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class IntegerUpDownViewModel : BaseUpDownViewModel<int>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        /// <param name="largeStepSize"></param>
        public IntegerUpDownViewModel(int value,
                                      int minimumValue,
                                      int maximumValue,
                                      int stepSize,
                                      int largeStepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
            base.LargeStepSize = largeStepSize;
        }

        /// <summary>
        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public override bool Compare(int intValue, int intValue1)
        {
            return int.Equals(intValue, intValue1);
        }
    }
}
