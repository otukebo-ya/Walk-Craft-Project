using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class TileDirector : MonoBehaviour
{
    // タイルを配置する先のgrid
    public Tilemap groundMap;
    public Tilemap itemMap;
    public Tilemap effectMap;
    public TileBase effect;
    public TileBase newItemTile = null;
    private Vector3 previousPosition;
    private Vector3 currentPosition;

    GameObject gm;
    GameManager gmScript;


    void Start()
    {
        gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();
        previousPosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            checkTile(mouse_position);
            emphasizeCrickedTile(mouse_position);
            if (gmScript.isTileChangeMode() && newItemTile != null)
            {
                // 配置するか確認する処理
                changeTile(mouse_position, newItemTile, itemMap);
                gmScript.setTileChangeModeOff();
            }
        }
    }

    void changeTile(Vector3 position, TileBase tile,Tilemap map)
    {
        Vector3Int grid = map.WorldToCell(position);
        grid.z = 0;
        map.SetTile(grid, tile);
    }

    void emphasizeCrickedTile(Vector3 currentPosition)
    {
        changeTile(previousPosition, null, effectMap);
        changeTile(currentPosition, effect, effectMap);
        previousPosition = currentPosition;
    }

    void checkTile(Vector3 position)
    {
        Vector3Int grid1 = groundMap.WorldToCell(position);
        Vector3Int grid2 = itemMap.WorldToCell(position);
        Vector3Int grid3 = effectMap.WorldToCell(position);
        TileBase clickedGroundTile = groundMap.GetTile(grid1);
        TileBase clickedItemTile = itemMap.GetTile(grid2);
        TileBase clickedEffectTile = effectMap.GetTile(grid3);
        //Debug.Log("g" + clickedGroundTile);
        Debug.Log("I" + clickedItemTile);
        Debug.Log("E" + clickedEffectTile);
        Debug.Log(grid1);
    }

}
