using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutButton : ButtonScript
{
    public override void OnClick()
    {
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.LayoutState);
    }
}
