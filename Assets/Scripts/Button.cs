using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : TownSceneInitializer
{

    [SerializeField] protected Sprite _on;
    [SerializeField] protected Sprite _off;
    protected bool _flg = false;

    void Start()
    {
        
    }

    public virtual void OnClick()
    {
        ChangeImage();
    }

    public virtual void ChangeImage()
    {
        _flg = !_flg;
        var img = GetComponent<Image>();
        img.sprite = (_flg) ? _on : _off;

    }
}