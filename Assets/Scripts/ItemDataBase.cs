using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<Item> items = new List<Item>();

    public Item GetItemByName(string name)
    {
        foreach (var item in items)
        {
            if (item.name == name)
            {
                return item; 
            }
        }
        return null;
    }
}