using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TiledExample.Tiled
{
    public class Tmx
    {
        public int Width { get; }
        public int Height { get; }
        public int TileWidth { get; }
        public int TileHeight { get; }
        public List<Tsx> Tilesets { get; }
        public List<TmxLayer> Layers { get; } = new List<TmxLayer>();

        public Tmx(string tmxPath)
        {
            var doc = XDocument.Load($"Content/{tmxPath}");
            var map = doc.Element(XName.Get("map"));
            Width = new XValue(map, "width").AsInt();
            Height = new XValue(map, "height").AsInt();
            TileWidth = new XValue(map, "tilewidth").AsInt();
            TileHeight = new XValue(map, "tileheight").AsInt();
            Tilesets = map.Elements(XName.Get("tileset"))
                .Select(x => new Tsx(new XValue(x, "firstgid").AsInt(), new XValue(x, "source").AsString()))
                .ToList();
            var layers = map.Elements(XName.Get("layer")).ToList();
            for (var i = 0; i < layers.Count; i++)
                 Layers.Add(new TmxLayer(i, layers[i]));
        }
    }
}
