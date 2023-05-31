namespace ShapeSquare.Abstract
{
    public abstract class Shape
    {
        private readonly Lazy<double> _square;
        public double Square => _square.Value;

        public Shape()
        {
            _square = new Lazy<double>(GetSquare, LazyThreadSafetyMode.PublicationOnly);
        }

        public abstract Task<double> GetSquareAsync();
        public abstract double GetSquare();
    }
}
