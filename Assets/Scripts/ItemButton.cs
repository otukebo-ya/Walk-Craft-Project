using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button
{
    public override void OnClick()
    {
        // �����Ń{�^���̌����ڂ��ω�������

        // �^�C���`�F���W���[�h�ɐ؂�ւ�����
        GameManager.Instance.SetTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = UIDirector.Instance.ItemDataBase.GetItemByName(name);
        TileDirector.Instance.NewItemTile = item.TileBase;
    }
}
