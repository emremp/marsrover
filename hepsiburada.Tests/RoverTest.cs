using System;
using Business;
using NUnit.Framework;

namespace hepsiburada.Tests
{
    [TestFixture]
    public class RoverTest
    {

        [Test]
        public void TestRoverWithRoute()
        {
            var boundaries = new Plateau { XAxisMin = 0, XAxisMax = 5, YAxisMin = 0, YAxisMax = 5 };

            var rover = new Rover();
            rover.SetRoverBoundaries(boundaries);

            var location = new Location() { xAxis = 1, yAxis = 2, Direction = CompassDirection.North };
            var onSet = rover.InitialLocationSet(location);
            if (onSet)
            {
                var stringRoute = "LMLMLMLMM";
                rover.SetRoute(stringRoute.ToCharArray());

                var result = rover.Navigate();
                var expectedResult = "1 3 N";
                Assert.AreEqual(expectedResult, result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestRoverTurnLeft()
        {
            var boundaries = new Plateau { XAxisMin = 0, XAxisMax = 5, YAxisMin = 0, YAxisMax = 5 };


            var values = Enum.GetValues(typeof(CompassDirection));
            var random = new Random();
            var randomDir = (CompassDirection)values.GetValue(random.Next(values.Length));

            var rover = new Rover();
            rover.SetRoverBoundaries(boundaries);
            var location = new Location() { xAxis = 1, yAxis = 1, Direction = randomDir };
            var onSet = rover.InitialLocationSet(location);

            if (onSet)
            {


                var stringRoute = "L";
                char[] stringRouteCharArr = stringRoute.ToCharArray();

                rover.SetRoute(stringRouteCharArr);
                rover.Navigate();
                var currentLocation = rover.CurrentLocation;

                var expectedResult = DirectionHelper.GetLeftCompassDirection(randomDir).GetDescription();
                Assert.AreEqual(expectedResult, currentLocation.Direction.GetDescription());
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestRoverTurnRight()
        {
            var boundaries = new Plateau { XAxisMin = 0, XAxisMax = 5, YAxisMin = 0, YAxisMax = 5 };


            var values = Enum.GetValues(typeof(CompassDirection));
            var random = new Random();
            var randomDir = (CompassDirection)values.GetValue(random.Next(values.Length));

            var rover = new Rover();
            rover.SetRoverBoundaries(boundaries);
            var location = new Location() { xAxis = 1, yAxis = 1, Direction = randomDir };
            var onSet = rover.InitialLocationSet(location);

            if (onSet)
            {


                var stringRoute = "R";
                rover.SetRoute(stringRoute.ToCharArray());
                rover.Navigate();
                var currentLocation = rover.CurrentLocation;

                var expectedResult = DirectionHelper.GetRightCompassDirection(randomDir).GetDescription();
                Assert.AreEqual(expectedResult, currentLocation.Direction.GetDescription());
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestRoverMove()
        {
            var boundaries = new Plateau { XAxisMin = 0, XAxisMax = 5, YAxisMin = 0, YAxisMax = 5 };

            var values = Enum.GetValues(typeof(CompassDirection));
            var random = new Random();
            var randomDir = (CompassDirection)values.GetValue(random.Next(values.Length));

            var rover = new Rover();
            rover.SetRoverBoundaries(boundaries);
            var location = new Location() { xAxis = 1, yAxis = 1, Direction = randomDir };
            var onSet = rover.InitialLocationSet(location);
            if (onSet)
            {


                var stringRoute = "M";

                rover.SetRoute(stringRoute.ToCharArray());
                rover.Navigate();

                var currentLocation = rover.CurrentLocation;
                var locaXResult = currentLocation.xAxis;
                var locaYResult = currentLocation.yAxis;
                if (randomDir == CompassDirection.North)
                {
                    Assert.AreEqual(locaYResult, 2);
                }
                else if (randomDir == CompassDirection.East)
                {
                    Assert.AreEqual(locaXResult, 2);
                }
                else if (randomDir == CompassDirection.South)
                {
                    Assert.AreEqual(locaYResult, 0);
                }
                else if (randomDir == CompassDirection.West)
                {
                    Assert.AreEqual(locaXResult, 0);
                }
            }
            else
            {
                Assert.Fail();
            }

        }


    }
}

