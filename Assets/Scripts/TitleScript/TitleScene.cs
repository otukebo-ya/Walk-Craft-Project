﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveTownScene();
        }
    }

    // シーンをTownSceneに切り替え
    private void MoveTownScene() {
        Debug.Log("ToTownScene!");
        SceneManager.LoadScene("TownScene");
    }
}
