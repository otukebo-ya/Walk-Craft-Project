using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void onClick()
    {
        // �����Ń{�^���̌����ڂ��ω�������

        // �^�C���`�F���W���[�h�ɐ؂�ւ�����
        gmScript.setTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.getItemByName(name);
        tdScript.newItemTile = item.tileBase;
    }
}
