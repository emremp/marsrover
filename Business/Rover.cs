using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Rover
    {
        public Location CurrentLocation { get; private set; }

        private List<RoverDirection> _routeItemList;

        public List<RoverDirection> RouteItemList
        {
            get { return _routeItemList ?? (_routeItemList = new List<RoverDirection>()); }
        }

        public Plateau CurrentBoundaryArea { get; private set; }

        public void SetRoverBoundaries(Plateau plateau)
        {
            CurrentBoundaryArea = plateau;
        }

        public bool InitialLocationSet(Location location)
        {
            if (CurrentBoundaryArea != null)
            {
                if (CurrentBoundaryArea.XAxisMin > location.xAxis || CurrentBoundaryArea.XAxisMax < location.xAxis ||
                    CurrentBoundaryArea.YAxisMin > location.yAxis || CurrentBoundaryArea.YAxisMax < location.yAxis)
                    return false;
                CurrentLocation = location;
                return true;
            }
            return false;
        }

        public void SetRoute(char[] routes)
        {
            foreach (var route in routes)
            {

                if (RoverDirectionsTranslator.RouteDirectionDictionary.ContainsKey(route))
                {
                    RouteItemList.Add(RoverDirectionsTranslator.RouteDirectionDictionary[route]);
                }
            }
        }

        public string Navigate()
        {
            var sb = new StringBuilder();

            foreach (var item in RouteItemList)
            {
                if (item == RoverDirection.Left)
                {
                    TurnLeft();
                }
                else if (item == RoverDirection.Right)
                {
                    TurnRight();
                }
                else if (item == RoverDirection.Move)
                {
                    Move();
                }

                //sb.AppendFormat ("x: {0}, y: {1}, direction: {2} \r\n", _myLocation.xAxis, _myLocation.yAxis, _myLocation.Direction);
            }

            sb.AppendFormat("{0} {1} {2}", CurrentLocation.xAxis, CurrentLocation.yAxis, CurrentLocation.Direction.GetDescription());

            return sb.ToString();
        }

        private void TurnLeft()
        {
            var newDirection = DirectionHelper.GetLeftCompassDirection(CurrentLocation.Direction);
            CurrentLocation.Direction = newDirection;
        }

        private void TurnRight()
        {
            var newDirection = DirectionHelper.GetRightCompassDirection(CurrentLocation.Direction);
            CurrentLocation.Direction = newDirection;
        }

        private void Move()
        {
            if (CurrentLocation.Direction == CompassDirection.North)
            {
                CurrentLocation.yAxis++;
            }
            else if (CurrentLocation.Direction == CompassDirection.East)
            {
                CurrentLocation.xAxis++;
            }
            else if (CurrentLocation.Direction == CompassDirection.South)
            {
                CurrentLocation.yAxis--;
            }
            else if (CurrentLocation.Direction == CompassDirection.West)
            {
                CurrentLocation.xAxis--;
            }
        }



    }
}

