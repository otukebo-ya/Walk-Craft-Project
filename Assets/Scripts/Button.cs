using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : TownSceneInitializer
{

    [SerializeField] protected Sprite _on;
    public Sprite _off;
    protected bool flg = false;

    void Start()
    {
        
    }

    public virtual void onClick()
    {
        changeImage();
    }

    public virtual void changeImage()
    {
        flg = !flg;
        var img = GetComponent<Image>();
        img.sprite = (flg) ? _on : _off;

    }
}