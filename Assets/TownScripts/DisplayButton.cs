using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : Button
{
    public override void OnClick()
    {
        DisplayItemWindow();
        base.OnClick();
    }

    public void DisplayItemWindow()
    {
        // 表示する場合
        if (_flg)
        {
            TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ItemPlaceState);
        }

        // 非表示にする場合
        else
        {
            TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ViewState);
        }
    }
}
