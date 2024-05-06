using UnityEngine;

namespace Move.Interface
{
    public interface IMovement
    {
        void Step();
        void HardDrop();
        bool Move(Vector2Int translation);
    }
}