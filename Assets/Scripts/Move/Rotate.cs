using Blacks.Interface;
using Game.Interface;
using Move.Interface;
using StaticData;
using UnityEngine;

namespace Move
{
    public class Rotate : IRotate
    {
        private readonly IPlace _piece;
        private readonly IMovement _movement;
        private readonly IWallKicks _wallKicks;

        public Rotate(IPlace piece, IMovement movement, IWallKicks wallKicks)
        {
            _piece = piece;
            _movement = movement;
            _wallKicks = wallKicks;
        }

        public void RotateBlock(int direction)
        {
            int originalRotation = _piece.RotationIndex;
            _piece.SetRotationIndex(Warp(_piece.RotationIndex + direction, _wallKicks.RotationMatrix.Length));

            ApplyRotationMatrix(direction);

            if (TestWallKicks(_piece.RotationIndex, direction) == false)
            {
                _piece.SetRotationIndex(originalRotation);
                ApplyRotationMatrix(-direction);
            }
        }

        private void ApplyRotationMatrix(int direction)
        {
            for (int i = 0; i < _piece.Cells.Length; i++)
            {
                Vector3 cell = _piece.Cells[i];

                Vector2Int newPositionBlocks;

                switch (_piece.BlockTile.Tetromino)
                {
                    case TetrominoType.I:
                    case TetrominoType.O:
                        Vector3 offsetCell = new Vector3(cell.x -= 0.5f, cell.y -= 0.5f, cell.z);
                        newPositionBlocks = SetPositionRotate(direction, offsetCell).ToCeilToInt();
                        break;

                    default:
                        newPositionBlocks = SetPositionRotate(direction, cell).ToRoundToInt();
                        break;
                }

                _piece.Cells[i] = newPositionBlocks.ToVector3Int();
            }
        }

        private bool TestWallKicks(int rotationIndex, int rotationDirection)
        {
            int wallKickIndex = GetWallKickIndex(rotationIndex, rotationDirection);

            for (int i = 0; i < _piece.BlockTile.WallKicksBlack.GetLength(1); i++)
            {
                Vector2Int translation = _piece.BlockTile.WallKicksBlack[wallKickIndex, i];

                if (_movement.Move(translation))
                    return true;
            }

            return false;
        }

        private int GetWallKickIndex(int rotationIndex, int rotationDirection)
        {
            int wallKickIndex = rotationIndex * 2;

            if (rotationDirection < 0)
                wallKickIndex--;

            return Warp(wallKickIndex, _piece.BlockTile.WallKicksBlack.GetLength(0));
        }

        private Vector2 SetPositionRotate(int direction, Vector3 cell)
        {
            return new Vector2(
                (cell.x * _wallKicks.RotationMatrix[0] * direction) +
                (cell.y * _wallKicks.RotationMatrix[1] * direction),
                (cell.x * _wallKicks.RotationMatrix[2] * direction) +
                (cell.y * _wallKicks.RotationMatrix[3] * direction));
        }

        private int Warp(int index, int max, int min = 0)
        {
            if (index < min)
                return max - (min - index) % (max - min);

            return min + (index - min) % (max - min);
        }
    }
}


