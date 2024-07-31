using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Sprite _on;
    public Sprite _off;
    private bool flg = false;

    [SerializeField] GameObject visibilityChangeTarget;
    public void changeImage()
    {
        GameObject uid = GameObject.Find("UIDirector");
        UIDirector uidScript = uid.GetComponent<UIDirector>();

        flg = !flg;
        var img = GetComponent<Image>();
        img.sprite = (flg) ? _on : _off;

        
        // �\������ꍇ��active�ɂ��Ă���q�v�f���쐬
        if(flg)
        {
            uidScript.switchVisibility(flg, visibilityChangeTarget);
            uidScript.displayItemWindow();
        }
        // ��\���ɂ���ꍇ�Awindow��acrive�̂����Ɏq�v�f������
        else
        {
            uidScript.destroyItemWindow();
            uidScript.switchVisibility(flg, visibilityChangeTarget);
        }
    }

    public void onDisplayButtonClick()
    {
        GameObject td = GameObject.Find("TileDirector");
        TileDirector tdScript = td.GetComponent<TileDirector>();
        GameObject uid = GameObject.Find("UIDirector");
        UIDirector uidScript = uid.GetComponent<UIDirector>();

        tdScript.tileChangeMode = true;
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.getItemByName(name);
        tdScript.newItemTile = item.tileBase;
    }
}