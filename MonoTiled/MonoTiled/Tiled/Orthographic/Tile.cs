using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace TiledExample.Tiled
{
    public class Tile
    {
        private readonly Texture2D _texture;
        private readonly Rectangle _rect;

        public Tile(Texture2D texture, Rectangle rect)
        {
            _texture = texture;
            _rect = rect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, Color.White);
        } 
    }
}
