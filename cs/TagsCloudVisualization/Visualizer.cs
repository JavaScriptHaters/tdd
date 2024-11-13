using System.Drawing;

namespace TagsCloudVisualization;

public class Visualizer
{
    public Bitmap CreateBitmap(IEnumerable<Rectangle> rectangles, Size bitmapSize)
    {
        var bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height);

        using var graphics = Graphics.FromImage(bitmap);
        foreach (var rectangle in rectangles)
        {
            var pen = new Pen(Color.Blue);
            graphics.DrawRectangle(pen, rectangle);
        }

        return bitmap;
    }
}