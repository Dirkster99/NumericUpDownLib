namespace NumericUpDownLib.Enums
{
	/// <summary>
	/// Defines the mouse drag modes that are supported to increment/decrement
	/// small/large values allowing horizontal/vertical mouse drag moves at the same
	/// time or each direction only by itself.
	/// </summary>
	public enum CanIncDecMouseDrag
	{
		/// <summary>
		/// A value can be incremented/decremented in small steps using vertical mouse drag moves only.
		/// </summary>
		VerticalOnly,

		/// <summary>
		/// A value can be incremented/decremented in large steps using horizontal mouse drag moves only.
		/// </summary>
		HorizontalOnly,

		/// <summary>
		/// A value can be incremented/decremented in small steps or large steps
		/// using vertical or horizontal mouse drag moves at the same time.
		/// </summary>
		VerticalHorizontal
	}
}
