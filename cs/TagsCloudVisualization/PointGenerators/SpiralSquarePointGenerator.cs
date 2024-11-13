using System.Drawing;

namespace TagsCloudVisualization.PointGenerators;

public class SpiralSquarePointGenerator : IPointGenerator
{
    // Точки привязки для следующих прямоугольников
    private Point topLeft;
    private Point topRight;
    private Point bottomRight;
    private Point bottomLeft;
    private Directions currentDirection = Directions.UP;
    private Rectangle currentRectangle;

    public SpiralSquarePointGenerator()
    {
        Console.WriteLine("bebra");
    }

    public void InitFirstRectangle(Point center, Size mainRectangleSize)
    {
        topLeft = new Point(center.X - mainRectangleSize.Width / 2, center.Y - mainRectangleSize.Height / 2);
        topRight = new Point(center.X + mainRectangleSize.Width / 2, center.Y - mainRectangleSize.Height / 2);
        bottomRight = new Point(center.X + mainRectangleSize.Width / 2, center.Y + mainRectangleSize.Height / 2);
        bottomLeft = new Point(center.X - mainRectangleSize.Width / 2, center.Y + mainRectangleSize.Height / 2);

        currentRectangle = new Rectangle(topLeft, mainRectangleSize);
    }

    public void CalculateRectangle(Size rectangleSize)
    {
        switch (currentDirection)
        {
            case Directions.UP:
                currentRectangle = new Rectangle(topLeft.X, topLeft.Y - rectangleSize.Height, rectangleSize.Width, rectangleSize.Height);
                if (topRight.X - topLeft.X > rectangleSize.Width)
                {
                    topLeft = new Point(topLeft.X + rectangleSize.Width, topLeft.Y);
                    currentDirection = Directions.UP;
                }
                else
                {
                    topLeft = new Point(topLeft.X, topLeft.Y - rectangleSize.Height);
                    currentDirection = Directions.RIGHT;
                }
                break;
            case Directions.RIGHT:
                currentRectangle = new Rectangle(topRight.X, topRight.Y, rectangleSize.Width, rectangleSize.Height);
                if (topRight.Y - bottomRight.Y > rectangleSize.Height)
                {
                    topRight = new Point(topRight.X, topRight.Y + rectangleSize.Height);
                    currentDirection = Directions.RIGHT;
                }
                else
                {
                    topRight = new Point(topLeft.X + rectangleSize.Width, topLeft.Y);
                    currentDirection = Directions.DOWN;
                }
                break;
            case Directions.DOWN:
                currentRectangle = new Rectangle(bottomRight.X - rectangleSize.Width, bottomRight.Y, rectangleSize.Width, rectangleSize.Height);
                if (bottomLeft.X - bottomRight.X > rectangleSize.Width)
                {
                    bottomLeft = new Point(bottomLeft.X - rectangleSize.Width, bottomLeft.Y);
                    currentDirection = Directions.DOWN;
                }
                else
                {
                    bottomLeft = new Point(bottomLeft.X, bottomLeft.Y + rectangleSize.Height);
                    currentDirection = Directions.LEFT;
                }
                break;
            case Directions.LEFT:
                currentRectangle = new Rectangle(bottomLeft.X - rectangleSize.Width, bottomLeft.Y - rectangleSize.Height, rectangleSize.Width, rectangleSize.Height);
                if (topLeft.Y - bottomLeft.Y > rectangleSize.Height)
                {
                    bottomLeft = new Point(bottomLeft.X, bottomLeft.Y - rectangleSize.Height);
                    currentDirection = Directions.LEFT;
                }
                else
                {
                    bottomLeft = new Point(bottomLeft.X - rectangleSize.Width, bottomLeft.Y);
                    currentDirection = Directions.UP;
                }
                break;
        }
    }

    public Rectangle GetCurrentRectangle()
    {
        return currentRectangle;
    }
}