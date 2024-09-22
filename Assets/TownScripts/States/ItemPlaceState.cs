using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceState : ITownSceneState
{
    public string StateName => "ItemPlaceState";

    private GameObject _target = GameObject.Find("ItemWindow");

    public void Enter()
    {
        UIDirector.Instance.SwitchVisibility(true, _target);
        UIDirector.Instance.DisplayItemWindow();
    }

    public void Update()
    {
        TouchDirector.Instance.HandleTilePlacement();
    }

    public void Exit()
    {
        UIDirector.Instance.DestroyItemWindow();
        UIDirector.Instance.SwitchVisibility(false, _target);
    }
}