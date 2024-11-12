using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter : ICloudLayouter
{
    public CircularCloudLayouter(Point center)
    {
        if (center.X < 0 || center.Y < 0)
            throw new ArgumentException("X or Y must be positive");
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        return Rectangle.Empty;
    }
}