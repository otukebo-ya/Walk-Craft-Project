using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CraftMaterialDataBase", menuName = "CreateCraftMaterialDataBase")]
public class CraftMaterialDataBase : ScriptableObject
{
    public List<Craftmaterial> materials = new List<Craftmaterial>();

    // ���O�istring�j�̈�v������̂�����Ύ��o��
    public Craftmaterial GetCraftMaterialByName(string name)
    {
        foreach (var material in materials)
        {
            if (material.Name == name)
            {
                return material;
            }
        }
        return null;
    }
}