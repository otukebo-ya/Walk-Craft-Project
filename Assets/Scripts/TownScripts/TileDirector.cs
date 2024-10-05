using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TileDirector : MonoBehaviour
{
    // シングルトン
    private static TileDirector _instance;
    public static TileDirector Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TileDirector)FindObjectOfType(typeof(TileDirector));
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
    public TileBase NewItemTile = null;
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
        if (NewItemTile != null)
        {
            Vector3Int grid = ConvertVec3Int(position);
            ItemMap.SetTile(grid, NewItemTile);
        }
    }

    // 触っているところを強調する。（TODO：リッチなアニメーションに変更）
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
}
