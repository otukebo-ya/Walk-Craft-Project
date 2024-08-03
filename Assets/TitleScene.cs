using System.Collections;
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
            moveTownScene();
        }
    }

    // ƒV[ƒ“‚ğTownScene‚ÉØ‚è‘Ö‚¦
    private void moveTownScene() {
        SceneManager.LoadScene("TownScene");
    }
}
