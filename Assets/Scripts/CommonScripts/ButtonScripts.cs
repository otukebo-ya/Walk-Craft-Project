
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
    public Vector2 defaultPosition;
    public Vector2 defaultAnchors;
    public static int FADE_TIME = 5;
    public bool IsInCanvas;

    public virtual void Awake() {
        IsInCanvas = true;
        Debug.Log(this.name + "is in canvas");
    }

    public void Start()
    {
        button = GetComponent<Button>();
        defaultPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public virtual void OnClick()
    {
        _flg = !_flg;
        Color color = (_flg) ? NormalColor : SelectedColor;
        ChangeBaseColor(color);
    }

    public virtual void ChangeBaseColor(Color color)
    {
        var shape = GetComponent<Shape>();
        if (shape==null)
        {
            return;
        }
        shape.settings.fillColor = color;
    }

    public virtual void ChangeImage()
    {
        var img = GetComponent<Image>();
        img.sprite = (_flg) ? Active : Inactive;
    }
}