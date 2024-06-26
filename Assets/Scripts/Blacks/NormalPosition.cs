﻿using System.Collections.Generic;
using Blacks.Interface;
using StaticData;
using UnityEngine;

namespace Blacks
{
    public class NormalPosition : INormalPosition
    {
        public Dictionary<TetrominoType, Vector2Int[]> Position { get; } = new()
        {
            { TetrominoType.I,
                new[] { new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(2, 1) }
            },
            { TetrominoType.J,
                new[] { new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
            },
            { TetrominoType.L,
                new[] { new Vector2Int(1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
            },
            { TetrominoType.O,
                new[] { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
            },
            { TetrominoType.S,
                new[] { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0) }
            },
            { TetrominoType.T,
                new[] { new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
            },
            { TetrominoType.Z,
                new[] { new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
            },
        };
    }
}