using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITownSceneState
{
    string StateName { get; }

    public void Enter()
    {
        // その状態になった瞬間の処理
    }

    public void Update()
    {
        // 毎フレームの処理
    }

    public void Exit()
    {
        // 次の状態へ移る際の終了処理など
    }
}
