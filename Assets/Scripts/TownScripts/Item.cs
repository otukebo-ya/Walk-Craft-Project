using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject, IInventry, IHasTile
{
    public enum Type // 実装するItemの種類
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    [SerializeField] private Type _itemType; // 種類
    [SerializeField] private string _name;
    [SerializeField] private TileBase _tile;
    [SerializeField] private Sprite _activeImage;
    [SerializeField] private Sprite _inactiveImage;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _numberOfPossessions = 0;

    public Type ItemType{ get; protected set; }
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

    public TileBase Tile{
        get {
            return _tile; 
        }
        protected set {
            _tile = value; 
        } 
    }

    public Sprite[] Icons
    {
        get
        {
            Sprite[] icons = { _activeImage, _inactiveImage };
            return icons;
        }
        protected set
        {
            Icons = value;
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

    public int NumberOfPossessions{
        get
        {
            return _numberOfPossessions;
        }
        protected set
        {
            _numberOfPossessions = value;
        }
    }

    public Item(Item item)
    {
        this._itemType = item._itemType;
        this._name = item._name;
        this._tile = item._tile;
        this.Icons = item.Icons;
    }
}