using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Map
    {
        public List<Tile> tiles;
        public delegate void DxOnUpdate();

        public Map(List<Tile> tiles)
        {
            this.tiles = tiles;
        }

        public void Update(DxOnUpdate dxOnUpdate)
        {
            dxOnUpdate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
                tile.Draw(spriteBatch);
        }
    }
}