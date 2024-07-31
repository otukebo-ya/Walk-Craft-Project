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
    public bool tileChangeMode;
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    

    void start()
    {
        tileChangeMode = false;
        previousPosition = Vector3.zero;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            emphasizeCrickedTile(mouse_position);
            if (tileChangeMode && newItemTile != null)
            {
                changeTile(mouse_position, newItemTile, itemMap);
                tileChangeMode =false;
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
