using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : ButtonScript
{
    public override void OnClick()
    {
        DisplayItemWindow();
        base.OnClick();
    }

    public void DisplayItemWindow()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ItemWindowState);
    }
}
