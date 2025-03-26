using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToggle : MonoBehaviour
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
            Debug.Log("ItemIsOn");
            UIDirector.Instance.CleanItemWindow();
            DisplayItems();
        }
    }

    public void DisplayItems()
    {
        UIDirector.Instance.LineUpItems();
    }
}
