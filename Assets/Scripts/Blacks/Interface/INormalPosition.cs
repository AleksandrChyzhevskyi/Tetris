using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Blacks.Interface
{
    public interface INormalPosition
    {
        public Dictionary<TetrominoType, Vector2Int[]> Position { get; }
    }
}