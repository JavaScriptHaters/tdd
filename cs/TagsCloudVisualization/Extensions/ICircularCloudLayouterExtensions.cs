using System.Drawing;
using TagsCloudVisualization.Layouters;

namespace TagsCloudVisualization.Extensions;

public static class ICircularCloudLayouterExtensions
{
    private const int MinRectangleSize = 40;
    private const int MaxRectangleSize = 70;

    public static Rectangle[] GenerateCloud(this ICloudLayouter layouter, int rectanglesNumber = 1000)
    {
        var random = new Random();
        return Enumerable.Range(1, rectanglesNumber)
                .Select(_ => new Size(
                    random.Next(MinRectangleSize, MaxRectangleSize),
                    random.Next(MinRectangleSize, MaxRectangleSize)))
            .Select(size => layouter.PutNextRectangle(size))
            .ToArray();
    }
}