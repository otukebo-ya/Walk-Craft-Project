using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "BluePrint", menuName = "CreateBluePrint")]
public class BluePrint : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;

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
            _image = value;
        }
    }

    public BluePrint(BluePrint bluePrint)
    {
        this._name = bluePrint._name;
        this._image = bluePrint._image;
    }
}