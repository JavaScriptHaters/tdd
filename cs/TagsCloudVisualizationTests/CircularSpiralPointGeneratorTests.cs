using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization.PointGenerators;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class CircularSpiralPointGeneratorTests
{
    private CircularSpiralPointGenerator spiral;
    private Point center;

    [SetUp]
    public void Setup()
    {
        center = new Point(0, 0);
        spiral = new CircularSpiralPointGenerator(3, 100, center);
    }

    [TestCase(-1, 1, TestName = "WithNegativeRadius")]
    [TestCase(0, 1, TestName = "WithZeroRadius")]
    [TestCase(1, -1, TestName = "WithNegativeAngelOffset")]
    [TestCase(1, 0, TestName = "WithZeroAngelOffset")]
    public void CircularSpiralPointGenerator_WhenIncorrectArgs_ThrowArgumentException(double radius, double angleOffset)
    {
        var creation = () => new CircularSpiralPointGenerator(radius, angleOffset, center);
        creation.Should().Throw<ArgumentException>();

    }

    [TestCase(5, 90)]
    public void CircularSpiralPointGenerator_WhenCorrectArgs_NotThrowArgumentException(double radius, double angleOffset)
    {
        var creation = () => new CircularSpiralPointGenerator(radius, angleOffset, center);
        creation.Should().NotThrow<ArgumentException>();

    }

    [TestCaseSource(nameof(CorrectPointsCaseData))]
    public Point GetPoint_ReturnCorrectPoint(int pointNumber)
    {
        for (int i = 1; i < pointNumber; i++)
        {
            spiral.GetPoint();
        }

        return spiral.GetPoint();
    }

    public static TestCaseData[] CorrectPointsCaseData=
    {
        new TestCaseData(1).Returns(new Point(0, 0)),
        new TestCaseData(2).Returns(new Point(0, 1)),
        new TestCaseData(3).Returns(new Point(-2, -1)),
        new TestCaseData(4).Returns(new Point(1, -2)),
        new TestCaseData(5).Returns(new Point(3, 2)),
        new TestCaseData(6).Returns(new Point(-3, 3))
    };

}