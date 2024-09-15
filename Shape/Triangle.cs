namespace Shape;

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double GetArea()
    {
        double s = GetPerimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override double GetPerimeter() => A + B + C;

    public override void DisplayProperties()
    {
        Console.WriteLine($"Треугольник: стороны = {A}, {B}, {C}, площадь = {GetArea()}, периметр = {GetPerimeter()}");
    }
}
