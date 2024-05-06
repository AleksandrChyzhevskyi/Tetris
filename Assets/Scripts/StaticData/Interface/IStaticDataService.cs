using System.Collections.Generic;
using Blacks.Interface;

namespace StaticData.Interface
{
    public interface IStaticDataService
    {
        List<IBlockTile> GetBlockTiles();
    }
}