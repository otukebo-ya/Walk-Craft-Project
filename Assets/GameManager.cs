using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool tileChangeMode;
    // Start is called before the first frame update
    void Start()
    {
        tileChangeMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // タイルチェンジモード
    public bool isTileChangeMode() {
        return tileChangeMode;
    }

    public void setTileChangeModeOn() {
        tileChangeMode = true;
    }

    public void setTileChangeModeOff()
    {
        tileChangeMode = false;
    }
}
