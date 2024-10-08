using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindowState : ITownSceneState
{
    public string StateName => "ItemWindowState";

    private GameObject _window = GameObject.Find("Window");
    

    public void Enter()
    {
        UIDirector.Instance.DisplayItemWindow();
    }

    public void Update()
    {
        // スクロール操作や、タッチ部分の協調などがおきないように
        TouchController.Instance.CanScroll = false;
    }

    public void Exit()
    {
        UIDirector.Instance.DestroyWindow();
    }
}
