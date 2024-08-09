using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    // _on�͒ʏ펞�A_off�͎��s��
    public Sprite Active;
    public Sprite Inactive;
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
        img.sprite = (_flg) ? Active : Inactive;
    }
}