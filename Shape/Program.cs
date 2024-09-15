using System;
using System.Collections.Generic;
namespace Shape{
class Program
{
    static void Main()
    {
        Random random = new Random();
        List<Shape> shapes = new List<Shape>();

        for (int i = 0; i < 10; i++)
        {
            int shapeType = random.Next(4);
            switch (shapeType)
            {
                case 0:
                    shapes.Add(new Square(random.Next(1, 10)));
                    break;
                case 1:
                    shapes.Add(new Rectangle(random.Next(1, 10), random.Next(1, 10)));
                    break;
                case 2:
                    shapes.Add(new Circle(random.Next(1, 10)));
                    break;
                case 3:
                    shapes.Add(new Triangle(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10)));
                    break;
            }
        }

        foreach (var shape in shapes)
        {
            shape.DisplayProperties();
        }
    }
}
}
