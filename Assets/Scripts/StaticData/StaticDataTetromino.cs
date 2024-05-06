using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace StaticData
{
    [CreateAssetMenu(fileName = "TetrominoData", menuName = "StaticData/Tetromino")]
    public class StaticDataTetromino : ScriptableObject
    {
        public TetrominoType Type;
        public Tile Block;
    }
}