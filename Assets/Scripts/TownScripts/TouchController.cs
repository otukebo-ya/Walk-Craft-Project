using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TouchController : MonoBehaviour
{
    // シングルトン
    private static TouchController _instance;
    public static TouchController Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TouchController)FindObjectOfType(typeof(TouchController));
                if (null == _instance)
                {
                    Debug.Log("TouchController Instance Error");
                }
            }
            return _instance;
        }
    }

    private Vector3 _scrollStartPos = new Vector3(); // スクロールの起点となるタッチポジション
    private Vector3 _screenPosition = new Vector3();
    private static float SCROLL_DISTANCE_CORRECTION = 0.8f; // スクロール距離の調整
    private bool _scrolled = false;
    public bool CanScroll = true;
    public GameObject TouchOption;
    public bool AfterCloseTouchOption = false;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        CanScroll = true;

        // ステートごとの固有の処理
        TownSceneStateMachine.Instance.Update();
        
        if (!CanScroll) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            var touchPosition = Input.mousePosition;
            // スクロール開始位置を取得
            _scrollStartPos = _mainCamera.ScreenToWorldPoint(touchPosition);
        }

        if (Input.GetMouseButton(0))
        {
            // タッチ操作のポジションを取得
            var touchPosition = Input.mousePosition;
            _screenPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
            // スクロールしているか調べる。

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            // UIの上でないならスクロール処理を行う。
            if (!isOnUI)
            {
                Scroll();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // タッチを離したらスクロール開始位置を初期化する 
            _scrollStartPos = new Vector3();
            _scrolled = false;
        }
        AfterCloseTouchOption = false;
    }

    // レイキャストを投げて、結果を返す
    public List<RaycastResult> RayCast(Vector3 position)
    {
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.position = position;
        List<RaycastResult> rayResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointData, rayResults);

        return rayResults;
    }

    // レイキャスト結果のタグを確認し、スクロール可能かを返す
    private bool IsOnUI(Vector3 position)
    {
        var rayResults = RayCast(position);

        return rayResults.Exists(result => result.gameObject.CompareTag("UI"));
    }

    // スクロール情報を取得し、Cameraの位置を移動させる
    private void Scroll()
    {
        Vector3 touchMovePos = _screenPosition;
        // 直前のタッチ位置との差を取得する
        Vector3 diffPos = SCROLL_DISTANCE_CORRECTION * (touchMovePos - _scrollStartPos);
        if ((touchMovePos - _scrollStartPos).magnitude > 0.01f)
        {
            _scrolled = true;
        }
        CameraController.Instance.CamPosMove(diffPos);
    }

    // 主にstateがItemPlaceStateのときに用いることになると思う
    public void HandleTilePlacement()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // タッチ操作のポジションを取得
            var touchPosition = Input.mousePosition;
            _screenPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            // UIの上でないならタイルの設置
            if (!isOnUI)
            {
                // (TODO配置するか確認する処理)

                // タイルを設置
                TileController.Instance.ChangeTile(_screenPosition);
            }
        }
    }

    public void HandleLayoutTouchOption() {
        if (AfterCloseTouchOption) { return; }

        if (Input.GetMouseButton(0))
        {
            TouchedTileOption touchOptionScript = TouchOption.GetComponent<TouchedTileOption>();
            var touchPosition = Input.mousePosition;
            _screenPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            if (_scrolled) {
                touchOptionScript.HideOptions();
                TileController.Instance.DeleteEmphasis();
                return;
            }

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            // (TODO)タッチした場所にアイテムがあれば、それを取り外すかを聞くウィンドウ
            // ウィンドウが表示されているときは、
            // ほかのところをタッチするとウィンドウを閉じるように
            TileBase tile = TileController.Instance.GetTile(_screenPosition, TilemapType.Item);
            if (tile) 
            {
                TileController.Instance.EmphasizeCrickedTile(_screenPosition);
                touchOptionScript.ShowOptions(touchPosition);
            }
            else if(!isOnUI)
            {
                touchOptionScript.HideOptions();
                TileController.Instance.DeleteEmphasis();
            }
        }
    }

    public void HandleTilePlaceTouchOption()
    {
        if (AfterCloseTouchOption) { return; }

        if (Input.GetMouseButton(0))
        {
            TouchedTileOption touchOptionScript = TouchOption.GetComponent<TouchedTileOption>();
            var touchPosition = Input.mousePosition;
            _screenPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            if (_scrolled)
            {
                touchOptionScript.HideOptions();
                TileController.Instance.DeleteEmphasis();
                return;
            }

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            // (TODO)タッチした場所にアイテムがあれば、それを取り外すかを聞くウィンドウ
            // ウィンドウが表示されているときは、
            // ほかのところをタッチするとウィンドウを閉じるように
            //TileBase tile = TileController.Instance.GetTile(_screenPosition, TilemapType.Item);
            if (!isOnUI)
            {
                TileController.Instance.EmphasizeCrickedTile(_screenPosition);
                touchOptionScript.ShowOptions(touchPosition);
            }
        }
    }

    public TileBase MemorizeTile() {
        TileBase TouchedTile = TileController.Instance.GetTile(_screenPosition, TilemapType.Item);
        if (TouchedTile)
        {
            Debug.Log("tilePicked!  " + TouchedTile.name);
        }
        
        return TouchedTile;
    }

    public TileBase IsOnTile() {
        if (Input.GetMouseButtonDown(0))
        {
            // タッチ操作のポジションを取得
            var touchPosition = Input.mousePosition;
            _screenPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            if (isOnUI) { return null; }

            TileBase tile = TileController.Instance.GetTile(_screenPosition, TilemapType.Item);
            if (tile)
            {
                Debug.Log("tile  " + tile.name);
            }
            return tile;
        }
        return null;
    }
}
