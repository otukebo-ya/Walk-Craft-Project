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
    public Image DeleteButtonImage;

    public Sprite _returnWindowImage;
    public Sprite _pitInBox;

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

        DeleteButtonImage.sprite = _pitInBox;
    }

    public void SetItemPlaceOptionListener() {
        Debug.Log("SetPlaceOption");
        OKButton.onClick.AddListener(PlaceItem);
        MoveButton.onClick.AddListener(HideOptions);
        DeleteButton.onClick.AddListener(ReturnItemWindow);

        DeleteButtonImage.sprite = _returnWindowImage;

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

        Tilemap itemMap = TileController.Instance.ItemMap;
        Vector3Int touchedTileCell = itemMap.WorldToCell(touchedWorldPosition);
        Vector3 touchedTilePos = itemMap.GetCellCenterWorld(touchedTileCell);
        Vector3 touchedTileScreenPosition = Camera.main.WorldToScreenPoint(touchedTilePos);
        Vector3 pos = DecidePosition(touchedTileScreenPosition);
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
        const int X_LIMIT = 75;
        const int X_OFFSET = 110;
        const int Y_OFFSET = 50;

        if (position.x <= X_LIMIT) 
        {
            newPos.x = X_OFFSET;
            Debug.Log("migi");
        }else if(position.x > Screen.width - X_LIMIT)
        {
            newPos.x = Screen.width - X_OFFSET;
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
        TouchController.Instance.AfterCloseTouchOption = true;
        HideOptions();
    }

    public void DeleteEnphasizedTile() 
    {
        // （TODO）持ち物に戻す作業が必要！！！
        TileController.Instance.DeleteEmphasizedTile();
        TileController.Instance.DeleteEmphasis();

        TouchController.Instance.AfterCloseTouchOption = true;
        HideOptions();
    }

    public void PlaceItem() 
    {
        TileController.Instance.PlaceChoicedItemTile();
        TileController.Instance.DeleteEmphasis();
        TouchController.Instance.AfterCloseTouchOption = true;
        HideOptions();
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ItemWindowState);
    }

    public void ReturnItemWindow() 
    {
        TouchController.Instance.AfterCloseTouchOption = true;
        HideOptions();
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ItemWindowState);
    }
}
