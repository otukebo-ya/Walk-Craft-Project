using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BluePrintDataBase", menuName = "CreateBluePrintDataBase")]
public class BluePrintDataBase : ScriptableObject
{
    public List<BluePrint> bluePrints = new List<BluePrint>();

    // 名前（string）の一致するものがあれば取り出す
    public BluePrint GetBluePrintByName(string name)
    {
        foreach (var bluePrint in bluePrints)
        {
            if (bluePrint.Name == name)
            {
                return bluePrint;
            }
        }
        return null;
    }
}