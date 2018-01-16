using System.Collections.Generic;

namespace Business
{
    public enum RoverDirection
    {
        Left,
        Right,
        Move
    }

    public static class RoverDirectionsTranslator
    {
        public const char Left = 'L';
        public const char Right = 'R';
        public const char Move = 'M';

        public static IDictionary<char, RoverDirection> RouteDirectionDictionary = new Dictionary<char, RoverDirection>
        {
        	{Left, RoverDirection.Left},
        	{Right, RoverDirection.Right},
        	{Move, RoverDirection.Move}
        };

    }
}

