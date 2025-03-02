using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public enum Direction 
{
    TOP,
    BOTTOM,
    LEFT,
    RIGHT
}

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

    [SerializeField] GameObject _ItemWindow;
    [SerializeField] GameObject _BluePrintWindow;

    public ItemDataBase ItemDataBase;
    public GameObject ItemPanel;

    public CraftMaterialDataBase CraftMaterialDataBase;
    public GameObject MaterialPanel;

    public BluePrintDataBase BluePrintDataBase;
    public GameObject BluePrintPanel;

    public Button[] Buttons;
    public GameObject TouchOption; 

    [SerializeField] TMP_Text PlayerNameText;
    [SerializeField] TMP_Text HeldCoinText;
    [SerializeField] Canvas Canvas;
    public float CanvasWidth;
    public float CanvasHeight;
    public Vector2 CanvasPivot;
    public Vector2 CanvasPosition;

    // Start is called before the first frame update
    void Start()
    {
        var canvasRect = Canvas.GetComponent<RectTransform>();
        CanvasWidth = canvasRect.rect.width;
        CanvasHeight = canvasRect.rect.height;
        CanvasPivot = canvasRect.pivot;
        CanvasPosition = canvasRect.position;
        
        _ItemWindow.SetActive(false);
        _BluePrintWindow.SetActive(false);
        TouchOption.SetActive(false);

        DisplayPlayerData();

    }

    // 与えられたゲームオブジェクトの表示非表示を切り替える
    public void SwitchVisibility(bool visible, GameObject gameObject)
    {
        gameObject.SetActive(visible);
    }

    public void DisplayItemWindow()
    {
        FadeOutButtons();

        SwitchVisibility(true, _ItemWindow);

        Animator animator = _ItemWindow.GetComponent<Animator>();
        animator.SetTrigger("Open");

        LineUpItems();
    }

    public void LineUpItems()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        foreach (Item item in ItemDataBase.items)
        {
            Sprite[] icon = item.Icons;
            string name = item.Name;
            GameObject itemPanel = Instantiate(ItemPanel);
            GameObject itemButton = itemPanel.transform.Find("ItemButton").gameObject;
            GameObject itemShadow = itemPanel.transform.Find("ItemShadow").gameObject;
            GameObject itemImage = itemButton.transform.Find("ItemImage").gameObject;
            GameObject itemPossessionPanel = itemButton.transform.Find("PossessionPanel").gameObject;
            GameObject itemPossession = itemPossessionPanel.transform.Find("Possession").gameObject;
            float ITEM_BUTTON_SCALE = 0.7f;

            itemPanel.transform.SetParent(content.transform);
            itemButton.name = name;
            itemImage.GetComponent<Image>().sprite = icon[0];
            itemButton.GetComponent<ItemButton>().Active = icon[0];
            itemButton.GetComponent<ItemButton>().Inactive = icon[1];
            itemButton.GetComponent<ItemButton>().Tile = item.Tile;
            itemPossession.GetComponent<TextMeshProUGUI>().text = item.NumberOfPossessions.ToString();

            // scaleを調整する
            Vector3 unitVector = new Vector3(ITEM_BUTTON_SCALE, ITEM_BUTTON_SCALE, 0);
            itemPanel.GetComponent<RectTransform>().localScale = unitVector;

            TMP_Text buttonText = itemButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
            Debug.Log("ADD");
        }
    }

    public void LineUpMaterials()
    {
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        foreach (Craftmaterial material in CraftMaterialDataBase.materials)
        {
            Sprite icon = material.Image;
            string name = material.Name;
            GameObject materialPanel = Instantiate(MaterialPanel);
            GameObject materialButton = materialPanel.transform.Find("MaterialButton").gameObject;
            GameObject materialShadow = materialPanel.transform.Find("MaterialShadow").gameObject;
            GameObject materialImage = materialButton.transform.Find("MaterialImage").gameObject;
            GameObject materialPossessionPanel = materialButton.transform.Find("PossessionPanel").gameObject;
            GameObject materialPossession = materialPossessionPanel.transform.Find("Possession").gameObject;
            float ITEM_BUTTON_SCALE = 0.7f;

            materialPanel.transform.SetParent(content.transform);
            materialButton.name = name;
            materialImage.GetComponent<Image>().sprite = icon;
            materialPossession.GetComponent<TextMeshProUGUI>().text = material.NumberOfPossessions.ToString();

            // scaleを調整する
            Vector3 unitVector = new Vector3(ITEM_BUTTON_SCALE, ITEM_BUTTON_SCALE, 0);
            materialPanel.GetComponent<RectTransform>().localScale = unitVector;

            TMP_Text buttonText = materialButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
        }
    }

    public void DestroyItemWindow()
    {
        Debug.Log("DESTROY!");
        GameObject content = GameObject.Find("ItemWindow/Viewport/Content");
        if (content == null || content.transform == null)
        {
            return;
        }
        foreach (Transform t in content.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
        StartCoroutine("CloseItemWindow");
    }

    private IEnumerator CloseItemWindow()
    {
        Animator animator = _ItemWindow.GetComponent<Animator>();
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.2f);
        SwitchVisibility(false, _ItemWindow);
        yield return null;
    }

    public void DisplayBluePrintWindow()
    {
        FadeOutButtons();
        SwitchVisibility(true, _BluePrintWindow);

        Animator animator = _BluePrintWindow.GetComponent<Animator>();
        animator.SetTrigger("Open");

        LineUpBluePrints();
    }

    public void LineUpBluePrints()
    {
        GameObject content = GameObject.Find("BluePrintWindow/Viewport/Content");
        foreach (BluePrint bluePrint in BluePrintDataBase.bluePrints)
        {
            Sprite image = bluePrint.Image;
            string name = bluePrint.Name;
            GameObject bluePrintPanel = Instantiate(BluePrintPanel);
            GameObject bluePrintButton = bluePrintPanel.transform.Find("CraftButton").gameObject;
            GameObject ItemImageFrame = bluePrintPanel.transform.Find("ItemImageFrame").gameObject;
            GameObject itemImage = ItemImageFrame.transform.Find("ItemImage").gameObject;
            float ITEM_BUTTON_SCALE = 0.7f;

            bluePrintPanel.transform.SetParent(content.transform);
            bluePrintButton.name = name;
            itemImage.GetComponent<Image>().sprite = image;

            // scaleを調整する
            Vector3 unitVector = new Vector3(ITEM_BUTTON_SCALE, ITEM_BUTTON_SCALE, 0);
            bluePrintPanel.GetComponent<RectTransform>().localScale = unitVector;

            TMP_Text buttonText = bluePrintPanel.GetComponentInChildren<TMP_Text>();
            buttonText.text = name;
        }
    }

    public void DestroyBluePrintWindow()
    {
        GameObject content = GameObject.Find("BluePrintWindow/Viewport/Content");
        if (content == null || content.transform == null)
        {
            return;
        }
        foreach (Transform t in content.transform)
        {
            GameObject.Destroy(t.gameObject);
        }
        StartCoroutine("CloseBluePrintWindow");
    }

    private IEnumerator CloseBluePrintWindow()
    {
        Animator animator = _BluePrintWindow.GetComponent<Animator>();
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.2f);
        SwitchVisibility(false, _BluePrintWindow);
        _BluePrintWindow.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        yield return null;
    }

    public void FadeOutButtons()
    {
        foreach(Button b in Buttons)
        {
            FadeOutButton(b);
        }
    }

    public void FadeOutButton(Button button) 
    {
        //if (button.gameObject.name == "ReturnButton") { return; }
        Animator animator = button.GetComponent<Animator>();
        if (animator == null)
        {
            return;
        }
        ButtonScript buttonScript = button.GetComponent<ButtonScript>();
        if (buttonScript.IsInCanvas)
        {
            animator.SetTrigger("FadeOut");
            Debug.Log("fadeout");
            buttonScript.IsInCanvas = false;
        }
        else
        {
            Debug.Log(button.name+"画面内にいないよ");
        }
    }

    public void FadeInButtons(List<string> ignoreButtonName = null)
    {
        foreach (Button b in Buttons)
        {
            //if (TownSceneStateMachine.Instance.BeforeState.StateName == "ViewState")

            if (ignoreButtonName.Contains(b.gameObject.name)) {
                continue;
            }
            FadeInButton(b);
        }
    }

    public void FadeInButtons()
    {
        foreach (Button b in Buttons)
        {
            FadeInButton(b);
        }
    }

    public void FadeInButton(Button button)
    {
        Animator animator = button.GetComponent<Animator>();
        ButtonScript buttonScript = button.GetComponent<ButtonScript>();
        if (!buttonScript.IsInCanvas)
        {
            buttonScript.IsInCanvas = true;
            animator.SetTrigger("FadeIn");
        }
    }

    public void DisplayPlayerData()
    {
        PlayerNameText.SetText(PlayerData.Instance.Name);
        string heldCoin = PlayerData.Instance.HeldCoin.ToString();
        HeldCoinText.SetText(heldCoin);
    }

    public void DisplayPickOption()
    {

    }
}
