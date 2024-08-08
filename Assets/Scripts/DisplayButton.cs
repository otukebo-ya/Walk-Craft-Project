using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : Button
{
    [SerializeField] GameObject visibilityChangeTarget;
    public override void changeImage()
    {
        base.changeImage();

        // 表示する場合はactiveにしてから子要素を作成
        if (flg)
        {
            uidScript.switchVisibility(flg, visibilityChangeTarget);
            uidScript.displayItemWindow();
        }
        // 非表示にする場合、windowがacriveのうちに子要素を消去
        else
        {
            uidScript.destroyItemWindow();
            uidScript.switchVisibility(flg, visibilityChangeTarget);
        }
    }
}
