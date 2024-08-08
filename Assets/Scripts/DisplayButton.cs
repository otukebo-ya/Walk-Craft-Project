using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : Button
{
    [SerializeField] GameObject visibilityChangeTarget;
    public override void changeImage()
    {
        base.changeImage();

        // �\������ꍇ��active�ɂ��Ă���q�v�f���쐬
        if (flg)
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
}
