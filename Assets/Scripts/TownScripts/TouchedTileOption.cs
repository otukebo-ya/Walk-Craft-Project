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

    // 建物片付ける用のオプション表示
    public void SetLayoutOptionListener()
    {
        //Debug.Log("LayoutOption");
        OKButton.onClick.AddListener(HideOptions);
        MoveButton.onClick.AddListener(MoveEnphasizedTile);
        DeleteButton.onClick.AddListener(DeleteEnphasizedTile);

        // 右端ボタンの画像を「片付ける」に
        DeleteButtonImage.sprite = _pitInBox;
    }

    // 建物配置用のオプション
    public void SetItemPlaceOptionListener() {
        //Debug.Log("PlaceOption");
        OKButton.onClick.AddListener(PlaceItem);
        MoveButton.onClick.AddListener(HideOptions);
        DeleteButton.onClick.AddListener(ReturnItemWindow);

        // 右端ボタンの画像を「戻る」に
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

    public void ClearTileOptions()
    {
        RemoveListeners();
        HideOptions();
    }

    // オプションボタンの位置が画面内に収まるよう決定する
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

    // タッチ位置の強調を移動する
    public void MoveEnphasizedTile()
    {
        TouchController.Instance.AfterCloseTouchOption = true;
        HideOptions();
    }

    // タッチ位置の強調を削除する
    public void DeleteEnphasizedTile() 
    {
        // （TODO）持ち物に戻す作業が必要！！！
        TileController.Instance.DeleteEmphasizedItem();
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
