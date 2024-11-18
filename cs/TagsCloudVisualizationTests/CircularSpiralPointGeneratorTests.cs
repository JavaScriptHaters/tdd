using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization.PointGenerators;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class CircularSpiralPointGeneratorTests
{
    private static readonly Point DefaultCenter = new(0, 0);
    private readonly double defaultRadius = 1;
    private readonly double defaultAngleOffset = 10;

    [TestCase(-1, 1, TestName = "WithNegativeRadius")]
    [TestCase(0, 1, TestName = "WithZeroRadius")]
    [TestCase(1, -1, TestName = "WithNegativeAngelOffset")]
    [TestCase(1, 0, TestName = "WithZeroAngelOffset")]
    public void CircularSpiralPointGenerator_WhenIncorrectArgs_ThrowArgumentException(double radius, double angleOffset)
    {
        var creation = () => new CircularSpiralPointGenerator(radius, angleOffset, DefaultCenter);

        creation.Should().Throw<ArgumentException>();

    }

    [Test]
    public void CircularSpiralPointGenerator_WhenCorrectArgs_NotThrowArgumentException()
    {
        var creation = () => new CircularSpiralPointGenerator(5, 90, DefaultCenter);

        creation.Should().NotThrow<ArgumentException>();

    }

    [Test]
    public void GetPoint_ReturnCorrectPoints()
    {
        var spiral = new CircularSpiralPointGenerator(3, 100, DefaultCenter);
        var actualPoins = new Point[6];
        Point[] correctPoints =
        {
            new Point(0, 0),
            new Point(0, 1),
            new Point(-2, -1),
            new Point(1, -2),
            new Point(3, 2),
            new Point(-3, 3)
        };
        var pointNumber = correctPoints.Length;

        for (var i = 0; i < pointNumber; i++)
        {
            actualPoins[i] = spiral.GetPoint();
        }

        actualPoins.Should().BeEquivalentTo(correctPoints);
    }
}