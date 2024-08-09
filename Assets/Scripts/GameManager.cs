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


public class GameManager : TownSceneInitializer
{
    private GameState _currentGameState;

    private bool _tileChangeMode;

    void Awake()
    {
        SetCurrentState(GameState.View);
        //tileChangeMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentState(GameState state)
    {
        _currentGameState = state;
        //OnGameStateChanged(currentGameState);
    }

    public GameState CheckGameState()
    {
        return _currentGameState;
    }

    public void SetTileChangeModeOn()
    {
        _tileChangeMode = true;
    }

    public void SetTileChangeModeOff()
    {
        _tileChangeMode = false;
    }

    public bool IsTileChangeMode()
    {
        return _tileChangeMode;
    }
}
