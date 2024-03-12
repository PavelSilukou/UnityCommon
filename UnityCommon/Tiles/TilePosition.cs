using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityCommon.Tiles
{
    public class TilePosition
    {
        public readonly TileBase TileBase;
        public Vector3 Position { get; set; }

        public TilePosition(TileBase tileBase, Vector3 position)
        {
            TileBase = tileBase;
            Position = position;
        }

        public override string ToString()
        {
            var tileName = TileBase != null ? TileBase.name : "Empty";
            return $"{tileName}, {Position.ToString()}";
        }
    }
}
