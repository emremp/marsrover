using System;
using System.ComponentModel;

namespace Business
{
	public enum CompassDirection
	{
		[Description("N")]
		North,
		[Description("E")]
		East,
		[Description("S")]
		South,
		[Description("W")]
		West
	}

}

