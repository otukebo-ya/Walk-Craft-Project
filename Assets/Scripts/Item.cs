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

    public Type ItemType; // ���
    public Sprite Sprite;// �摜
    public string Name;
    public TileBase TileBase;

    

    public Item(Item item)
    {
        this.ItemType = item.ItemType;
        
    }
    public Type GetType()
    {
        return ItemType;
    }

    public Sprite GetIcon()
    {
        return Sprite;
    }

    public string GetName()
    {
        return Name;
    }

    public TileBase GetTile()
    {
        return TileBase;
    }
}