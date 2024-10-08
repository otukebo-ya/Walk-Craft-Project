using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceState : ITownSceneState
{
    public string StateName => "ItemPlaceState";

    private GameObject _window = GameObject.Find("Window");

    public void Enter()
    {

    }

    public void Update()
    {
        TouchController.Instance.HandleTilePlacement();
    }

    public void Exit()
    {

    }
}