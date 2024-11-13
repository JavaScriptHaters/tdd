using FluentAssertions;
using System.Drawing;
using TagsCloudVisualization;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class TagsCloudVisualizationTests
{
    CircularCloudLayouter circularCloudLayouter;

    [SetUp]
    public void Setup()
    {
    }

    [TestCase(5, 5, TestName = "x equal y and greater than zero")]
    [TestCase(5, 15, TestName = "x and y are different and greater than zero")]
    [TestCase(0, 0, TestName = "x and y are zero")]
    public void CircularCloudLayouter_WhenCorrectArgs_NotThrowArgumentException(int x, int y)
    {
        Action act = () => new CircularCloudLayouter(new Point(x, y));
        act.Should().NotThrow<ArgumentException>();
    }

    [TestCase(-5, -5, TestName = "x equal y and less than zero")]
    [TestCase(-5, 5, TestName = "x less than zero")]
    [TestCase(5, -5, TestName = "y less than zero")]
    public void CircularCloudLayouter_WhenIncorrectArgs_ThrowArgumentException(int x, int y)
    {
        Action act = () => new CircularCloudLayouter(new Point(x, y));
        act.Should().Throw<ArgumentException>();
    }

    [TestCase(-5, -5, TestName = "width equal height and less than zero")]
    [TestCase(-5, 5, TestName = "width less than zero")]
    [TestCase(5, -5, TestName = "height less than zero")]
    [TestCase(0, 0, TestName = "width and height are zero")]
    public void PutNextRectangle_WhenIncorrectArgs_ThrowArgumentException(int width, int height)
    {
        circularCloudLayouter = new CircularCloudLayouter(new Point(600, 600));

        Action act = () => circularCloudLayouter.PutNextRectangle(new Size(width, height));
        act.Should().Throw<ArgumentException>();
    }
}