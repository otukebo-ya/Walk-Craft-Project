using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TouchedTileOption : MonoBehaviour
{
    public TileBase TouchedTile;
    public Vector3Int TouchedTilePosition;
    public Button OKButton;
    public Button MoveButton;
    public Button DeleteButton;

    // シングルトン
    private static TouchedTileOption _instance;
    public static TouchedTileOption Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TouchedTileOption)FindObjectOfType(typeof(TouchedTileOption));
                if (null == _instance)
                {
                    Debug.Log("TouchedTileOption Instance Error");
                }
            }
            return _instance;
        }
    }

    public void SetLayoutOptionListener()
    {
        Debug.Log("SetLayoutOption");
        OKButton.onClick.AddListener(HideOptions);
        MoveButton.onClick.AddListener(MoveEnphasizedTile);
        DeleteButton.onClick.AddListener(DeleteEnphasizedTile);
    }

    public void SetItemPlaceOptionListener() {
        Debug.Log("SetPlaceOption");
        OKButton.onClick.AddListener(PlaceItem);
        MoveButton.onClick.AddListener(HideOptions);
        DeleteButton.onClick.AddListener(ReturnItemWindow);
    }

    public void RemoveListeners() {
        OKButton.onClick.RemoveAllListeners();
        MoveButton.onClick.RemoveAllListeners();
        DeleteButton.onClick.RemoveAllListeners();
    }

    // 表示する
    public void ShowOptions(Vector3 touchedScreenPosition)
    {
        Vector3 touchedWorldPosition = Camera.main.ScreenToWorldPoint(touchedScreenPosition);
        TouchedTile = TileController.Instance.GetTile(touchedWorldPosition, TilemapType.Item);

        Vector3 pos = DecidePosition(touchedScreenPosition);
        this.gameObject.transform.position = pos;
        
        this.gameObject.SetActive(true);
    }

    public void HideOptions() 
    {
        this.gameObject.SetActive(false);
    }

    public Vector3 DecidePosition (Vector3 position)
    {
        Vector3 newPos = position;
        const int X_LIMIT = 150;
        const int Y_OFFSET = 150;
        if (position.x <= X_LIMIT) 
        {
            newPos.x = position.x + X_LIMIT;
            Debug.Log("migi");
        }else if(position.x > Screen.width - X_LIMIT)
        {
            newPos.x = position.x - X_LIMIT;
            Debug.Log("hidari");

        }

        if (position.y <= Screen.height / 2)
        {
            newPos.y = position.y + Y_OFFSET;
        }
        else
        {
            newPos.y = position.y - Y_OFFSET;
        }
        return newPos;
    }

    public void MoveEnphasizedTile()
    {
        
    }

    public void DeleteEnphasizedTile() 
    {
        // （TODO）持ち物に戻す作業が必要！！！
        TileController.Instance.DeleteEmphasizedTile();
        TileController.Instance.DeleteEmphasis();
        this.gameObject.SetActive(false);
    }

    public void PlaceItem() 
    {
        TileController.Instance.PlaceChoicedItemTile();
    }

    public void ReturnItemWindow() 
    {
        
    }
}
