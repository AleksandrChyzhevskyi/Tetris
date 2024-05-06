using Game.Interface;
using Move.Interface;
using Tetromino.Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class NewGhost : INewGhost
    {
        private readonly IPosition _position;
        private readonly INewBoard _boardGame;
        private readonly IPlace _trackingPiece;
        private readonly ITileTetromino _tileTetromino;
        
        private readonly Vector3Int[] _cells;
        private readonly Tile _tileShadow;

        private Vector3Int _positionTile;

        public Tilemap Map { get; }

        public NewGhost(Tilemap map, Tile tileShadow, INewBoard boardGame, IPlace trackingPiece,
            ITileTetromino tileTetromino, IPosition position)
        {
            Map = map;
            _position = position;
            _tileShadow = tileShadow;
            _boardGame = boardGame;
            _trackingPiece = trackingPiece;
            _tileTetromino = tileTetromino;
            _cells = new Vector3Int[_trackingPiece.Cells.Length];
        }

        public void UpdatePosition()
        {
            Clear();
            Copy();
            Drop();
            Set();
        }

        private void Clear() =>
            _tileTetromino.Clear(_cells, Map, _positionTile);

        private void Set() =>
            _tileTetromino.Set(_cells, Map, _positionTile, _tileShadow);

        private void Copy()
        {
            for (var i = 0; i < _cells.Length; i++)
                _cells[i] = _trackingPiece.Cells[i];
        }

        private void Drop()
        {
            Vector3Int position = _trackingPiece.Position;

            int current = position.y;
            int bottom = -_boardGame.BordSize.y / 2 - 1;

            _tileTetromino.Clear();

            for (int row = current; row >= bottom; row--)
            {
                position.y = row;

                if (_position.IsValidPosition(_boardGame, _trackingPiece.Cells, position))
                    _positionTile = position;
                else
                    break;
            }

            _tileTetromino.Set();
        }
    }
}