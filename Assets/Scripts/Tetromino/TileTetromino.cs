using Game.Interface;
using Tetromino.Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetromino
{
    public class TileTetromino : ITileTetromino
    {
        private readonly Tilemap _tilemap;
        private readonly IPlace _place;

        public TileTetromino(Tilemap tilemap, IPlace place)
        {
            _place = place;
            _tilemap = tilemap;
        }

        public void Set(Vector3Int[] cells = null, Tilemap map = null, Vector3Int position = default, Tile tile = null)
        {
            if (cells != null)
                SetTiles(cells, map, position, tile);

            SetTiles(_place.Cells, _tilemap, _place.Position, _place.BlockTile.TileBlack);
        }

        public void Clear(Vector3Int[] cells = null, Tilemap map = null, Vector3Int position = default)
        {
            if (cells != null)
                SetTiles(cells, map, position);

            SetTiles(_place.Cells, _tilemap, _place.Position);
        }

        private void SetTiles(Vector3Int[] cells, Tilemap map, Vector3Int position = default, Tile tile = null)
        {
            foreach (var positionCell in cells)
            {
                Vector3Int tilePosition = positionCell + position;
                map.SetTile(tilePosition, tile);
            }
        }

        public TileBase GetTile(Vector3Int pos, Tilemap _map) =>
            _map.GetTile(pos);
    }
}