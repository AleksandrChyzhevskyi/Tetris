using Game.Interface;
using Move.Interface;
using UnityEngine;

namespace Move
{
    public class NewPosition : IPosition //сервис, Позитион сервис 
    {
        public Vector3Int CreateNewPosition(int col, int row) =>
            new(col, row, 0);

        public Vector3Int CalculateNewPosition(Vector2Int translation, Vector3Int position) =>
            position + translation.ToVector3Int();
        
        public bool IsValidPosition(INewBoard board, Vector3Int[] cells, Vector3Int position)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                Vector3Int tilePosition = cells[i] + position;

                if (board.Bounds.Contains(tilePosition.ToVector2Int()) == false)
                    return false;

                if (board.Map.HasTile(tilePosition))
                    return false;
            }

            return true;
        }
    }
}