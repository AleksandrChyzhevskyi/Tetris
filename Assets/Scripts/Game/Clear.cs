using System;
using Game.Interface;
using Move.Interface;
using Tetromino.Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class Clear : IClear
    {
        private readonly INewBoard _newBoard;
        private readonly ITileTetromino _tileTetromino;
        private readonly IPosition _position;

        public Clear(INewBoard newBoard, ITileTetromino tileTetromino, IPosition position)
        {
            _newBoard = newBoard;
            _tileTetromino = tileTetromino;
            _position = position;
        }

        public void ClearLines()
        {
            int row = _newBoard.Bounds.yMin;

            while (row < _newBoard.Bounds.yMax)
            {
                if (IsLineFull(row))
                    LineClear(row);
                else
                    row++;
            }
        }

        private void LineClear(int row)
        {
            ClearRow(row);

            while (row < _newBoard.Bounds.yMax)
            {
                ClearRow(row, _position.CreateNewPosition, pos => _tileTetromino.GetTile(pos, _newBoard.Map));
                row++;
            }
        }

        private void ClearRow(int row, Func<int, int, Vector3Int> CreateNewPos = null,
            Func<Vector3Int, TileBase> GetTile = null)
        {
            for (int col = _newBoard.Bounds.xMin; col < _newBoard.Bounds.xMax; col++)
            {
                if (CreateNewPos != null && GetTile != null)
                {
                    Vector3Int position = new Vector3Int(col, row + 1, 0);
                    _newBoard.Map.SetTile(CreateNewPos.Invoke(col, row), GetTile.Invoke(position));
                }
                else
                {
                    Vector3Int position = new Vector3Int(col, row, 0);
                    _newBoard.Map.SetTile(position, null);
                }
            }
        }

        private bool IsLineFull(int row)
        {
            for (int col = _newBoard.Bounds.xMin; col <_newBoard.Bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row, 0);
                if (_newBoard.Map.HasTile(position) == false)
                    return false;
            }

            return true;
        }
    }
}