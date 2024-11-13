using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Visualizers;

namespace TagsCloudVisualization;

internal class Program
{
    private const int ImageWidth = 1920;
    private const int ImageHeight = 1080;

    private const int RectanglesNumber = 50;
    private const int MinRectangleSize = 40;
    private const int MaxRectangleSize = 70;

    private const double Radius = 1;
    private const double AngleOffset = 10;

    private const string ImagesDirectory = "images";

    public static void Main(string[] args)
    {
        var center = new Point(ImageWidth / 2, ImageHeight / 2);
        var cloudLayouter = new CircularCloudLayouter(center);
        cloudLayouter.InitSpiral(Radius, AngleOffset);
        var random = new Random();
        var rectangles = new Rectangle[RectanglesNumber];

        rectangles = rectangles
            .Select(_ => cloudLayouter.PutNextRectangle(new Size(
                random.Next(MinRectangleSize, MaxRectangleSize),
                random.Next(MinRectangleSize, MaxRectangleSize))))
            .ToArray();

        var visualizer = new Visualizer();
        var bitmap = visualizer.CreateBitmap(rectangles, new Size(ImageWidth, ImageHeight));
        Directory.CreateDirectory(ImagesDirectory);

        bitmap.Save(GetPathToImages(), ImageFormat.Jpeg);
    }

    private static string GetPathToImages()
    {
        var filename = $"{RectanglesNumber}_TagCloud.jpg";
        return Path.Combine(ImagesDirectory, filename);
    }

}