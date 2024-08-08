using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // ��������Item�̎��
    {
        UserItem,
        //CraftItem,
        //KeyItem,
    }

    public Type type; // ���
    public Sprite sprite;// �摜
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