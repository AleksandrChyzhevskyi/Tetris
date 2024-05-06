using System.Collections.Generic;
using Blacks.Interface;
using StaticData;
using UnityEngine;

namespace Blacks
{
    public class WallKicks : IWallKicks
    {
        public float[] RotationMatrix { get; } = { _cos, _sin, -_sin, _cos };

        public Dictionary<TetrominoType, Vector2Int[,]> WallKicksBlack { get; } = new()
        {
            { TetrominoType.I, WallKicksI },
            { TetrominoType.J, WallKicksJLOSTZ },
            { TetrominoType.L, WallKicksJLOSTZ },
            { TetrominoType.O, WallKicksJLOSTZ },
            { TetrominoType.S, WallKicksJLOSTZ },
            { TetrominoType.T, WallKicksJLOSTZ },
            { TetrominoType.Z, WallKicksJLOSTZ },
        };

        private static readonly float _cos = Mathf.Cos(Mathf.PI / 2f);
        private static readonly float _sin = Mathf.Sin(Mathf.PI / 2f);

        private static readonly Vector2Int[,] WallKicksI =
        {
            { new(0, 0), new(-2, 0), new(1, 0), new(-2, -1), new(1, 2) },
            { new(0, 0), new(2, 0), new(-1, 0), new(2, 1), new(-1, -2) },
            { new(0, 0), new(-1, 0), new(2, 0), new(-1, 2), new(2, -1) },
            { new(0, 0), new(1, 0), new(-2, 0), new(1, -2), new(-2, 1) },
            { new(0, 0), new(2, 0), new(-1, 0), new(2, 1), new(-1, -2) },
            { new(0, 0), new(-2, 0), new(1, 0), new(-2, -1), new(1, 2) },
            { new(0, 0), new(1, 0), new(-2, 0), new(1, -2), new(-2, 1) },
            { new(0, 0), new(-1, 0), new(2, 0), new(-1, 2), new(2, -1) },
        };

        private static readonly Vector2Int[,] WallKicksJLOSTZ =
        {
            { new(0, 0), new(-1, 0), new(-1, 1), new(0, -2), new(-1, -2) },
            { new(0, 0), new(1, 0), new(1, -1), new(0, 2), new(1, 2) },
            { new(0, 0), new(1, 0), new(1, -1), new(0, 2), new(1, 2) },
            { new(0, 0), new(-1, 0), new(-1, 1), new(0, -2), new(-1, -2) },
            { new(0, 0), new(1, 0), new(1, 1), new(0, -2), new(1, -2) },
            { new(0, 0), new(-1, 0), new(-1, -1), new(0, 2), new(-1, 2) },
            { new(0, 0), new(-1, 0), new(-1, -1), new(0, 2), new(-1, 2) },
            { new(0, 0), new(1, 0), new(1, 1), new(0, -2), new(1, -2) },
        };
    }
}