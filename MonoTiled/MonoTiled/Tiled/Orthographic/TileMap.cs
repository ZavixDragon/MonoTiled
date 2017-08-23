using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace TiledExample.Tiled
{
    public class TileMap
    {
        private readonly List<TileLayer> _layers;

        public TileMap(List<TileLayer> layers)
        {
            _layers = layers.OrderBy(x => x.ZIndex).ToList();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _layers.ForEach(x => x.Draw(spriteBatch));
        }
    }
}
