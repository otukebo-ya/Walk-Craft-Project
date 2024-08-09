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
        // 表示する場合はactiveにしてから子要素を作成
        if (_flg)
        {
            UIDirector.Instance.SwitchVisibility(_flg, _visibilityChangeTarget);
            UIDirector.Instance.DisplayItemWindow();
        }

        // 非表示にする場合、windowがacriveのうちに子要素を消去
        else
        {
            UIDirector.Instance.DestroyItemWindow();
            UIDirector.Instance.SwitchVisibility(_flg, _visibilityChangeTarget);
        }
    }
}
