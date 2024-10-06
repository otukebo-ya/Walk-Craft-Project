using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToTownButton : ButtonScript
{
    public override void OnClick()
    {
        MoveTownScene();
    }
    private void MoveTownScene()
    {
        Debug.Log("ToTownScene!");
        SceneManager.LoadScene("TownScene");
    }
}