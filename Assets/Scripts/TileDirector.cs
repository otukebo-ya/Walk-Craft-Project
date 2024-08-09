using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class TileDirector : TownSceneInitializer
{
    // タイルを配置する先のgrid
    public Tilemap GroundMap;
    public Tilemap ItemMap;
    public Tilemap EffectMap;
    public TileBase Effect;
    public TileBase NewItemTile = null;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (gmScript.IsTileChangeMode() && NewItemTile != null)
            {
                // 配置するか確認する処理
                ChangeTile(mousePosition, NewItemTile, ItemMap);
                gmScript.SetTileChangeModeOff();
            }

            // タイルがある場合、消すかを問う
            if (ItemMap.GetTile(ConvertVec3Int(mousePosition)))
            {

            }
        }
    }

    void ChangeTile(Vector3 position, TileBase tile,Tilemap map)
    {
        Vector3Int grid = ConvertVec3Int(position);
        map.SetTile(grid, tile);
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
}
