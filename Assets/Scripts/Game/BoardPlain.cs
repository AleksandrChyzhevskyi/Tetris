using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class BoardPlain : MonoBehaviour
    {
        public SpriteRenderer Grid;
        public Tilemap Map;
        public SpriteRenderer Boarder;
        public Tilemap ShadowMap;
        public Tile TileShadow;
        public Tilemap NewtMap;

        public void SetSizePlain(Vector2Int size)
        {
            Grid.size = size;
            Boarder.size = size;
        }
    }
}