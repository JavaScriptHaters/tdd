using FluentAssertions;
using System.Drawing;
using TagsCloudVisualization.Layouters;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class CircularCloudLayouterTests
{
    private CircularCloudLayouter circularCloudLayouter;

    [Test]
    public void CircularCloudLayouter_WhenCorrectArgs_NotThrowArgumentException()
    {
        Action act = () => new CircularCloudLayouter(new Point(5, 15));

        act.Should().NotThrow<ArgumentException>();
    }

    [TestCase(-5, -5, TestName = "WithNegativeXAndY")]
    [TestCase(-5, 5, TestName = "WithNegativeX")]
    [TestCase(5, -5, TestName = "WithNegativeY")]
    public void CircularCloudLayouter_WhenIncorrectArgs_ThrowArgumentException(int x, int y)
    {
        Action act = () => new CircularCloudLayouter(new Point(x, y));

        act.Should().Throw<ArgumentException>();
    }

    [TestCase(-5, -5, TestName = "WithNegativeWidthAndHeight")]
    [TestCase(-5, 5, TestName = "WithNegativeWidth")]
    [TestCase(5, -5, TestName = "WithNegativeHeight")]
    [TestCase(0, 0, TestName = "WithZeroWidthAndHeight")]
    public void PutNextRectangle_WhenIncorrectArgs_ThrowArgumentException(int width, int height)
    {
        circularCloudLayouter = new CircularCloudLayouter(new Point(600, 600), 1, 90);

        Action act = () => circularCloudLayouter.PutNextRectangle(new Size(width, height));

        act.Should().Throw<ArgumentException>();
    }
}