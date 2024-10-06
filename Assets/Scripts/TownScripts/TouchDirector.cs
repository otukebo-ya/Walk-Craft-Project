using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchDirector : MonoBehaviour
{
    // シングルトン
    private static TouchDirector _instance;
    public static TouchDirector Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TouchDirector)FindObjectOfType(typeof(TouchDirector));
                if (null == _instance)
                {
                    Debug.Log("TouchDirector Instance Error");
                }
            }
            return _instance;
        }
    }

    private Vector3 _scrollStartPos = new Vector3(); // スクロールの起点となるタッチポジション
    private Vector3 _sceenPosition = new Vector3();
    private static float SCROLL_DISTANCE_CORRECTION = 0.8f; // スクロール距離の調整
    private List<string> OnUITag = new List<string>();
    private bool _scrolled = false;
    public bool CanScroll = true;

    // Update is called once per frame
    void Update()
    {
        // 中身の初期化
        OnUITag.Clear();
        CanScroll = true;
        // ステートごとの固有の処理
        TownSceneStateMachine.Instance.Update();
        
        // ウィンドウ表示中などは、スクロールやタッチしたタイルの協調を無効にする必要がある
        if (!CanScroll) { return; }

        // スクロール処理
        /*
        #if UNITY_IOS || UNITY_ANDROID //IOSまたはAndroidの時
        	if (Input.GetMouseButtonDown (0))
            {
                // タッチ操作のポジションを取得
                var touchPosition = Input.mousePosition;
                _sceenPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        
                // スクロールしているか調べる。
                if (_sceenPosition != _scrollStartPos)
                {
                    _scrolled = true;
                }
        
                // タッチした場所がUIの上か調べる
                var isOnUI = IsOnUI(touchPosition);
        
                // UIの上でないならスクロール処理を行う。
                if (!isOnUI)
                {
                    // マスを強調
                    TileDirector.Instance.EmphasizeCrickedTile(_sceenPosition);
        
                    Scroll();
                }
            } else{
                // タッチを離したらスクロール開始位置を初期化する 
                _scrollStartPos = new Vector3();
                _scrolled = false;
            }
        #else */ //Unityエディターの時

            // スクロール処理

            if (Input.GetMouseButtonDown(0))
            {
                var touchPosition = Input.mousePosition;
                // スクロール開始位置を取得
                _scrollStartPos = Camera.main.ScreenToWorldPoint(touchPosition);
                _scrolled = true;
            }
            if (Input.GetMouseButton(0))
            {

                // タッチ操作のポジションを取得
                var touchPosition = Input.mousePosition;
                _sceenPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                // スクロールしているか調べる。

                // タッチした場所がUIの上か調べる
                var isOnUI = IsOnUI(touchPosition);

                // UIの上でないならスクロール処理を行う。
                if (!isOnUI)
                {
                    // マスを強調
                    TileDirector.Instance.EmphasizeCrickedTile(_sceenPosition);

                    Scroll();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (!_scrolled) { HandleTilePlacement(); }
                // タッチを離したらスクロール開始位置を初期化する 
                _scrollStartPos = new Vector3();
                _scrolled = false;
            }
        // #endif
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
            bool isOnUI;
            var rayResults = RayCast(position);

            foreach (RaycastResult result in rayResults)
            {
                // 中身の確認処理
                var tag = result.gameObject.tag;

                if (tag == "UI")
                {
                    OnUITag.Add(tag);
                }
            }

            // ３項演算子を使った方が短くなるけど、どうする？
            if (OnUITag.Count != 0)
            {
                isOnUI = true;
            }
            else
            {
                isOnUI = false;
            }

            return isOnUI;
        }

        // スクロール情報を取得し、Cameraの位置を移動させる
        private void Scroll()
        {
            Vector3 touchMovePos = _sceenPosition;
            Debug.Log("diff");
            _scrolled = true;
            // 直前のタッチ位置との差を取得する
            Vector3 diffPos = SCROLL_DISTANCE_CORRECTION * (touchMovePos - _scrollStartPos);
            CameraController.Instance.CamPosMove(diffPos);
            _scrollStartPos = touchMovePos;


        }

        // 主にstateがItemPlaceStateのときに用いることになると思う
        public void HandleTilePlacement()
        {
            // タッチ操作のポジションを取得
            var touchPosition = Input.mousePosition;
            _sceenPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // タッチした場所がUIの上か調べる
            var isOnUI = IsOnUI(touchPosition);

            // UIの上でないならタイルの設置
            if (!isOnUI)
            {
                var td = TileDirector.Instance;
                // (TODO配置するか確認する処理)

                // タイルを設置
                td.ChangeTile(_sceenPosition);
            }
        }
    }
