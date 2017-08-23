using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TiledExample.Tiled
{
    public class TileLayer
    {
        private readonly List<Tile> _tiles;
        public int ZIndex { get; }

        public TileLayer(int zIndex, List<Tile> tiles)
        {
            _tiles = tiles;
            ZIndex = zIndex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _tiles.ForEach(x => x.Draw(spriteBatch));
        }
    }
}
