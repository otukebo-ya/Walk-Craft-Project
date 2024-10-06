
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Shapes2D;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public Shadow shadow;
    public Sprite Active;
    public Sprite Inactive;
    protected bool _flg = true;
    public Color NormalColor;
    public Color SelectedColor;
    //private float BRIGHTNESS_RATIO = 0.9f;

    public void Start()
    {
        button = GetComponent<Button>();
        //shadow = GetComponent<Shadow>();
    }

    public virtual void OnClick()
    {
        _flg = !_flg;
        Color color = (_flg) ? NormalColor : SelectedColor;
        ChangeBaseColor(color);
        //ChangeShadowColor(color);
    }

    public virtual void ChangeBaseColor(Color color)
    {
        var shape = GetComponent<Shape>();

        shape.settings.fillColor = color;
    }
    /*
    public virtual void ChangeShadowColor(Color color)
    {
        Color.RGBToHSV(color, out float h, out float s, out float v);
        float newV = v * BRIGHTNESS_RATIO;
        shadow.effectColor = Color.HSVToRGB(h, s, newV);
        Debug.Log(Color.HSVToRGB(h, s, newV));
    }*/

    public virtual void ChangeImage()
    {
        var img = GetComponent<Image>();
        img.sprite = (_flg) ? Active : Inactive;
    }
}