using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetromino.Interface
{
    public interface ITileTetromino
    {
        TileBase GetTile(Vector3Int pos, Tilemap _map);
        void Set(Vector3Int[] cells = null, Tilemap map = null, Vector3Int position = default, Tile tile = null);
        void Clear(Vector3Int[] cells = null, Tilemap map = null, Vector3Int position = default);
    }
}