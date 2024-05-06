using Game.Interface;
using Move.Interface;
using Tetromino.Interface;
using UnityEngine;

namespace Move
{
    public class Movement : IMovement
    {
        private readonly INewBoard _board;
        private readonly IPlace _piece;
        private readonly ITimerStep _timer;
        private readonly IClear _clear;
        private readonly IPosition _position;
        private readonly ITileTetromino _tileTetromino;

        public Movement(INewBoard board, IPlace piece, ITimerStep timer, IClear clear, IPosition position, ITileTetromino tileTetromino)
        {
            _board = board;
            _piece = piece;
            _timer = timer;
            _clear = clear;
            _position = position;
            _tileTetromino = tileTetromino;
        }

        public void Step()
        {
            _timer.UpdateStepTime();

            Move(Vector2Int.down);

            if (_timer.CheckLockTime())
                Lock();
        }

        public void HardDrop()
        {
            while (Move(Vector2Int.down))
                continue;

            Lock();
        }

        public bool Move(Vector2Int translation)
        {
            Vector3Int newPosition = _position.CalculateNewPosition(translation, _piece.Position);

            if (_position.IsValidPosition(_board, _piece.Cells, newPosition) == false)
                return false;

            _piece.SetPosition(newPosition);
            _timer.SetLockTime(0f);
            return true;
        }

        private void Lock()
        {
            _tileTetromino.Set();
            _clear.ClearLines();
            _board.SpawnPiece();
        }
    }
}