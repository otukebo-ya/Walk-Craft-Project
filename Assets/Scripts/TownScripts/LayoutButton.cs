using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutButton : ButtonScript
{
    public static float BOTTOM_SPACE = 40f;
    public override void OnClick()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.LayoutState);
    }
}
