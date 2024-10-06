using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewState : ITownSceneState
{
    public string StateName => "ViewState";

    public void Enter()
    {
        // 非表示、あるいは画面外のボタンがあれば元に戻す
        // アニメーションとして実装したほうがいい
    }

    public void Update()
    {
        // 触ったアイテムがアニメーションすると楽しいんだがね

    }

    public void Exit()
    {
        // 次の状態へ移る際の終了処理など
    }
}
