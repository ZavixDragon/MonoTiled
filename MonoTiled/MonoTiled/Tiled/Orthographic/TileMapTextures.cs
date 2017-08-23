using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework.Graphics;

namespace TiledExample.Tiled
{
    public class TileMapTextures
    {
        private readonly Dictionary<int, Texture2D> _tiles = new Dictionary<int, Texture2D>();

        public TileMapTextures(GraphicsDevice graphicsDevice, Tmx tmx)
        {
            tmx.Tilesets.ForEach(x => AddTileset(graphicsDevice, x));
        }

        public Texture2D Get(int id)
        {
            return _tiles[id];
        }

        private void AddTileset(GraphicsDevice graphicsDevice, Tsx tsx)
        {
            for (int i = 0; i < tsx.TileCount; i++)
                _tiles[tsx.FirstId + i] = new BitmapAsTexture2D(graphicsDevice, 
                    tsx.TileSource.Clone(GetTileRectangle(i, tsx), PixelFormat.Format64bppArgb)).Get();
        }

        private Rectangle GetTileRectangle(int tile, Tsx tsx)
        {
            var column = tile % tsx.Columns;
            var row = (int)Math.Floor((double)tile / tsx.Columns);
            var x = column * tsx.TileWidth + (column + 1) * tsx.Spacing;
            var y = row * tsx.TileHeight + (row + 1) * tsx.Spacing;
            return new Rectangle(x, y, tsx.TileWidth, tsx.TileHeight);
        }
    }
}
