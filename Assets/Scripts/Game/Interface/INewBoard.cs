using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Interface
{
    public interface INewBoard
    {
        public Tilemap Map { get; }
        void SpawnPiece();
        Vector2Int BordSize { get; }
        RectInt Bounds { get; }
    }
}