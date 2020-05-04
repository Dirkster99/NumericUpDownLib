namespace NumericUpDownLib.Themes
{
	using System.Windows;

	/// <summary>
	/// Resource key management class to keep track of all resources
	/// that can be re-styled in applications that make use of the implemented controls.
	/// </summary>
	public static class ResourceKeys
	{
		#region Accent Keys
		/// <summary>
		/// Accent Color Key - This Color key is used to accent elements in the UI
		/// (e.g.: Color of Activated Normal Window Frame, ResizeGrip, Focus or MouseOver input elements)
		/// </summary>
		public static readonly ComponentResourceKey ControlAccentColorKey = new ComponentResourceKey(typeof(ResourceKeys), "ControlAccentColorKey");

		/// <summary>
		/// Accent Brush Key - This Brush key is used to accent elements in the UI
		/// (e.g.: Color of Activated Normal Window Frame, ResizeGrip, Focus or MouseOver input elements)
		/// </summary>
		public static readonly ComponentResourceKey ControlAccentBrushKey = new ComponentResourceKey(typeof(ResourceKeys), "ControlAccentBrushKey");
		#endregion Accent Keys

		#region Brush Keys
		/// <summary>
		/// Resource key of the controls normal glyph brush key.
		/// </summary>
		public static readonly ComponentResourceKey GlyphNormalForegroundKey = new ComponentResourceKey(typeof(ResourceKeys), "GlyphNormalForegroundKey");

		/// <summary>
		/// Resource key of the controls normal glyph brush key.
		/// </summary>
		public static readonly ComponentResourceKey GlyphMouseOverForegroundKey = new ComponentResourceKey(typeof(ResourceKeys), "GlyphMouseOverForegroundKey");

		/// <summary>
		/// Resource key of the controls disabled glyph brush key.
		/// </summary>
		public static readonly ComponentResourceKey GlyphDisabledForegroundKey = new ComponentResourceKey(typeof(ResourceKeys), "GlyphDisabledForegroundKey");

		/// <summary>
		/// Resource key of the controls disabled glyph brush key.
		/// </summary>
		public static readonly ComponentResourceKey GlyphPressedBackroundKey = new ComponentResourceKey(typeof(ResourceKeys), "GlyphPressedBackroundKey");
		#endregion Brush Keys
	}
}
