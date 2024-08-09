using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void OnClick()
    {
        // ここでボタンの見た目も変化させる

        // タイルチェンジモードに切り替えする
        GameManager.Instance.SetTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = UIDirector.Instance.ItemDataBase.GetItemByName(name);
        TileDirector.Instance.NewItemTile = item.TileBase;
    }
}
