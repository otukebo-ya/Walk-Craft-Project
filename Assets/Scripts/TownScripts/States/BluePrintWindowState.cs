using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintWindowState :ITownSceneState
{
    public string StateName => "BluePrintWindowState";

    public void Enter()
    {
        UIDirector.Instance.DisplayBluePrintWindow();
    }

    public void Update()
    {
        // スクロール操作や、タッチ部分の協調などがおきないように
        TouchController.Instance.CanScroll = false;
    }

    public void Exit()
    {
        UIDirector.Instance.DestroyBluePrintWindow();
    }
}
