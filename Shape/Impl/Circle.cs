using ShapeSquare.Abstract;

namespace ShapeSquare.Impl
{
    public sealed class Circle : Shape
    {
        /// <summary>
        /// Radius
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">radius</param>
        /// <exception cref="ArgumentOutOfRangeException">Radius can't be smaller than 0</exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius can't be smaller than 0", nameof(radius));

            Radius = radius;
        }

        /// <summary>
        /// Circle square
        /// </summary>
        /// <returns><b>Returns</b> the square of circle (<see cref="double"/>)</returns>
        public override double GetSquare() => Math.PI * Math.Pow(Radius, 2);


        /// <summary>
        /// Circle square for async impl
        /// </summary>
        /// <returns><b>Returns</b> the square of circle in (<see cref="Task"/>)</returns>
        public override async Task<double> GetSquareAsync() => await Task.FromResult(GetSquare());
    }
}
