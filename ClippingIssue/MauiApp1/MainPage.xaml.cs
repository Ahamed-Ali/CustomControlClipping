
using Microsoft.Maui.Controls.Shapes;
using System.ComponentModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomControl : GraphicsView, IDrawable
    {

        public CustomControl()
        {
            this.Drawable = this;
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();
            canvas.FillColor = Colors.Red;
            canvas.FillEllipse(10, 10, 100, 100);
            this.UpdateBaseClip();
           canvas.RestoreState();
        }

        internal void UpdateBaseClip()
        {
            var x = 0;
            var y = 0;
#if WINDOWS
            if (!(Parent is Frame))
                   this.Clip = new RoundRectangleGeometry(new CornerRadius(8), new Rect(x, y, this.Width, this.Height));
#else
            this.Clip = new RoundRectangleGeometry(new CornerRadius(8), new Rect(x, y, this.Width, this.Height));
#endif
        }
    }


}
