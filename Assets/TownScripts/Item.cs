using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // 実装するItemの種類
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    [SerializeField] private  Type _itemType; // 種類
    [SerializeField] private string _name;
    [SerializeField] private TileBase _tile;
    [SerializeField] private Sprite _activeImage;
    [SerializeField] private Sprite _inactiveImage;

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

    public Item(Item item)
    {
        this._itemType = item._itemType;
        this._name = item._name;
        this._tile = item._tile;
        this.Icons = item.Icons;
    }
}