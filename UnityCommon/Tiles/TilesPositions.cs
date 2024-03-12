using System.Collections.Generic;
using UnityEngine;

namespace UnityCommon.Tiles
{
    public class TilesPositions
    {
        private readonly List<TilePosition> _tilePositions;
        private readonly int _x;
        private readonly int _y;

        public TilesPositions(List<TilePosition> tilePositions, int x, int y)
        {
            _tilePositions = tilePositions;
            _x = x;
            _y = y;
        }

        public void RecalculatePositions(Transform targetTransform)
        {
            foreach (var t in _tilePositions)
            {
                var tileWorldNewPosition = targetTransform.TransformPoint(t.Position);
                t.Position = tileWorldNewPosition;
            }
        }

        public TilePosition GetTilePosition(Vector3 targetPosition)
        {
            return _tilePositions.MinBy(tilePosition => Vector3.Distance(targetPosition, tilePosition.Position));
        }
        
        public TilePosition GetTilePosition(Vector3 targetPosition, Vector3Int shiftPosition)
        {
            var nearestTilePosition = GetTilePosition(targetPosition);
            
            var shiftedTilePositionX = nearestTilePosition.Position.x + shiftPosition.x;
            var shiftedTilePositionY = nearestTilePosition.Position.y + shiftPosition.y;
            var shiftedTilePositionZ = nearestTilePosition.Position.z + shiftPosition.z;

            var shiftedTilePosition = _tilePositions.Find(tilePosition =>
                FloatUtils.EqualsApproximately(tilePosition.Position.x, shiftedTilePositionX, 0.0001f) &&
                FloatUtils.EqualsApproximately(tilePosition.Position.y, shiftedTilePositionY, 0.0001f) && 
                FloatUtils.EqualsApproximately(tilePosition.Position.z, shiftedTilePositionZ, 0.0001f));

            return shiftedTilePosition;
        }
    }
}
