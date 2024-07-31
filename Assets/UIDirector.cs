using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIDirector : MonoBehaviour
{
    [SerializeField] GameObject DisplayWindow;

    public ItemDataBase ItemDataBase;
    // Start is called before the first frame update

    public GameObject ItemButton;
    void Start()
    {
        DisplayWindow.SetActive(false);
    }

    public void switchVisibility(bool visible, GameObject gameObject)
    {
        gameObject.SetActive(visible);
    }

    public void displayItemWindow()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        foreach (Item item in ItemDataBase.items)
        {
            var icon = item.getIcon();
            string name = item.getName();
            GameObject itemButton = Instantiate(ItemButton);

            itemButton.transform.parent = content.transform;
            itemButton.name = name;
            itemButton.GetComponent<Image>().sprite = icon;
            TMP_Text buttonText = itemButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
            Debug.Log("display: " + name);
        }
    }

    public void destroyItemWindow()
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
