using System;
using System.Threading.Tasks;

namespace Models
{
    public class MovableItem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Opacity { get; set; }
        public double Width { get; set; } 
        public double Height { get; set; } 
        
        public event EventHandler Event;

        public double Speed { get; set; } = 0.8;
        private double tempX;
        private double tempY;
        
        public void MoveElement(double x, double y)
        {
            if (x > tempX)
                X += Speed;
            if (x < tempX)
                X -= Speed;
            if (y > tempY)
                Y += Speed;
            if (y < tempY)
                Y -= Speed;

            tempX = x;
            tempY = y;
        }

        public async Task AnimateItem(string animate)
        {
            switch (animate)
            {
                case "FadeIn":
                    Opacity = 0;
                    while (Opacity < 1)
                    {
                        Opacity += 0.01;
                        await Task.Delay(10);
                        Event?.Invoke(this, EventArgs.Empty);
                        Console.WriteLine(Opacity);
                    }
                    break;
            }
        }

        public double GetCenteredY()
        {
            return Y + Height / 2;
        }

        public double GetCenteredX()
        {
            return X + Width / 2;
        }
        
        
    }
}