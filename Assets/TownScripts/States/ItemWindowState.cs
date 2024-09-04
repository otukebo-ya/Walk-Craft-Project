using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindowState : ITownSceneState
{
    private GameObject _target = GameObject.Find("ItemWindow");
    public string StateName => "ItemWindowState";

    // activeにしてから子要素を作成
    public void Enter()
    {
        UIDirector.Instance.SwitchVisibility(true, _target);
        UIDirector.Instance.DisplayItemWindow();
    }

    public void Update()
    {
        // 毎フレームの処理
    }

    // windowがacriveのうちに子要素を消去
    public void Exit()
    {
        UIDirector.Instance.DestroyItemWindow();
        UIDirector.Instance.SwitchVisibility(false, _target);
    }
}
