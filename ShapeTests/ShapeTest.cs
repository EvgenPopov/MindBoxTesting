using NUnit.Framework;
using ShapeSquare.Impl;

namespace ShapeTests
{
    public class Tests
    {
        [Test]
        public void CirlceInvalidTest() =>Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));

        [Test]
        public async Task CircleSquareTest()
        {
            var circle = new Circle(1);

            double expectedSquare = 3.141592653589793;

            Assert.That(expectedSquare, Is.EqualTo(circle.GetSquare()));
            Assert.That(expectedSquare, Is.EqualTo(await circle.GetSquareAsync()));
            Assert.That(expectedSquare, Is.EqualTo(circle.Square));
        }

        [Test]
        public void TriangleInvalideSidesTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -2, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, -2, -2));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0.5, 0.5, 1));
        }

        [Test]
        public async Task TriangleSquareTest()
        {
            var triangle = new Triangle(4, 6, 8);

            double square = 11.61895003862225;

            Assert.That(square, Is.EqualTo(triangle.GetSquare()));

            Assert.That(square, Is.EqualTo(triangle.Square));

            Assert.That(square, Is.EqualTo(await triangle.GetSquareAsync()));
        }

        [Test]
        public void IsRightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.IsRightTriangle, Is.True);
        }

        [Test]
        public void IsNotRightTriangle()
        {
            var triangle = new Triangle(1, 1, 1);

            Assert.That(triangle.IsRightTriangle, Is.False);
        }

    }
}