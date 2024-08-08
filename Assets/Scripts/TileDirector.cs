using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class TileDirector : TownSceneInitializer
{
    // �^�C����z�u������grid
    public Tilemap groundMap;
    public Tilemap itemMap;
    public Tilemap effectMap;
    public TileBase effect;
    public TileBase newItemTile = null;
    private Vector3Int previousPosition;
    private Vector3Int currentPosition;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int grid = itemMap.WorldToCell(mouse_position);
            grid.z = 0;

            emphasizeCrickedTile(grid);

            if (gmScript.isTileChangeMode() && newItemTile != null)
            {
                // �z�u���邩�m�F���鏈��
                changeTile(grid, newItemTile, itemMap);
                gmScript.setTileChangeModeOff();
            }

            // �^�C��������ꍇ�A��������₤
            if (itemMap.GetTile(grid))
            {
                //Debug.Log(itemMap.GetTile(grid));
            }
        }
    }

    void changeTile(Vector3Int grid, TileBase tile,Tilemap map)
    {
        map.SetTile(grid, tile);
    }

    void emphasizeCrickedTile(Vector3Int currentPosition)
    {
        changeTile(previousPosition, null, effectMap);
        changeTile(currentPosition, effect, effectMap);
        previousPosition = currentPosition;
    }
}
