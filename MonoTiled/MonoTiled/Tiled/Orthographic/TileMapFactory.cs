using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TiledExample.Tiled.Orthographic
{
    public class TileMapFactory
    {
        private readonly GraphicsDevice _graphicsDevice;

        public TileMapFactory(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public TileMap CreateMap(Tmx tmx)
        {
            var textures = new TileMapTextures(_graphicsDevice, tmx);
            return new TileMap(tmx.Layers.Select(x => 
                new TileLayer(x.ZIndex, x.Tiles.Select(y => 
                    new Tile(textures.Get(y.TextureId), 
                        new Rectangle(y.Column * tmx.TileWidth, y.Row * tmx.TileHeight, tmx.TileWidth, tmx.TileHeight))).ToList())).ToList());
        }
    }
}
