using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewState : ITownSceneState
{
    public string StateName => "ViewState";

    public void Enter()
    {

    }

    public void Update()
    {
        // 触ったアイテムがアニメーションするとうれしい
    }

    public void Exit()
    {
        // 次の状態へ移る際の終了処理など
        UIDirector.Instance.TouchOption.GetComponent<TouchedTileOption>().RemoveListeners();
    }
}
