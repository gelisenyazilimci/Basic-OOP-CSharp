var rectangle = new Rectangle(5, 10);

var rectangleArea = rectangle.Width * rectangle.Height;


internal class Rectangle
{
    public int Width;
    public int Height;

    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }
}