using Blacks.Interface;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Blacks
{
    public class BlockTile : IBlockTile
    {
        public TetrominoType Tetromino { get; }
        public Tile TileBlack { get; }
        public float[] RotationMatrix { get; }
        public Vector2Int[,] WallKicksBlack { get; }
        public Vector2Int[] Position { get; }

        public BlockTile(Tile tileBlack, IWallKicks wallKicksBlack, INormalPosition position,
            TetrominoType tetrominoType)
        {
            Tetromino = tetrominoType;
            TileBlack = tileBlack;
            
            WallKicksBlack = wallKicksBlack.WallKicksBlack[Tetromino];
            RotationMatrix = wallKicksBlack.RotationMatrix;
            Position = position.Position[Tetromino];
        }
    }
}