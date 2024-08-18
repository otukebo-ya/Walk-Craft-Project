using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class UIDirector : MonoBehaviour
{
    // シングルトン
    private static UIDirector _instance;
    public static UIDirector Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (UIDirector)FindObjectOfType(typeof(UIDirector));
                if (null == _instance)
                {
                    Debug.Log("UIDirector Instance Error");
                }
            }
            return _instance;
        }
    }

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
            Sprite[] icon = item.Icons;
            string name = item.Name;
            GameObject itemButton = Instantiate(ItemButton);

            itemButton.transform.parent = content.transform;
            itemButton.name = name;
            itemButton.GetComponent<Image>().sprite = icon[0];
            itemButton.GetComponent<ItemButton>().Active = icon[0];
            itemButton.GetComponent<ItemButton>().Inactive = icon[1];
            itemButton.GetComponent<ItemButton>().Tile = item.Tile;
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
