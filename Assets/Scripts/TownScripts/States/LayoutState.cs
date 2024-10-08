using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutState : ITownSceneState
{
    public string StateName => "LayoutState";

    public void Enter()
    {
        // 収集へボタンをフェードアウト
        // Viewへ戻るボタンをフェードイン
        // 非表示、あるいは画面外のボタンがあれば元に戻す
        Button layoutButton = GameObject.Find("LayoutButton").GetComponent<Button>();
        Button returnButton = GameObject.Find("ReturnButton").GetComponent<Button>();

        LayoutButton LayoutButtonScript = layoutButton.GetComponent<LayoutButton>();
        ReturnButton ReturnButtonScript = returnButton.GetComponent<ReturnButton>();
        if (LayoutButtonScript.IsInCanvas) {
            UIDirector.Instance.FadeOutButton(layoutButton);
        }

        if (!ReturnButtonScript.IsInCanvas) {
            UIDirector.Instance.FadeInButton(returnButton);

        }

        TownSceneStateMachine.Instance.LastBaseState = TownSceneStateMachine.Instance.LayoutState;
    }

    public void Update()
    {
        // タッチした場所にアイテムがあれば、それを取り外すかを聞くウィンドウ
        // ウィンドウが表示されているときは、
        // ほかのところをタッチするとウィンドウを閉じるように
        TouchController.Instance.PickTile();
    }

    public void Exit()
    {
        // Viewへ戻るボタンをフェードアウト
    }
}
