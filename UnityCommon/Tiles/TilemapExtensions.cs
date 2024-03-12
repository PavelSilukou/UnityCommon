using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityCommon.Tiles
{
    public static class TilemapExtensions
    {
        // Orientation - XY
        // Sort order - Bottom left
        // Bounds - Bottom left
        public static TilesPositions GetTilePositions(this Tilemap map)
        {
            var bounds = map.cellBounds;
            var allTiles = map.GetTilesBlock(bounds);
            var tileMapAnchor = map.tileAnchor;

            var tilePositions = new List<TilePosition>(bounds.size.x * bounds.size.y);

            var boundsPointIndex = 0;
            foreach (var point in bounds.allPositionsWithin)
            {
                var tileNewPosition = new Vector3(point.x + tileMapAnchor.x, point.y + tileMapAnchor.y,
                    point.z + tileMapAnchor.z);
                var tileWorldNewPosition = map.transform.TransformPoint(tileNewPosition);

                var tilePosition = new TilePosition(allTiles[boundsPointIndex], tileWorldNewPosition);
                tilePositions.Add(tilePosition);
                
                boundsPointIndex++;
            }

            return new TilesPositions(tilePositions, bounds.size.x, bounds.size.y);
        }
        
        // public static TilesPositions GetTilePositions(this Tilemap map)
        // {
        //     var bounds = map.cellBounds;
        //     var allTiles = map.GetTilesBlock(bounds);
        //     var tileMapAnchor = map.tileAnchor;
        //
        //     var tilePositions = new TilePosition[bounds.size.x, bounds.size.y];
        //
        //     var boundsPointIndex = 0;
        //     foreach (var point in bounds.allPositionsWithin)
        //     {
        //         var tileNewPosition = new Vector3(point.x + tileMapAnchor.x, point.y + tileMapAnchor.y,
        //             point.z + tileMapAnchor.z);
        //         var tileWorldNewPosition = map.transform.TransformPoint(tileNewPosition);
        //         
        //         var tilePosition = new TilePosition
        //         {
        //             TileBase = allTiles[boundsPointIndex],
        //             Position = tileWorldNewPosition
        //         };
        //
        //         var x = boundsPointIndex / bounds.size.x;
        //         var y = boundsPointIndex - x * bounds.size.x;
        //         tilePositions[x, y] = tilePosition;
        //         
        //         boundsPointIndex++;
        //     }
        //
        //     return new TilesPositions(tilePositions);
        // }
    }
}