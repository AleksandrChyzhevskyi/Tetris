using Blacks.Interface;
using Tetromino.Interface;
using UnityEngine;

namespace Game.Interface
{
    public interface IPlace
    {
        IBlockTile BlockTile { get; }
        Vector3Int Position { get; }
        Vector3Int[] Cells { get; }
        int RotationIndex { get; }
        void Initialize(Vector3Int position, IBlockTile data, ITimerStep timer);
        void SetPosition(Vector3Int newPosition);
        void SetRotationIndex(int index);
    }
}