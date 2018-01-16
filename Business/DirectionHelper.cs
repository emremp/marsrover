using System;
using System.Collections.Generic;

namespace Business
{
	public static class DirectionHelper
	{
		public static List<CompassDirection> CompassDirectionsOnClockWise = new List<CompassDirection>(){
			CompassDirection.North,
			CompassDirection.East,
			CompassDirection.South,
			CompassDirection.West
		};

		public static CompassDirection GetLeftCompassDirection (CompassDirection direction)
		{
			var indexComp = CompassDirectionsOnClockWise.IndexOf(direction);
			if (indexComp == 0) {
				return CompassDirectionsOnClockWise [CompassDirectionsOnClockWise.Count - 1];
			}

			var itemPrevForLeft = CompassDirectionsOnClockWise[(indexComp - 1)];
			return itemPrevForLeft;
		}

		public static CompassDirection GetRightCompassDirection (CompassDirection direction)
		{
			var indexComp = CompassDirectionsOnClockWise.IndexOf(direction);
			if (indexComp == CompassDirectionsOnClockWise.Count - 1) {
				return CompassDirectionsOnClockWise [0];
			}

			var itemNextForRight = CompassDirectionsOnClockWise[(indexComp + 1)];
			return itemNextForRight;
		}
	}
}

