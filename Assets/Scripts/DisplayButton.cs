using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : Button
{
    [SerializeField] GameObject _visibilityChangeTarget;
    public override void OnClick()
    {
        base.OnClick();
        DisplayItemWindow();
    }

    public void DisplayItemWindow()
    {
        // �\������ꍇ��active�ɂ��Ă���q�v�f���쐬
        if (_flg)
        {
            uidScript.SwitchVisibility(_flg, _visibilityChangeTarget);
            uidScript.DisplayItemWindow();
        }

        // ��\���ɂ���ꍇ�Awindow��acrive�̂����Ɏq�v�f������
        else
        {
            uidScript.DestroyItemWindow();
            uidScript.SwitchVisibility(_flg, _visibilityChangeTarget);
        }
    }
}
