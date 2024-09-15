namespace Shape;

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea() => Math.PI * Radius * Radius;
    public override double GetPerimeter() => 2 * Math.PI * Radius;

    public override void DisplayProperties()
    {
        Console.WriteLine($"Круг: радиус = {Radius}, площадь = {GetArea()}, периметр = {GetPerimeter()}");
    }
}