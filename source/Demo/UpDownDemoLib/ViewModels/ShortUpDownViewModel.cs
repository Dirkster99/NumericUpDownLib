﻿namespace UpDownDemoLib.Demos.ViewModels
{
    using UpDownDemoLib.ViewModels;

    /// <summary>
    /// Implements a <see cref="short"/> based demo viewmodel that can be used
    /// to drive an integer base numeric up down control.
    /// </summary>
    public class ShortUpDownViewModel : BaseUpDownViewModel<short>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <param name="stepSize"></param>
        /// <param name="largeStepSize"></param>
        public ShortUpDownViewModel(short value,
                                    short minimumValue,
                                    short maximumValue,
                                    short stepSize,
                                    short largeStepSize
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
        /// Method determine whether two objects of type {T} are equal.
        /// 
        /// Returns false if both objects are in-equal, otherwise true.
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="intValue1"></param>
        /// <returns></returns>
        public override bool Compare(short intValue, short intValue1)
        {
            return short.Equals(intValue, intValue1);
        }
    }
}
