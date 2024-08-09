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

    private List<string> _cantScrollTag = new List<string>();
    private bool _scrollable = true;
    private bool _scrolled = true;

    // Update is called once per frame
    void Update()
    {
        // 中身の初期化
        _cantScrollTag.Clear();
        _scrollable = true;

        if (Input.GetMouseButton(0))
        {
            // タッチ操作のポジションを取得
            var touchPosition = Input.mousePosition;
            _sceenPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // レイキャストし、タッチした場所にあるオブジェクトをかくにん
            var rayCastResults = RayCast(touchPosition);

            ChangeScrollable(IsScrollable(rayCastResults));

            TileDirector.Instance.EmphasizeCrickedTile(_sceenPosition);

            // スクロール可能ならスクロール処理を行う。
            if (_scrollable) Scroll();
        }
        else
        {
            // タッチを離したらスクロール開始位置を初期化する 
            _scrollStartPos = new Vector3();
        }
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
    private bool IsScrollable(List<RaycastResult> rayResults)
    {
        bool isScrollable;
        foreach (RaycastResult result in rayResults)
        {
            // 中身の確認処理
            var tag = result.gameObject.tag;

            if (tag == "CantScroll")
            {
                _cantScrollTag.Add(tag);
            }
        }

        if (_cantScrollTag.Count != 0)
        {
            isScrollable = false;
        }
        else
        {
            isScrollable = true;
        }

        return isScrollable;
    }

    // スクロール情報を取得し、Cameraの位置を移動させる
    private void Scroll()
    {
        if (_scrollStartPos.x == 0.0f)
        {
            _scrolled = false;
            // スクロール開始位置を取得
            _scrollStartPos = _sceenPosition;
        }
        else
        {
            Vector3 touchMovePos = _sceenPosition;
            if (_scrollStartPos != touchMovePos)
            {
                _scrolled = true;
                // 直前のタッチ位置との差を取得する
                Vector3 diffPos = SCROLL_DISTANCE_CORRECTION * (touchMovePos - _scrollStartPos);
                CameraController.Instance.CamPosMove(diffPos);
                _scrollStartPos = touchMovePos;
            }
        }
    }

    public void ChangeScrollable(bool change)
    {
        _scrollable = change;
    }

    public bool CheckScrolled()
    {
        return _scrolled;
    }
}
