using System.Drawing;

namespace TagsCloudVisualization.PointGenerators;

public class CircularSpiralPointGenerator : IPointGenerator
{
    private double angleOffset;
    private double radius;
    private double angle = 0;
    private Point center;

    public CircularSpiralPointGenerator(double radius, double angle, Point center)
    {
        if (radius <= 0)
            throw new ArgumentException("radius must be greater than 0");
        if (angle <= 0)
            throw new ArgumentException("angle must be greater than 0");

        this.radius = radius;
        this.angleOffset = angle * Math.PI / 180;
        this.center = center;
    }

    public Point GetPoint()
    {
        return TransferPolarToEuclideanPoint(this.center, this.angle);
    }

    private Point TransferPolarToEuclideanPoint(Point spiralCenter, double angle)
    {
        var radiusVector = (this.radius / (2 * Math.PI)) * angle;

        var x = (int)Math.Round(
            radiusVector * Math.Cos(angle) + spiralCenter.X);
        var y = (int)Math.Round(
            radiusVector * Math.Sin(angle) + spiralCenter.Y);

        this.angle += angleOffset;

        return new Point(x, y);
    }
}