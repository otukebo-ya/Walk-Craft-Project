using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void onClick()
    {
        // ここでボタンの見た目も変化させる

        // タイルチェンジモードに切り替えする
        gmScript.setTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.getItemByName(name);
        tdScript.newItemTile = item.tileBase;
    }
}
