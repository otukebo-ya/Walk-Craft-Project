using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このクラスは、ゲームの進行を管理します
public class TownSceneManager : MonoBehaviour
{
    // シングルトン
    private static TownSceneManager _instance;
    public static TownSceneManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TownSceneManager)FindObjectOfType(typeof(TownSceneManager));
                if (null == _instance)
                {
                    Debug.Log("TownSceneManager Instance Error");
                }
            }
            return _instance;
        }
    }

    public void Awake()
    {
        TownSceneStateMachine.Instance.Initialize(TownSceneStateMachine.Instance.ViewState);
    }

    public void OnDestroy() 
    {
        // ステートマシンの削除
        TownSceneStateMachine.Instance.Cleanup();
    }
}
