using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintButton : ButtonScript
{
    public override void OnClick()
    {
        DisplayBluePrintWindow();
        base.OnClick();
    }

    public void DisplayBluePrintWindow()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.BluePrintWindowState);
    }
}

