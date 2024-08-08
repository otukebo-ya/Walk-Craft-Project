using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // ŽÀ‘•‚·‚éItem‚ÌŽí—Þ
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    public Type type; // Ží—Þ
    public Sprite sprite;// ‰æ‘œ
    public string name;
    public TileBase tileBase;

    

    public Item(Item item)
    {
        this.type = item.type;
        
    }
    public Type getType()
    {
        return type;
    }

    public Sprite getIcon()
    {
        return sprite;
    }

    public string getName()
    {
        return name;
    }

    public TileBase GetTile()
    {
        return tileBase;
    }
}