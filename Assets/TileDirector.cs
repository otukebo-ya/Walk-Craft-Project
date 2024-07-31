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

        map.SetTile(grid, tile);
    }

    void emphasizeCrickedTile(Vector3 currentPosition)
    {
        changeTile(previousPosition, null, effectMap);
        changeTile(currentPosition, effect, effectMap);
        previousPosition = currentPosition;
    }

}
