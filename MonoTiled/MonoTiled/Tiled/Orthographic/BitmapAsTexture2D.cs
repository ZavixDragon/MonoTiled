using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics;

namespace TiledExample.Tiled
{
    public class BitmapAsTexture2D
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Bitmap _value;

        public BitmapAsTexture2D(GraphicsDevice graphicsDevice, Bitmap value)
        {
            _graphicsDevice = graphicsDevice;
            _value = value;
        }

        public Texture2D Get()
        {
            var texture = new Texture2D(_graphicsDevice, _value.Width, _value.Height, true, SurfaceFormat.Color);
            var data = _value.LockBits(new Rectangle(0, 0, _value.Width, _value.Height), ImageLockMode.ReadOnly, _value.PixelFormat);
            var bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            texture.SetData(bytes);
            _value.UnlockBits(data);
            return texture;
        }
    }
}
