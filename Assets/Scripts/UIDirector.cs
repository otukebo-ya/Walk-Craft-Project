using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDirector : MonoBehaviour
{
    // �V���O���g��
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

    // �^����ꂽ�Q�[���I�u�W�F�N�g�̕\����\����؂�ւ���
    public void SwitchVisibility(bool visible, GameObject gameObject)
    {
        gameObject.SetActive(visible);
    }

    public void DisplayItemWindow()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        foreach (Item item in ItemDataBase.items)
        {
            Sprite[] icon = item.GetIcon();
            string name = item.GetName();
            GameObject itemButton = Instantiate(ItemButton);

            itemButton.transform.parent = content.transform;
            itemButton.name = name;
            itemButton.GetComponent<Image>().sprite = icon[0];
            itemButton.GetComponent<ItemButton>().Active = icon[0];
            itemButton.GetComponent<ItemButton>().Inactive = icon[1];
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
