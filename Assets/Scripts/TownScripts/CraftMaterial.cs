using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Craftmaterial", menuName = "CreateCraftmaterial")]
public class Craftmaterial : ScriptableObject, IInventry
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _numberOfPossessions = 0;

    public string Name
    {
        get
        {
            return _name;
        }
        protected set
        {
            _name = value;
        }
    }

    public Sprite Image
    {
        get
        {
            return _image;
        }
        protected set
        {
            Image = value;
        }
    }
    public int NumberOfPossessions
    {
        get
        {
            return _numberOfPossessions;
        }
        protected set
        {
            _numberOfPossessions = value;
        }
    }
}