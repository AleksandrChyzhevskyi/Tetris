using System.Collections.Generic;
using Blacks.Interface;
using Game.Interface;
using Tetromino.Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class NextTile : INextTile
    {
        private readonly ITileTetromino _tileTetromino;
        private readonly Tilemap Map;
        private readonly BoardPlain _boardPlain;
        private readonly Vector3 _transformParent;
        private readonly Vector2Int _offset = new(3, 4);

        public NextTile(ITileTetromino tileTetromino, BoardPlain boardPlain)
        {
            _boardPlain = boardPlain;
            _tileTetromino = tileTetromino;
            Map = boardPlain.NewtMap;
        }

        public IBlockTile NextBlock(List<IBlockTile> tetrominoes, IBlockTile currentTile)
        {
            Map.ClearAllTiles();

            IBlockTile data = tetrominoes[Random.Range(0, tetrominoes.Count)];
            _tileTetromino.Set(ToVector3IntArray(data.Position), Map, StartPosition(), data.TileBlack);

            return data;
        }

        private Vector3Int StartPosition()
        {
            Vector3 parentPos = _boardPlain.transform.position;
            Vector2 size = _boardPlain.Grid.size;

            Vector3 startPosition = new(parentPos.x + _offset.x, parentPos.y + size.y - _offset.y);

            return startPosition.ToVector3Int();
        }

        public IBlockTile GetBlock(List<IBlockTile> tetrominoes) =>
            tetrominoes[Random.Range(0, tetrominoes.Count)];

        private Vector3Int[] ToVector3IntArray(Vector2Int[] array)
        {
            List<Vector3Int> newArray = new List<Vector3Int>();

            foreach (Vector2Int element in array)
                newArray.Add(element.ToVector3Int());

            return newArray.ToArray();
        }
    }
}