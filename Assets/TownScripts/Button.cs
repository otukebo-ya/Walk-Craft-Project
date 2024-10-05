using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Button : MonoBehaviour
{
    public Sprite Active;
    public Sprite Inactive;
    protected bool _flg = true;

    void Start()
    {
        
    }

    public virtual void OnClick()
    {
        _flg = !_flg;
        ChangeImage();
    }

    public virtual void ChangeImage()
    {
        var img = GetComponent<Image>();
        img.sprite = (_flg) ? Active : Inactive;
    }
}