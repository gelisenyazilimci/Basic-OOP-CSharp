var rectangle = new Rectangle(5, 10);
Console.WriteLine(rectangle.CalculateCircumference());
Console.WriteLine(rectangle.CalculateArea());

internal class Rectangle
{
    public int Width;
    public int Height;

    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int CalculateCircumference() => 2 * Width + 2 * Height;
    public int CalculateArea() => Width * Height;
}