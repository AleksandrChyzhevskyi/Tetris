using System.Collections.Generic;
using Blacks.Interface;
using Game.Interface;
using Move.Interface;
using Tetromino.Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class NewBoard : INewBoard
    {
        private readonly List<IBlockTile> _tetrominoes;

        private readonly ITimerStep _timer;
        private readonly IPlace _activePiece;
        private readonly ITileTetromino _tileTetromino;
        private readonly IPosition _position;
        private readonly INextTile _nextTile;
        private readonly INewGhost _ghost;

        private Vector3Int _startPosition;
        private IBlockTile _currentTile;

        public Tilemap Map { get; }
        public Vector2Int BordSize { get; }

        public RectInt Bounds
        {
            get
            {
                Vector2Int position = new Vector2Int(-BordSize.x / 2, -BordSize.y / 2);
                return new RectInt(position, BordSize);
            }
        }

        public NewBoard(Tilemap map, List<IBlockTile> tetrominoes, ITimerStep timer, IPlace activePiece,
            Vector2 size, ITileTetromino tileTetromino, IPosition position, INextTile nextTile)
        {
            Map = map;
            _tetrominoes = tetrominoes;
            _timer = timer;
            _activePiece = activePiece;
            _tileTetromino = tileTetromino;
            _position = position;
            _nextTile = nextTile;

            BordSize = size.ToRoundToInt();

            SetStartPosition();

            SpawnPiece();
        }

        public void SpawnPiece()
        {
            _currentTile ??= _nextTile.GetBlock(_tetrominoes);

            _activePiece.Initialize(_startPosition, _currentTile, _timer);

            if (_position.IsValidPosition(this, _activePiece.Cells, _startPosition))
                _tileTetromino.Set();
            else
                GameOver();

            _currentTile = _nextTile.NextBlock(_tetrominoes, _currentTile);
        }

        

        private void GameOver() =>
            Map.ClearAllTiles(); //TODO Отображение поля конец игры и рестарт и.т.д.

        private void SetStartPosition() =>
            _startPosition = new(0, BordSize.y / 2 - 2);
    }
}