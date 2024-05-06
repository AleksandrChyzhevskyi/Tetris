using System.Collections.Generic;
using System.Linq;
using Blacks;
using Blacks.Interface;
using StaticData.Interface;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private List<StaticDataTetromino> _tetromins;
        private Dictionary<TetrominoType, IBlockTile> _blocks;

        public StaticDataService(INormalPosition normalPosition, IWallKicks wallKicks)
        {
            LoadTetromins();
            Initialize(wallKicks, normalPosition);
        }

        public List<IBlockTile> GetBlockTiles() =>
            _blocks.Values.ToList();

        private void Initialize(IWallKicks wallKicks, INormalPosition normalPosition)
        {
            _blocks = new Dictionary<TetrominoType, IBlockTile>();

            foreach (StaticDataTetromino tetromino in _tetromins)
                _blocks.Add(tetromino.Type,
                    new BlockTile(tetromino.Block, wallKicks, normalPosition, tetromino.Type));
        }

        private void LoadTetromins() =>
            _tetromins = Resources.LoadAll<StaticDataTetromino>("Tetromins").ToList();
    }
}