using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutState : ITownSceneState
{
    public string StateName => "LayoutState";

    public void Enter()
    {
        // 収集へボタンをフェードアウト
        // Viewへ戻るボタンをフェードイン
        UIDirector.Instance.DisplayLayoutStateUI();
    }

    public void Update()
    {
        // タッチした場所にアイテムがあれば、それを取り外すかを聞くウィンドウ
        // ウィンドウが表示されているときは、
        // ほかのところをタッチするとウィンドウを閉じるように
    }

    public void Exit()
    {
        // Viewへ戻るボタンをフェードアウト
    }
}
