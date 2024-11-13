using System.Drawing;
using TagsCloudVisualization.PointGenerators;

namespace TagsCloudVisualization.Layouters;

public class CircularCloudLayouter : ICloudLayouter
{
    private Point center;
    private List<Rectangle> rectangles;
    private int counter = 0;
    private SpiralSquarePointGenerator pointsGenerator;

    public CircularCloudLayouter(Point center)
    {
        if (center.X < 0 || center.Y < 0)
            throw new ArgumentException("X or Y must be positive");

        this.center = center;
        rectangles = new List<Rectangle>();
        pointsGenerator = new SpiralSquarePointGenerator();
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        if (rectangleSize.Height <= 0 || rectangleSize.Width <= 0)
            throw new ArgumentException("X or Y is negative!");

        if (counter == 0)
        {
            counter++;
            pointsGenerator.InitFirstRectangle(center, rectangleSize);
            return pointsGenerator.GetCurrentRectangle();
        }
        else
        {
            pointsGenerator.CalculateRectangle(rectangleSize);
            return pointsGenerator.GetCurrentRectangle();
        }
    }
}