using UnityEngine;

public static class Extension
{
    public static Vector3Int ToVector3Int(this Vector2Int pos) =>
        new (pos.x, pos.y, 0);
    
    public static Vector3Int ToVector3Int(this Vector3 pos) =>
        new ((int)pos.x, (int)pos.y, 0);
    
    public static Vector2Int ToVector2Int(this Vector3Int pos) =>
        new (pos.x, pos.y);

    public static Vector2Int ToCeilToInt(this Vector2 pos) =>
        new (Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y));

    public static Vector2Int ToRoundToInt(this Vector2 pos) =>
        new (Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
}