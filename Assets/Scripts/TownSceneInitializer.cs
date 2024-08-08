using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneInitializer : MonoBehaviour
{
    protected GameObject uid;
    protected UIDirector uidScript;
    protected GameObject td;
    protected TileDirector tdScript;
    protected GameObject gm;
    protected GameManager gmScript;
    protected GameObject cc;
    protected CameraController ccScript;

    protected virtual void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        uid = GameObject.Find("UIDirector");
        uidScript = uid.GetComponent<UIDirector>();

        td = GameObject.Find("TileDirector");
        tdScript = td.GetComponent<TileDirector>();

        gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();

        cc = GameObject.Find("Main Camera");
        ccScript = cc.GetComponent<CameraController>();
    }
}
