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
    public GameObject ItemPanel;

    [SerializeField] TMP_Text PlayerNameText;
    [SerializeField] TMP_Text HeldCoinText;

    // Start is called before the first frame update
    void Start()
    {
        _displayWindow.SetActive(false);
        DisplayPlayerData();
    }

    // 与えられたゲームオブジェクトの表示非表示を切り替える
    public void SwitchVisibility(bool visible, GameObject gameObject)
    {
        gameObject.SetActive(visible);
    }

    public void DisplayItemWindow()
    {
        GameObject content = GameObject.Find("Window/Viewport/Content");
        foreach (Item item in ItemDataBase.items)
        {
            Sprite[] icon = item.Icons;
            string name = item.Name;
            GameObject itemPanel = Instantiate(ItemPanel);
            GameObject itemButton = itemPanel.transform.Find("ItemButton").gameObject;
            GameObject itemShadow = itemPanel.transform.Find("ItemShadow").gameObject;
            float ITEM_BUTTON_SCALE = 0.7f;

            itemPanel.transform.parent = content.transform;
            itemButton.name = name;
            itemButton.GetComponent<Image>().sprite = icon[0];
            itemButton.GetComponent<ItemButton>().Active = icon[0];
            itemButton.GetComponent<ItemButton>().Inactive = icon[1];
            itemButton.GetComponent<ItemButton>().Tile = item.Tile;

            // scaleを調整する
            Vector3 unitVector = new Vector3(ITEM_BUTTON_SCALE, ITEM_BUTTON_SCALE, 0);
            itemPanel.GetComponent<RectTransform>().localScale = unitVector;

            TMP_Text buttonText = itemButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
        }
    }

    public void DestroyWindow()
    {
        GameObject content = GameObject.Find("Window/Viewport/Content");
        if (content == null || content.transform == null)
        {
            return;
        }
        foreach (Transform t in content.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
    }

    public void DisplayPlayerData()
    {
        PlayerNameText.SetText(PlayerData.Instance.Name);
        string heldCoin = PlayerData.Instance.HeldCoin.ToString();
        HeldCoinText.SetText(heldCoin);
    }
}
