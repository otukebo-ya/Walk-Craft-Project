using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Craftmaterial", menuName = "CreateCraftmaterial")]
public class Craftmaterial : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] public int NumberOfPossessions = 0;

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
}