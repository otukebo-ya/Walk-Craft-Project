#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceState : ITownSceneState
{
    public string StateName => "ItemPlaceState";

    private GameObject _window = GameObject.Find("Window");
    private TouchedTileOption? _touchedTileOption = null;

    public void Enter()
    {
        if (_touchedTileOption is null)
        {
            _touchedTileOption = UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>();
        }
        _touchedTileOption.SetItemPlaceOptionListener();
    }

    public void Update()
    {
        TouchController.Instance.HandleTilePlaceTouchOption();
    }

    public void Exit()
    {
        _touchedTileOption?.ClearTileOptions();
        TileController.Instance.ClearTileController();
    }
}