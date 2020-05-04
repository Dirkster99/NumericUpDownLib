namespace NumericUpDownLib.Models
{
	/// <summary>
	/// Specifies the direction in which the mouse is recognized
	/// to be moved when comparing coordinates for 2 points.
	/// </summary>
	internal enum MouseDirections
	{
		/// <summary>
		/// A mouse movement was not detected.
		/// </summary>
		None,

		/// <summary>
		/// Mouse was moved horizontally rather than vertically.
		/// </summary>
		LeftRight,

		/// <summary>
		/// Mouse was moved vertically rather than horizontally.
		/// </summary>
		UpDown
	}
}
