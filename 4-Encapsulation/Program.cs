var rectangle = new Rectangle(5, 1);
var cal = new ShapesMeasurementsCalculator();
Console.WriteLine("Area is " + cal.CalculateRectangleArea(rectangle) );
Console.WriteLine("Circumference is " + cal.CalculateRectangleCircumference(rectangle));

class Rectangle
{
    public int Width;
    public int Height; 
    public Rectangle (int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}

class ShapesMeasurementsCalculator
{
    public int CalculateRectangleCircumference(Rectangle rectangle)
    {
        return 2 * (rectangle.Width + rectangle.Height);
    }

    public int CalculateRectangleArea(Rectangle rectangle)
    {
        return rectangle.Width * rectangle.Height;
    }
}