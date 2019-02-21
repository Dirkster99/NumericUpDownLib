namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements an <see cref="float"/>  based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class FloatUpDownViewModel : BaseUpDownViewModel<float>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        /// <param name="largeStepSize"></param>
        public FloatUpDownViewModel(float value,
                                    float minimumValue,
                                    float maximumValue,
                                    float stepSize,
                                    float largeStepSize
            )
            : base()
        {
            base.Value = value;
            base.MinimumValue = minimumValue;
            base.MaximumValue = maximumValue;
            base.StepSize = stepSize;
            base.LargeStepSize = largeStepSize;
        }

        /// Method determine whether to objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        public override bool Compare(float intValue, float intValue1)
        {
            return float.Equals(intValue, intValue1);
        }
    }
}
