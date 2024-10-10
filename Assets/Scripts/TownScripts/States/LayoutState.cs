using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


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

        UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>().SetLayoutOptionListener();

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
        TouchController.Instance.HandleLayoutTouchOption();
    }

    public void Exit()
    {
        var TouchedTileOption = UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>();
        TouchedTileOption.RemoveListeners();
        TouchedTileOption.HideOptions();
    }
}
