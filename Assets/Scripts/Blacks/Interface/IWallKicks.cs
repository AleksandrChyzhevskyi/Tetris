using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Blacks.Interface
{
    public interface IWallKicks
    {
        public float[] RotationMatrix { get;  }
        public Dictionary<TetrominoType, Vector2Int[,]> WallKicksBlack { get; }
    }
}