namespace NumericUpDownLib.Models
{
	using System;
	using System.Windows;

	/// <summary>
	/// Models a simple object that keeps track of the direction in which
	/// a mouse was moved, its initial coordinates on the screen and its
	/// current location...
	/// </summary>
	internal class MouseIncrementor
	{
		#region fields
		private MouseDirections _enumMouseDirection = MouseDirections.None;
		private Point _objPoint;

		private readonly Point _initialPoint;
		#endregion fields

		#region Ctors
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="objPoint"></param>
		/// <param name="enumMouseDirection"></param>
		public MouseIncrementor(Point objPoint, MouseDirections enumMouseDirection)
		{
			_objPoint = objPoint;
			_initialPoint = _objPoint;
			_enumMouseDirection = enumMouseDirection;
		}
		#endregion Ctors

		#region properties
		/// <summary>
		/// Gets/sets the direction in which a mouse was seen to be moved
		/// when comparing 2 points.
		/// </summary>
		public MouseDirections MouseDirection
		{
			get
			{
				return _enumMouseDirection;
			}

			protected set
			{
				_enumMouseDirection = value;
			}
		}

		/// <summary>
		/// Gets the initial mouse location (eg.: mouse down) in which we've seen the mouse
		/// in the beginning of this processing.
		/// </summary>
		public Point InitialPoint
		{
			get
			{
				return _initialPoint;
			}
		}

		/// <summary>
		/// Gets/sets the current mouse location (eg.: during mouse move)
		/// in which we've seen the mouse last.
		/// </summary>
		public Point Point
		{
			get
			{
				return _objPoint;
			}

			set
			{
				_objPoint = value;
			}
		}

		/// <summary>
		/// Sets the current mouse direction based on the last position stored
		/// in the <see cref="Point"/> property compared to the coordinates in
		/// the <paramref name="pos"/> parameter.
		/// </summary>
		/// <param name="pos"></param>
		/// <returns>The mouse direction that was identified when comparing 2 coordinates.</returns>
		internal MouseDirections SetMouseDirection(Point pos)
		{
			double deltaX = this.Point.X - pos.X;
			double deltaY = this.Point.Y - pos.Y;

			if (Math.Abs(deltaX) > Math.Abs(deltaY))
				MouseDirection = MouseDirections.LeftRight;
			else
			{
				if (Math.Abs(deltaX) < Math.Abs(deltaY))
					MouseDirection = MouseDirections.UpDown;
			}

			return MouseDirection;
		}
		#endregion properties
	}
}
