using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : ButtonScript
{
    public static float BOTTOM_SPACE = 40f;
    public override void Awake() {
        base.IsInCanvas = false;
    }

    public override void OnClick()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ViewState);
    }
}
