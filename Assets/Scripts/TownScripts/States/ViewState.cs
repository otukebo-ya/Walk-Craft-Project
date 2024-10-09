using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewState : ITownSceneState
{
    public string StateName => "ViewState";

    public void Enter()
    {
        // 非表示、あるいは画面外のボタンがあれば元に戻す
        Button layoutButton = GameObject.Find("LayoutButton").GetComponent<Button>();
        Button returnButton = GameObject.Find("ReturnButton").GetComponent<Button>();

        LayoutButton LayoutButtonScript = layoutButton.GetComponent<LayoutButton>();
        ReturnButton ReturnButtonScript = returnButton.GetComponent<ReturnButton>();

        if (!LayoutButtonScript.IsInCanvas) {
            UIDirector.Instance.FadeInButton(layoutButton);
        }

        if (ReturnButtonScript.IsInCanvas) {
            UIDirector.Instance.FadeOutButton(returnButton);
        }

        TownSceneStateMachine.Instance.LastBaseState = TownSceneStateMachine.Instance.ViewState;

    }

    public void Update()
    {
        // 触ったアイテムがアニメーションすると楽しいんだがね

    }

    public void Exit()
    {
        // 次の状態へ移る際の終了処理など
        UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>().RemoveListeners();
    }
}
