using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Blacks.Interface
{
    public interface IBlockTile
    {
        Tile TileBlack { get; }
        Vector2Int[,] WallKicksBlack { get; }
        Vector2Int[] Position { get; }
        TetrominoType Tetromino { get; }
    }
}