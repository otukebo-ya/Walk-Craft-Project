using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDirector : TownSceneInitializer
{
    [SerializeField] GameObject _displayWindow;

    public ItemDataBase ItemDataBase;
    public GameObject ItemButton;

    // Start is called before the first frame update
    void Start()
    {
        _displayWindow.SetActive(false);
    }

    // 与えられたゲームオブジェクトの表示非表示を切り替える
    public void SwitchVisibility(bool visible, GameObject gameObject)
    {
        gameObject.SetActive(visible);
    }

    public void DisplayItemWindow()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        foreach (Item item in ItemDataBase.items)
        {
            var icon = item.GetIcon();
            string name = item.GetName();
            GameObject itemButton = Instantiate(ItemButton);

            itemButton.transform.parent = content.transform;
            itemButton.name = name;
            itemButton.GetComponent<Image>().sprite = icon;
            TMP_Text buttonText = itemButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
        }
    }

    public void DestroyItemWindow()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        if (content == null || content.transform == null)
        {
            return;
        }
        foreach (Transform n in content.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
