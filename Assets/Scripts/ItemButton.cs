using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void OnClick()
    {
        // �����Ń{�^���̌����ڂ��ω�������

        // �^�C���`�F���W���[�h�ɐ؂�ւ�����
        gmScript.SetTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.GetItemByName(name);
        tdScript.NewItemTile = item.TileBase;
    }
}
