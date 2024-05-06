using System.Collections.Generic;
using Blacks.Interface;

namespace Game.Interface
{
    public interface INextTile
    {
        IBlockTile NextBlock(List<IBlockTile> tetrominoes,  IBlockTile currentTile);
        IBlockTile GetBlock(List<IBlockTile> tetrominoes);
    }
}