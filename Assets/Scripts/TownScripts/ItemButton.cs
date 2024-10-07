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
        TileController.Instance.NewItemTile = item.Tile;
    }
}