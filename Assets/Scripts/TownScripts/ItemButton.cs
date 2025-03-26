using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemButton : ButtonScript
{
    private TileBase _tile;

    public TileBase Tile { get; set; }

    public override void OnClick()
    {
        base.OnClick();
        var name = this.gameObject.name;
        Item item = UIDirector.Instance.ItemDataBase.GetItemByName(name);
        TileController.Instance.ChoicedItemTile = item.Tile;

        List<string> ignoreButtons = new List<string>();
        if(TownSceneStateMachine.Instance.LastBaseState == TownSceneStateMachine.Instance.ViewState)
        {
            ignoreButtons.Add("ReturnButton");
        }
        else
        {
            ignoreButtons.Add("LayoutButton");
        }
        UIDirector.Instance.FadeInButtons(ignoreButtons);
        TownSceneStateMachine.Instance.TransitionTo(TownSceneStateMachine.Instance.ItemPlaceState);
    }
}