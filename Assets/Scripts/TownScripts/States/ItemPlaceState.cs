using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceState : ITownSceneState
{
    public string StateName => "ItemPlaceState";

    private GameObject _window = GameObject.Find("Window");

    public void Enter()
    {
        UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>().SetItemPlaceOptionListener();
    }

    public void Update()
    {
        TouchController.Instance.HandleTilePlaceTouchOption();
    }

    public void Exit()
    {
        var TouchedTileOption = UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>();
        TouchedTileOption.RemoveListeners();
        TouchedTileOption.HideOptions();
        TileController.Instance.ResetChoice();
    }
}