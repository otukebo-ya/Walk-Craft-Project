using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceState : ITownSceneState
{
    public string StateName => "ItemPlaceState";

    private GameObject _window = GameObject.Find("Window");

    public void Enter()
    {
        UIDirector.Instance.SwitchVisibility(true, _window);
        UIDirector.Instance.DisplayItemWindow();
    }

    public void Update()
    {
        TouchController.Instance.HandleTilePlacement();
    }

    public void Exit()
    {
        
        UIDirector.Instance.DestroyWindow();
        UIDirector.Instance.SwitchVisibility(false, _window);
    }
}