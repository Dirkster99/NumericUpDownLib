namespace NumericUpDownLib.Converters
{
	using System;
	using System.Globalization;
	using System.Windows.Data;

	/// <summary>
	/// Converts a byte number into a string that contains the number 'X' characters input.
	/// The output of this converter can be used to measure UI Air space to ensure enough
	/// space for input controls...
	/// </summary>
	[ValueConversion(typeof(byte), typeof(string))]
	public sealed class ByteToPlaceHolderStringConverter : IValueConverter
	{
		/// <summary>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((value is byte) == false)
				return Binding.DoNothing;

			byte byteVal = (byte)value;

			string retString = string.Empty;
			for (int i = 0; i < byteVal; i++)
				retString = retString + "X";

			return retString;
		}

		/// <summary>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
