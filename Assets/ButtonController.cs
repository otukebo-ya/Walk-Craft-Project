using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Sprite _on;
    public Sprite _off;
    private bool flg = false;

    GameObject uid;
    UIDirector uidScript;
    GameObject td;
    TileDirector tdScript;
    GameObject gm;
    GameManager gmScript;

    void Start()
    {
        uid = GameObject.Find("UIDirector");
        uidScript = uid.GetComponent<UIDirector>();

        td = GameObject.Find("TileDirector");
        tdScript = td.GetComponent<TileDirector>();

        gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();
        
    }

    [SerializeField] GameObject visibilityChangeTarget;
    public void changeImage()
    {
        flg = !flg;
        var img = GetComponent<Image>();
        img.sprite = (flg) ? _on : _off;

        
        // 表示する場合はactiveにしてから子要素を作成
        if(flg)
        {
            uidScript.switchVisibility(flg, visibilityChangeTarget);
            uidScript.displayItemWindow();
        }
        // 非表示にする場合、windowがacriveのうちに子要素を消去
        else
        {
            uidScript.destroyItemWindow();
            uidScript.switchVisibility(flg, visibilityChangeTarget);
        }
    }

    public void onDisplayButtonClick()
    {
        gmScript.setTileChangeModeOn();
        var name = this.gameObject.name;
        Item item = uidScript.ItemDataBase.getItemByName(name);
        tdScript.newItemTile = item.tileBase;
    }
}