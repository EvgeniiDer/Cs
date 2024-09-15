namespace Shape;

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea() => Width * Height;
    public override double GetPerimeter() => 2 * (Width + Height);

    public override void DisplayProperties()
    {
        Console.WriteLine($"Прямоугольник: ширина = {Width}, высота = {Height}, площадь = {GetArea()}, периметр = {GetPerimeter()}");
    }
}