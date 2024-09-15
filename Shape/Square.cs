namespace Shape;

class Square : Shape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public override double GetArea() => Side * Side;
    public override double GetPerimeter() => 4 * Side;

    public override void DisplayProperties()
    {
        Console.WriteLine($"Квадрат: сторона = {Side}, площадь = {GetArea()}, периметр = {GetPerimeter()}");
    }
}
