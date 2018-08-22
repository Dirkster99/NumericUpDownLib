namespace ThemedDemo.Demos.ViewModels
{
    /// <summary>
    /// Implements an integer based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class IntegerUpDownViewModel : BaseUpDownViewModel<int>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intMinimumValue"></param>
        /// <param name="intMaximumValue"></param>
        /// <param name="intStepSize"></param>
        public IntegerUpDownViewModel(int intValue,
                                      int intMinimumValue,
                                      int intMaximumValue,
                                      int intStepSize
            )
            : base()
        {
            IntValue = intValue;
            IntMinimumValue = intMinimumValue;
            IntMaximumValue = intMaximumValue;
            IntStepSize = intStepSize;
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
