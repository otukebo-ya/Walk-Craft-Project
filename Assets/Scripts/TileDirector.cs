using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class TileDirector : MonoBehaviour
{
    // �V���O���g��
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

    // �^�C����z�u������grid
    public Tilemap GroundMap;
    public Tilemap ItemMap;
    public Tilemap EffectMap;
    public TileBase Effect;
    public TileBase NewItemTile = null;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GameManager.Instance.IsTileChangeMode() && NewItemTile != null)
            {
                // �z�u���邩�m�F���鏈��
                ChangeTile(mousePosition, NewItemTile, ItemMap);
                GameManager.Instance.SetTileChangeModeOff();
            }

            // �^�C��������ꍇ�A��������₤
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
