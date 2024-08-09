using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void OnClick()
    {
        // ここでボタンの見た目も変化させる

        // タイルチェンジモードに切り替えする
        gmScript.SetTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.GetItemByName(name);
        tdScript.NewItemTile = item.TileBase;
    }
}
