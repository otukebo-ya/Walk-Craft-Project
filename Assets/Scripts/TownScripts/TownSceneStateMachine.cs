using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneStateMachine
{
    public ITownSceneState CurrentState { get; private set; }
    public ViewState ViewState { get; private set; }
    public ItemWindowState ItemWindowState { get; private set; }
    public ItemPlaceState ItemPlaceState { get; private set; }

    // プライベートコンストラクタ  
    private TownSceneStateMachine() 
    {  
        this.ViewState = new ViewState();
        this.ItemWindowState = new ItemWindowState();
        this.ItemPlaceState = new ItemPlaceState();
    }

    // MonoBehaviourを用いない場合のシングルトン
    private static TownSceneStateMachine _instance;
    // インスタンスを取得するためのプロパティ  
    public static TownSceneStateMachine Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TownSceneStateMachine();
            }
            return _instance;
        }
    }

    // ステートマシーンの初期化。Viewで初期化することになるはず
    public void Initialize(ITownSceneState state)
    {
        CurrentState = state;
        state.Enter();
    }

    // 現在のステートを抜けて次のステートへ移る処理
    public void TransitionTo(ITownSceneState nextState)
    {
        Debug.Log(CurrentState.StateName + " => " + nextState.StateName);
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    // 現在のステートならばUpdate処理
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
    
    public string CheckCurrentState()
    {
        return CurrentState.StateName;
    }

    // 破棄メソッド  
    public void Cleanup()
    {
        _instance = null; // インスタンスを破棄  
    }
}
