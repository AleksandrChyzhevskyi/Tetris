using Game.Interface;
using UnityEngine;

namespace Move.Interface
{
    public interface IPosition
    {
        Vector3Int CreateNewPosition(int col, int row);
        Vector3Int CalculateNewPosition(Vector2Int translation, Vector3Int position);
        bool IsValidPosition(INewBoard board, Vector3Int[] cells, Vector3Int position);
    }
}