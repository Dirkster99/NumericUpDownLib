using System.Windows;

namespace NumericUpDownLib.Models
{
    class MouseIncrementor
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
        public MouseDirections MouseDirection
        {
            get
            {
                return _enumMouseDirection;
            }

            set
            {
                _enumMouseDirection = value;
            }
        }

        public Point InitialPoint
        {
            get
            {
                return _initialPoint;
            }
        }

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
        #endregion properties
    }
}
