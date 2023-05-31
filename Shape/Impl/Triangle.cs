using ShapeSquare.Abstract;

namespace ShapeSquare.Impl
{
    public class Triangle : Shape
    {
        /// <summary>
        /// FirstSide
        /// </summary>
        public double FirstSide { get; }

        /// <summary>
        /// SecondSide
        /// </summary>
        public double SecondSide { get; }

        /// <summary>
        /// ThirdSide
        /// </summary>
        public double ThirdSide { get; }

        /// <summary>
        /// Is triangle right or not
        /// </summary>
        public bool IsRightTriangle { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="firstSide">firstSide</param>
        /// <param name="secondSide">secondSide</param>
        /// <param name="thirdSide">thirdSide</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws if sides are not correct or triangle isn't right</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {

            if (firstSide < 0)
                throw new ArgumentOutOfRangeException($"Side is incorrect {nameof(firstSide)}");
            if (secondSide < 0)
                throw new ArgumentOutOfRangeException($"Side is incorrect {nameof(secondSide)}");
            if (thirdSide < 0)
                throw new ArgumentOutOfRangeException($"Side is incorrect {nameof(thirdSide)}");

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            if (!IsTriangleValid())
                throw new ArgumentOutOfRangeException("The sides of the triangle are wrong");

            IsRightTriangle = IsRight();
        }

        /// <summary>
        /// Calculate is right triangle or npt
        /// </summary>
        /// <returns><b>Returns</b> <see cref="bool"/> value - is triangle valid or not</returns>
        private bool IsRight()
        {
            double hypo = FirstSide, firstLeg = SecondSide, secondLeg = ThirdSide;

            if (firstLeg - hypo > 0)
                (hypo, firstLeg) = (firstLeg, hypo);

            if (secondLeg - hypo > 0)
                (hypo, secondLeg) = (secondLeg, hypo);

            return Math.Abs(Math.Pow(hypo, 2) - Math.Pow(firstLeg, 2) - Math.Pow(secondLeg, 2)) == 0;
        }

        /// <summary>
        /// Validation of triangle sides
        /// </summary>
        /// <returns><b>Returns</b> the validation triangle sides result (<see cref="double"/>)</returns>
        private bool IsTriangleValid()
        {
            var maxSide = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));
            var perimeter = GetPerimeter();
            return (perimeter - maxSide) - maxSide > 0.00;
        }

        /// <summary>
        /// Get perimeter of triangle
        /// </summary>
        /// <returns><b>Returns</b> the triangles perimeter (<see cref="double"/>)</returns>
        private double GetPerimeter() => FirstSide + SecondSide + ThirdSide;


        /// <summary>
        /// Get triangle square
        /// </summary>
        /// <returns><b>Returns</b> <see cref="Task"/> for async impl</returns>
        public override Task<double> GetSquareAsync() => Task.FromResult(GetSquare());


        /// <summary>
        /// Triangle square
        /// </summary>
        /// <returns><b>Returns</b> the square of triangle (<see cref="double"/>)</returns>
        public override double GetSquare()
        {
            double semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }
    }
}
