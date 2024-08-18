using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    View,
    ItemWindow,
    Place,
    Shop,
}


public class GameManager : MonoBehaviour
{
    // シングルトン
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (null == _instance)
                {
                    Debug.Log("GameManager Instance Error");
                }
            }
            return _instance;
        }
    }

    private GameState _currentGameState;

    public bool TileChangeMode{ get; set; }

    public GameState CurrentGameState {
        get
        {
            return this._currentGameState;
        }
        set
        { 
            this._currentGameState = value;
            // OnGameStateChanged(currentGameState);
        }
    }


    void Awake()
    {
        this.CurrentGameState = GameState.View;
        TileChangeMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGameStateChanged(GameState state)
    {

    }
}
