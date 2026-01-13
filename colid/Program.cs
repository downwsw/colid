using System;
using System.Globalization;

namespace colid
{
    // Task 1
    public interface IShape
    {
        void Draw();
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }

    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Circle();
        }
    }

    public class RectangleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Rectangle();
        }
    }

    // Task 2
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public interface ICoordinatesService
    {
        Coordinates GetCoordinates();
    }

    public class GeoLocation
    {
        public string GetCoordinates()
        {
            return "37.7749, -122.4194";
        }
    }

    public class GeoLocationAdapter : ICoordinatesService
    {
        private GeoLocation _geoLocation;

        public GeoLocationAdapter(GeoLocation geoLocation)
        {
            _geoLocation = geoLocation;
        }

        public Coordinates GetCoordinates()
        {
            string data = _geoLocation.GetCoordinates();
            string[] parts = data.Split(',');

            Coordinates coordinates = new Coordinates();
            coordinates.Latitude = double.Parse(parts[0], CultureInfo.InvariantCulture);
            coordinates.Longitude = double.Parse(parts[1], CultureInfo.InvariantCulture);

            return coordinates;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1:");
            ShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw(); 

            ShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();
            rectangle.Draw(); 

            Console.WriteLine();
            Console.WriteLine("Task 2:");

            GeoLocation geoLocation = new GeoLocation();
            ICoordinatesService coordinatesService = new GeoLocationAdapter(geoLocation);
            var coordinates = coordinatesService.GetCoordinates();
            Console.WriteLine($"Latitude: {coordinates.Latitude}, Longitude: {coordinates.Longitude}");

            Console.ReadLine();
        }
    }
}
