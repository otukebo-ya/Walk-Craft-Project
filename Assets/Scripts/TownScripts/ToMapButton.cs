using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToMapButton : ButtonScript
{
    
    public override void OnClick() 
    {
        MoveMapScene();
    }
    private void MoveMapScene()
    {
        Debug.Log("ToMapScene!");
        SceneManager.LoadScene("MapScene");
    }
}
