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
            UIDirector.Instance.SwitchVisibility(_flg, _visibilityChangeTarget);
            UIDirector.Instance.DisplayItemWindow();
        }

        // ��\���ɂ���ꍇ�Awindow��acrive�̂����Ɏq�v�f������
        else
        {
            UIDirector.Instance.DestroyItemWindow();
            UIDirector.Instance.SwitchVisibility(_flg, _visibilityChangeTarget);
        }
    }
}
