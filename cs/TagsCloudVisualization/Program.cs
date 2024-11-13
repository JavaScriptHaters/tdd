﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TagsCloudVisualization;

internal class Program
{
    private const int ImageWidth = 1920;
    private const int ImageHeight = 1080;

    private const int RectanglesNumber = 30;
    private const int MinRectangleSize = 50;
    private const int MaxRectangleSize = 100;

    private const string ImagesDirectory = "images";

    public static void Main(string[] args)
    {
        var center = new Point(ImageWidth / 2, ImageHeight / 2);
        var cloudLayouter = new CircularCloudLayouter(center);
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