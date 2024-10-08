using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowButton : ButtonScript
{
    public override void OnClick()
    {
        CloseWindow();
        base.OnClick();
    }

    public void CloseWindow()
    {
        string beforeState = TownSceneStateMachine.Instance.BeforeState.StateName;
        List<string> ignoreButtonName = new List<string>();
        if (beforeState == "ViewState")
        {
            ignoreButtonName.Add("ReturnButton");
        }
        else if (beforeState == "LayoutState") 
        {
            ignoreButtonName.Add("LayoutButton");
        }
        UIDirector.Instance.FadeInButtons(ignoreButtonName);
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.BeforeState);
    }
}