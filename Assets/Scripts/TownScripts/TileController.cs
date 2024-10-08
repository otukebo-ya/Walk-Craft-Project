using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public enum TilemapType 
{
    Item,
    Ground,
    Effect
}
public class TileController : MonoBehaviour
{
    // シングルトン
    private static TileController _instance;
    public static TileController Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TileController)FindObjectOfType(typeof(TileController));
                if (null == _instance)
                {
                    Debug.Log("TileDirector Instance Error");
                }
            }
            return _instance;
        }
    }

    // タイルを配置する先のgrid
    public Tilemap GroundMap;
    public Tilemap ItemMap;
    public Tilemap EffectMap;
    public TileBase Effect;
    public TileBase ChoicedItemTile = null;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    /// <summary>
    /// Camera.main.ScreenToWorldPoint(Input.mousePosition)にて、
    /// 座標を変換してから使いましょう。
    /// </summary>
    void ChangeTile(Vector3 position, TileBase tile,Tilemap map)
    {
        Vector3Int grid = ConvertVec3Int(position);
        map.SetTile(grid, tile);
    }

    // オーバーロード。アイテムを設置するためだけ用。
    /// <summary>
    /// Camera.main.ScreenToWorldPoint(Input.mousePosition)にて、
    /// 座標を変換してから使いましょう。
    /// </summary>
    public void ChangeTile(Vector3 position) 
    {
        if (ChoicedItemTile != null)
        {
            Vector3Int grid = ConvertVec3Int(position);
            ItemMap.SetTile(grid, ChoicedItemTile);
        }
    }

    public void EmphasizeCrickedTile(Vector3 _currentPosition)
    {
        ChangeTile(_previousPosition, null, EffectMap);
        ChangeTile(_currentPosition, Effect, EffectMap);
        _previousPosition = _currentPosition;
    }
     
    private Vector3Int ConvertVec3Int(Vector3 position)
    {
        Vector3Int grid = ItemMap.WorldToCell(position);
        grid.z = 0;

        return grid;
    }

    public TileBase GetTile(Vector3 position, TilemapType type) {
        Vector3Int grid = ItemMap.WorldToCell(position);
        grid.z = 0;

        Tilemap tilemap;
        if (type == TilemapType.Item)
        {
            tilemap = ItemMap;
        }else if(type == TilemapType.Ground)
        {
            tilemap = GroundMap;
        }
        else
        {
            tilemap = EffectMap;
        }

        TileBase tile = tilemap.GetTile(grid);

        return tile;
    }

    public void ResetChoice() 
    {
        ChoicedItemTile = null;
    }
}
