using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialToggle : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void ChangeWindow()
    {
        if (toggle.isOn)
        {
            Debug.Log("MaterialIsOn");
            UIDirector.Instance.CleanItemWindow();
            DisplayMaterials();
        }
    }

    public void DisplayMaterials()
    {
        UIDirector.Instance.LineUpMaterials();
    }
}