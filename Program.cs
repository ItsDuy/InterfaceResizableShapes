namespace InterfaceResizableShapes;
public class Circle : Resizeable
{
    private double radius;

    public Circle()
    {
        this.radius = 1.0;
    }

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double GetRadius()
    {
        return radius;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public void Resize(double percent)
    {
        radius += radius * percent / 100;
    }

    public override string ToString()
    {
        return $"Circle[radius={radius}, area={GetArea()}]";
    }
}

public class Rectangle : Resizeable
{
    private double width;
    private double height;

    public Rectangle()
    {
        this.width = 1.0;
        this.height = 1.0;
    }

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double GetWidth()
    {
        return width;
    }

    public void SetWidth(double width)
    {
        this.width = width;
    }

    public double GetHeight()
    {
        return height;
    }

    public void SetHeight(double height)
    {
        this.height = height;
    }

    public double GetArea()
    {
        return width * height;
    }

    public void Resize(double percent)
    {
        width += width * percent / 100;
        height += height * percent / 100;
    }

    public override string ToString()
    {
        return $"Rectangle[width={width}, height={height}, area={GetArea()}]";
    }
}

public class Square : Rectangle
{
    public Square() : base()
    { }

    public Square(double side) : base(side, side)
    { }

    public double GetSide()
    {
        return GetWidth();
    }

    public void SetSide(double side)
    {
        SetWidth(side);
        SetHeight(side);
    }

    public override string ToString()
    {
        return $"Square[side={GetSide()}, area={GetArea()}]";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        Resizeable[] shapes = new Resizeable[3];
        shapes[0] = new Circle(5.0);
        shapes[1] = new Rectangle(4.0, 6.0);
        shapes[2] = new Square(4.0);

        foreach (var shape in shapes)
        {
            Console.WriteLine("Before resize: " + shape.ToString());
            double percent = rand.Next(1, 101);
            shape.Resize(percent);
            Console.WriteLine($"After resize by {percent}%: " + shape.ToString());
            Console.WriteLine();
        }
    }
}
